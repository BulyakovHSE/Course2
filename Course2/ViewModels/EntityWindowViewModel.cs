using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Model;
using WPFMVVMLib;
using WPFMVVMLib.Commands;
using Attribute = Model.Attribute;

namespace Course2.ViewModels
{
    public class EntityWindowViewModel : ViewModelBase
    {
        public EntityWindowViewModel(Entity entity)
        {
            Entity = new Entity{Id = entity.Id, EntityParent = entity.EntityParent, 
                EntityParent1 = entity.EntityParent1, ModelGraphId = entity.ModelGraphId, 
                ModelGraph = entity.ModelGraph, TransformationRuleModelModel = entity.TransformationRuleModelModel, 
                TransformationRuleModelModel1 = entity.TransformationRuleModelModel1, TransformationRuleModelText = entity.TransformationRuleModelText};
            Name = entity.Name;
            InstanceCount = entity.InstanceCount;
            NameUniqueType = entity.NameUniqueFlag;
            NameUniqueTypes = new ObservableCollection<NameUniqueType>(Enum.GetValues(typeof(NameUniqueType)).OfType<NameUniqueType>());
            Attributes = new ObservableCollection<Attribute>(entity.Attributes);
            AddAttributeCommand = new DelegateCommand(AddAttribute);
            DeleteAttributeCommand = new DelegateCommand(DeleteAttribute);
            EditAttributeCommand = new DelegateCommand(EditAttribute);
            SaveCommand = new DelegateCommand(Save);
        }

        public bool IsValid => !string.IsNullOrEmpty(Name);

        public Entity Entity { get; set; }

        public string Name { get;set; }

        public int InstanceCount { get; set; }

        public NameUniqueType NameUniqueType { get; set; }

        public ObservableCollection<NameUniqueType> NameUniqueTypes { get; set; }

        public ObservableCollection<Attribute> Attributes { get; set; }

        public Attribute SelectedAttribute { get; set; }

        public DelegateCommand AddAttributeCommand { get; set; }

        public DelegateCommand DeleteAttributeCommand { get; set; }

        public DelegateCommand EditAttributeCommand { get; set; }

        public DelegateCommand CloseCommand { get; set; }

        public DelegateCommand SaveCommand { get; set; }

        public SimpleCommand<bool?> SetDialogResultCommand { get; set; }

        private void AddAttribute()
        {
            var attribute = new Attribute{EntityId = Entity.Id};
            var attributeWindow = new AttributeWindow(attribute);
            var result = attributeWindow.ShowDialog();
            if (result.HasValue && result.Value)
            {
                if (attributeWindow.DataContext is AttributeWindowViewModel vm)
                {
                    Attributes.Add(vm.Attribute);
                }
            }
        }

        private void DeleteAttribute()
        {
            if(SelectedAttribute == null)return;
            Attributes.Remove(SelectedAttribute);
        }

        private void EditAttribute()
        {
            if(SelectedAttribute == null) return;
            var attributeWindow = new AttributeWindow(SelectedAttribute);
            var result = attributeWindow.ShowDialog();
            if (result.HasValue && result.Value)
            {
                if (attributeWindow.DataContext is AttributeWindowViewModel vm)
                {
                    Attributes.Insert(Attributes.IndexOf(SelectedAttribute), vm.Attribute);
                    Attributes.Remove(SelectedAttribute);
                }
            }
        }

        private void Save()
        {
            Entity.Name = Name;
            Entity.InstanceCount = InstanceCount;
            Entity.Attributes = Attributes;
            Entity.NameUniqueFlag = NameUniqueType;
            SetDialogResultCommand.Execute(true);
            CloseCommand.Execute(null);
        }
    }
}