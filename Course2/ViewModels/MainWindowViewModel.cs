using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows;
using Model;
using WPFMVVMLib.Commands;
using WPFMVVMLib;
using Attribute = Model.Attribute;

//using Model;

namespace Course2.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private VmaContainer _container;

        public MainWindowViewModel()
        {
            Models = new ObservableCollection<ModelGraph>();
            LoadModelsCommand = new DelegateCommand(LoadModels);
            CreateNewModelCommand = new DelegateCommand(CreateNewModel);
            EditModelGraphCommand = new DelegateCommand(EditModelGraph);
            _container = new VmaContainer();
        }

        public ObservableCollection<ModelGraph> Models { get; set; }

        public ModelGraph SelectedModelGraph { get; set; }

        public DelegateCommand LoadModelsCommand { get; set; }

        public DelegateCommand CreateNewModelCommand { get; set; }

        public DelegateCommand EditModelGraphCommand { get; set; }

        public void LoadModels()
        {
            Models.Clear();
            var models = _container.ModelGraphSet.Include("Entities.Attributes").Include("Relationships.Attributes")
                .Include("TransformationsModelText.TransformationRules")
                .Include("TransformationsModelModel.TransformationRules");
            foreach (var modelGraph in models)
            {
                Models.Add(modelGraph);
            }
        }

        public void CreateNewModel()
        {
            var model = new ModelGraph();
            var modelWindow = new ModelWindow(model);
            var result = modelWindow.ShowDialog();
            if (result.HasValue && result.Value)
                if (modelWindow.DataContext is ModelWindowViewModel vm)
                {
                    try
                    {
                        _container.ModelGraphSet.Add(vm.Model);
                        _container.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Не удалось сохранить изменений в базе данных\n" + e.Message, "Ошибка", MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }
                }
        }

        private void EditModelGraph()
        {
            if (SelectedModelGraph == null) return;
            var modelWindow = new ModelWindow(SelectedModelGraph);
            var result = modelWindow.ShowDialog();
            if (result.HasValue && result.Value)
            {
                if (modelWindow.DataContext is ModelWindowViewModel vm)
                {
                    var m = vm.Model;
                    try
                    {
                        //_container.ModelGraphSet.Attach(SelectedModelGraph);
                        //_container.ModelGraphSet.Remove(SelectedModelGraph);
                        //_container.ModelGraphSet.Add(vm.Model);
                        var model = _container.ModelGraphSet.First(x => x.Id == SelectedModelGraph.Id);
                        model.Name = m.Name;
                        SynchronizeEntities(model, m.Entities);
                        //model.Relationships = m.Relationships;
                        //model.TransformationsModelModel = m.TransformationsModelModel;
                        //model.TransformationsModelText = m.TransformationsModelText;
                        _container.SaveChanges();
                        Models.Insert(Models.IndexOf(SelectedModelGraph), vm.Model);
                        Models.Remove(SelectedModelGraph);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Не удалось сохранить изменений в базе данных\n" + e.Message, "Ошибка", MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }
                }
            }
        }

        private void SynchronizeAttributes(Entity entity,
            ICollection<Attribute> synchronizeWith)
        {
            var findedIds = new List<int>();
            findedIds.Add(0);
            foreach (var attribute in synchronizeWith.ToList())
            {
                if (entity.Attributes.Any(x => x.Id == attribute.Id))
                {
                    var atr = entity.Attributes.First(x => x.Id == attribute.Id);
                    atr.DefaultValue = attribute.DefaultValue;
                    atr.Description = attribute.Description;
                    atr.Value = attribute.Value;
                    atr.Type = attribute.Type;
                    atr.Name = attribute.Name;
                    findedIds.Add(attribute.Id);
                }
                else
                {
                    entity.Attributes.Add(attribute);
                }
            }

            var attributesToDelete = entity.Attributes.Where(x => !findedIds.Contains(x.Id)).ToList();
            foreach (var attribute in attributesToDelete)
            {
                entity.Attributes.Remove(attribute);
            }
        }

        private void SynchronizeEntities(ModelGraph model, ICollection<Entity> synchronizeWith)
        {
            var findedIds = new List<int>();
            findedIds.Add(0);
            foreach (var entity in synchronizeWith.ToList())
            {
                if (model.Entities.Any(x => x.Id == entity.Id))
                {
                    var ent = model.Entities.First(x => x.Id == entity.Id);
                    SynchronizeAttributes(ent, entity.Attributes);
                    ent.InstanceCount = entity.InstanceCount;
                    ent.Name = entity.Name;
                    ent.NameUniqueFlag = entity.NameUniqueFlag;
                    findedIds.Add(entity.Id);
                }
                else
                {
                    model.Entities.Add(entity);
                }
            }

            var entitiesToDelete = model.Entities.Where(x => !findedIds.Contains(x.Id)).ToList();
            foreach (var entity in entitiesToDelete)
            {
                model.Entities.Remove(entity);
            }
        }
    }
}


