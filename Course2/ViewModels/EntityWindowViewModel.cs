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
            Entity = (Entity) entity.Clone();
            Name = Entity.Name;
            InstanceCount = Entity.InstanceCount;
            NameUniqueType = Entity.NameUniqueFlag;
            NameUniqueTypes = new ObservableCollection<NameUniqueType>(Enum.GetValues(typeof(NameUniqueType)).OfType<NameUniqueType>());
            Attributes = new ObservableCollection<Attribute>(Entity.Attributes);
            AddAttributeCommand = new DelegateCommand(AddAttribute);
            DeleteAttributeCommand = new DelegateCommand(DeleteAttribute);
            SaveCommand = new DelegateCommand(Save);
        }

        public Entity Entity { get; set; }

        public string Name { get;set; }

        public int InstanceCount { get; set; }

        public NameUniqueType NameUniqueType { get; set; }

        public ObservableCollection<NameUniqueType> NameUniqueTypes { get; set; }

        public ObservableCollection<Attribute> Attributes { get; set; }

        public Attribute SelectedAttribute { get; set; }

        public DelegateCommand AddAttributeCommand { get; set; }

        public DelegateCommand DeleteAttributeCommand { get; set; }

        public DelegateCommand CloseCommand { get; set; }

        public DelegateCommand SaveCommand { get; set; }

        public SimpleCommand<bool?> SetDialogResultCommand { get; set; }

        private void AddAttribute()
        {
            MessageBox.Show("Not implemented yet");
        }

        private void DeleteAttribute()
        {
            if(SelectedAttribute == null)return;
            Attributes.Remove(SelectedAttribute);
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