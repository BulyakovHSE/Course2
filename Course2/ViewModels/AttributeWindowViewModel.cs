using Model;
using WPFMVVMLib;
using WPFMVVMLib.Commands;

namespace Course2.ViewModels
{
    public class AttributeWindowViewModel : ViewModelBase
    {
        public AttributeWindowViewModel(Attribute attribute)
        {
            Attribute = new Attribute();
            Name = attribute.Name;
            Type = attribute.Type;
            Value = attribute.Value;
            DefaultValue = attribute.DefaultValue;
            Description = attribute.Description;
            SaveCommand = new DelegateCommand(Save);
        }

        public Attribute Attribute { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Value { get;set; }

        public string DefaultValue { get; set; }

        public string Description { get;set; }

        public DelegateCommand CloseCommand { get; set; }

        public DelegateCommand SaveCommand { get;set; }

        public SimpleCommand<bool?> SetDialogResultCommand { get; set; }

        private void Save()
        {
            Attribute.Name = Name;
            Attribute.DefaultValue = DefaultValue;
            Attribute.Type = Type;
            Attribute.Value = Value;
            Attribute.Description = Description;
            SetDialogResultCommand.Execute(true);
            CloseCommand.Execute(null);
        }
    }
}