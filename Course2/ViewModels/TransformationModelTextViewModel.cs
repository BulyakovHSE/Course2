using System.Collections.ObjectModel;
using Model;
using WPFMVVMLib;
using WPFMVVMLib.Commands;

namespace Course2.ViewModels
{
    public class TransformationModelTextViewModel : ViewModelBase
    {
        public TransformationModelTextViewModel(TransformationModelText transformation)
        {
            TransformationModelText = new TransformationModelText{Id = transformation.Id, ModelGraph = transformation.ModelGraph,
                ModelGraphId = transformation.ModelGraphId};
            Name = transformation.Name;
            Transformations = new ObservableCollection<TransformationRuleModelText>(transformation.TransformationRules);

            SaveCommand = new DelegateCommand(Save);
            AddTransformationCommand = new DelegateCommand(AddTransformation);
            EditTransformationCommand = new DelegateCommand(EditTransformation);
            DeleteTransformationCommand = new DelegateCommand(EditTransformation);
        }

        public bool IsValid => !string.IsNullOrEmpty(Name);

        public string Name { get; set; }

        public ObservableCollection<TransformationRuleModelText> Transformations { get; set; }

        public TransformationRuleModelText SelectedTransformationRuleModelText { get; set; }

        public TransformationModelText TransformationModelText { get; set; }

        public DelegateCommand CloseCommand { get; set; }

        public DelegateCommand SaveCommand { get; set; }

        public SimpleCommand<bool?> SetDialogResultCommand { get; set; }

        public DelegateCommand AddTransformationCommand { get; set; }

        public DelegateCommand EditTransformationCommand { get; set; }

        public DelegateCommand DeleteTransformationCommand { get; set; }

        private void Save()
        {
            TransformationModelText.Name = Name;
            TransformationModelText.TransformationRules = Transformations;
            SetDialogResultCommand.Execute(true);
            CloseCommand.Execute(null);
        }

        private void AddTransformation()
        {
            //
        }

        private void EditTransformation()
        {
            //
        }

        private void DeleteTransformation()
        {
            if(SelectedTransformationRuleModelText==null)return;
            Transformations.Remove(SelectedTransformationRuleModelText);
        }
    }
}