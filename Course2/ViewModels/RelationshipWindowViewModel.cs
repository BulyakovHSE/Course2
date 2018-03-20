using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Model;
using WPFMVVMLib;
using WPFMVVMLib.Commands;
using Attribute = Model.Attribute;

namespace Course2.ViewModels
{
    public class RelationshipWindowViewModel : ViewModelBase
    {
        public RelationshipWindowViewModel(Relationship relationship, IList<Entity> entities)
        {
            Relationship = new Relationship{Id = relationship.Id, 
                ModelGraph = relationship.ModelGraph, ModelGraphId = relationship.ModelGraphId};
            Name = relationship.Name;
            Multiplicity1 = relationship.Multiplicity1;
            Multiplicity2 = relationship.Multiplicity2;
            NameUniqueType = relationship.NameUniqueFlag;
            NameUniqueTypes = new ObservableCollection<NameUniqueType>(Enum.GetValues(typeof(NameUniqueType)).OfType<NameUniqueType>());
            Type = relationship.Type;
            Types = new ObservableCollection<RelationshipType>(Enum.GetValues(typeof(RelationshipType)).OfType<RelationshipType>());
            Entity1 = relationship.Entity1;
            Entity2 = relationship.Entity2;
            Attributes = new ObservableCollection<Attribute>(relationship.Attributes);
            Entity1List = new ObservableCollection<Entity>(entities);
            Entity2List = new ObservableCollection<Entity>(entities);

            AddAttributeCommand = new DelegateCommand(AddAttribute);
            EditAttributeCommand = new DelegateCommand(EditAttribute);
            DeleteAttributeCommand = new DelegateCommand(DeleteAttribute);
        }

        public string Name { get; set; }

        public int Multiplicity1 { get; set; }

        public int Multiplicity2 { get; set; }

        public NameUniqueType NameUniqueType { get; set; }

        public ObservableCollection<NameUniqueType> NameUniqueTypes { get; set; }

        public RelationshipType Type { get; set; }

        public ObservableCollection<RelationshipType> Types { get; set; }

        public ObservableCollection<Entity> Entity1List { get; set; }

        public ObservableCollection<Entity> Entity2List { get; set; }

        public Entity Entity1 { get; set; }

        public Entity Entity2 { get; set; }

        public ObservableCollection<Attribute> Attributes { get; set; }

        public Attribute SelectedAttribute { get; set; }

        public Relationship Relationship { get; set; }

        public DelegateCommand CloseCommand { get; set; }

        public DelegateCommand SaveCommand { get; set; }

        public DelegateCommand AddAttributeCommand { get; set; }

        public DelegateCommand DeleteAttributeCommand { get; set; }

        public DelegateCommand EditAttributeCommand { get; set; }

        public SimpleCommand<bool?> SetDialogResultCommand { get; set; }

        private void AddAttribute()
        {
            var attribute = new Attribute();
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
            if (SelectedAttribute == null) return;
            Attributes.Remove(SelectedAttribute);
        }

        private void EditAttribute()
        {
            if (SelectedAttribute == null) return;
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
    }
}