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
            DeleteModelGraphCommand = new DelegateCommand(DeleteModelGraph);
            _container = new VmaContainer();
        }

        public ObservableCollection<ModelGraph> Models { get; set; }

        public ModelGraph SelectedModelGraph { get; set; }

        public DelegateCommand LoadModelsCommand { get; set; }

        public DelegateCommand CreateNewModelCommand { get; set; }

        public DelegateCommand EditModelGraphCommand { get; set; }

        public DelegateCommand DeleteModelGraphCommand { get; set; }

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
                        var model = _container.ModelGraphSet.First(x => x.Id == SelectedModelGraph.Id);
                        model.Name = m.Name;
                        SynchronizeEntities(model.Entities, m.Entities);
                        SynchronizeRelationships(model.Relationships, m.Relationships);
                        SynchronizeTransformationsModelModel(model.TransformationsModelModel, m.TransformationsModelModel);
                        SynchronizeTransformationsModelText(model.TransformationsModelText, m.TransformationsModelText);

                        _container.SaveChanges();
                        Models.Insert(Models.IndexOf(SelectedModelGraph), vm.Model);
                        Models.Remove(SelectedModelGraph);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Не удалось сохранить изменения в базе данных\n" + e.Message, "Ошибка", MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }
                }
            }
        }

        private void DeleteModelGraph()
        {
            if(SelectedModelGraph == null) return;
            try
            {
                foreach (var relationship in SelectedModelGraph.Relationships.ToList())
                {
                    foreach (var relationshipAttribute in relationship.Attributes.ToList())
                        _container.AttributeSet.Remove(relationshipAttribute);

                    _container.RelationshipSet.Remove(relationship);
                }

                foreach (var entity in SelectedModelGraph.Entities.ToList())
                {
                    foreach (var entityAttribute in entity.Attributes.ToList())
                        _container.AttributeSet.Remove(entityAttribute);

                    _container.EntitySet.Remove(entity);
                }

                foreach (var transformationModelModel in SelectedModelGraph.TransformationsModelModel.ToList())
                {
                    foreach (var transformationRuleModelModel in transformationModelModel.TransformationRules.ToList())
                        _container.TransformationRuleModelModelSet.Remove(transformationRuleModelModel);

                    _container.TransformationModelModelSet.Remove(transformationModelModel);
                }

                foreach (var transformationModelText in SelectedModelGraph.TransformationsModelText.ToList())
                {
                    foreach (var transformationRuleModelText in transformationModelText.TransformationRules.ToList())
                        _container.TransformationRuleModelTextSet.Remove(transformationRuleModelText);

                    _container.TransformationModelTextSet.Remove(transformationModelText);
                }

                _container.ModelGraphSet.Remove(SelectedModelGraph);
                Models.Remove(SelectedModelGraph);
                _container.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show("Не удалось сохранить изменения в базе данных\n" + e.Message, "Ошибка", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void SynchronizeAttributes(ICollection<Attribute> attributes,
            ICollection<Attribute> synchronizeWith)
        {
            var findedIds = new List<int>();
            findedIds.Add(0);
            foreach (var attribute in synchronizeWith.ToList())
            {
                if (attributes.Any(x => x.Id == attribute.Id))
                {
                    var atr = attributes.First(x => x.Id == attribute.Id);
                    atr.DefaultValue = attribute.DefaultValue;
                    atr.Description = attribute.Description;
                    atr.Value = attribute.Value;
                    atr.Type = attribute.Type;
                    atr.Name = attribute.Name;
                    findedIds.Add(attribute.Id);
                }
                else
                {
                    attributes.Add(attribute);
                }
            }

            var attributesToDelete = attributes.Where(x => !findedIds.Contains(x.Id)).ToList();
            foreach (var attribute in attributesToDelete)
            {
                attributes.Remove(attribute);
            }
        }

        private void SynchronizeTransformationRules(ICollection<TransformationRuleModelModel> transformationRules,
            ICollection<TransformationRuleModelModel> synchronizeWith)
        {
            var findedIds = new List<int>();
            findedIds.Add(0);
            foreach (var transformationRuleModelModel in synchronizeWith.ToList())
            {
                if (transformationRules.Any(x => x.Id == transformationRuleModelModel.Id))
                {
                    var first = transformationRules.First(x => x.Id == transformationRuleModelModel.Id);
                    first.Final = transformationRuleModelModel.Final;
                    first.Initial = transformationRuleModelModel.Initial;
                    findedIds.Add(transformationRuleModelModel.Id);
                }
                else
                {
                    transformationRules.Add(transformationRuleModelModel);
                }
            }

            var toDelete = transformationRules.Where(x => !findedIds.Contains(x.Id)).ToList();
            foreach (var transformationRuleModelModel in toDelete)
            {
                transformationRules.Remove(transformationRuleModelModel);
            }
        }

        private void SynchronizeTransformationRules(ICollection<TransformationRuleModelText> transformationRules,
            ICollection<TransformationRuleModelText> synchronizeWith)
        {
            var findedIds = new List<int>();
            findedIds.Add(0);
            foreach (var transformationRuleModelModel in synchronizeWith.ToList())
            {
                if (transformationRules.Any(x => x.Id == transformationRuleModelModel.Id))
                {
                    var first = transformationRules.First(x => x.Id == transformationRuleModelModel.Id);
                    first.Final = transformationRuleModelModel.Final;
                    first.Initial = transformationRuleModelModel.Initial;
                    findedIds.Add(transformationRuleModelModel.Id);
                }
                else
                {
                    transformationRules.Add(transformationRuleModelModel);
                }
            }

            var toDelete = transformationRules.Where(x => !findedIds.Contains(x.Id)).ToList();
            foreach (var transformationRuleModelModel in toDelete)
            {
                transformationRules.Remove(transformationRuleModelModel);
            }
        }

        private void SynchronizeEntities(ICollection<Entity> entities, ICollection<Entity> synchronizeWith)
        {
            var findedIds = new List<int>();
            findedIds.Add(0);
            foreach (var entity in synchronizeWith.ToList())
            {
                if (entities.Any(x => x.Id == entity.Id))
                {
                    var ent = entities.First(x => x.Id == entity.Id);
                    SynchronizeAttributes(ent.Attributes, entity.Attributes);
                    ent.InstanceCount = entity.InstanceCount;
                    ent.Name = entity.Name;
                    ent.NameUniqueFlag = entity.NameUniqueFlag;
                    findedIds.Add(entity.Id);
                }
                else
                {
                    entities.Add(entity);
                }
            }

            var entitiesToDelete = entities.Where(x => !findedIds.Contains(x.Id)).ToList();
            foreach (var entity in entitiesToDelete)
            {
                entities.Remove(entity);
            }
        }

        private void SynchronizeRelationships(ICollection<Relationship> relationships, ICollection<Relationship> synchronizeWith)
        {
            var findedIds = new List<int>();
            findedIds.Add(0);
            foreach (var relationship in synchronizeWith.ToList())
            {
                if (relationships.Any(x => x.Id == relationship.Id))
                {
                    var rel = relationships.First(x => x.Id == relationship.Id);
                    SynchronizeAttributes(rel.Attributes, rel.Attributes);
                    rel.Entity1 = relationship.Entity1;
                    rel.Entity2 = relationship.Entity2;
                    rel.Name = relationship.Name;
                    rel.Multiplicity1 = relationship.Multiplicity1;
                    rel.Multiplicity2 = relationship.Multiplicity2;
                    rel.NameUniqueFlag = relationship.NameUniqueFlag;
                    rel.Type = relationship.Type;
                    findedIds.Add(rel.Id);
                }
                else
                {
                    relationships.Add(relationship);
                }
            }

            var toDelete = relationships.Where(x => !findedIds.Contains(x.Id)).ToList();
            foreach (var relationship in toDelete)
            {
                relationships.Remove(relationship);
            }
        }

        private void SynchronizeTransformationsModelModel(ICollection<TransformationModelModel> transformations,
            ICollection<TransformationModelModel> synchronizeWith)
        {
            var findedIds = new List<int>();
            findedIds.Add(0);
            foreach (var transformationModelModel in synchronizeWith.ToList())
            {
                if (transformations.Any(x => x.Id == transformationModelModel.Id))
                {
                    var first = transformations.First(x => x.Id == transformationModelModel.Id);
                    first.Name = transformationModelModel.Name;
                    SynchronizeTransformationRules(first.TransformationRules, transformationModelModel.TransformationRules);
                    findedIds.Add(transformationModelModel.Id);
                }
                else
                {
                    transformations.Add(transformationModelModel);
                }
            }

            var toDelete = transformations.Where(x => !findedIds.Contains(x.Id)).ToList();
            foreach (var transformationModelModel in toDelete)
            {
                transformations.Remove(transformationModelModel);
            }
        }

        private void SynchronizeTransformationsModelText(ICollection<TransformationModelText> transformations,
            ICollection<TransformationModelText> synchronizeWith)
        {
            var findedIds = new List<int>();
            findedIds.Add(0);
            foreach (var transformationModelText in synchronizeWith.ToList())
            {
                if (transformations.Any(x => x.Id == transformationModelText.Id))
                {
                    var first = transformations.First(x => x.Id == transformationModelText.Id);
                    first.Name = transformationModelText.Name;
                    SynchronizeTransformationRules(first.TransformationRules, transformationModelText.TransformationRules);
                    findedIds.Add(transformationModelText.Id);
                }
                else
                {
                    transformations.Add(transformationModelText);
                }
            }

            var toDelete = transformations.Where(x => !findedIds.Contains(x.Id)).ToList();
            foreach (var transformationModelModel in toDelete)
            {
                transformations.Remove(transformationModelModel);
            }
        }
    }
}


