using System.Collections.ObjectModel;
using Model;
using WPFMVVMLib;
using WPFMVVMLib.Commands;

namespace Course2.ViewModels
{
    public class TransformationModelModelViewModel : ViewModelBase
    {
        public TransformationModelModelViewModel(TransformationModelModel transformation)
        {
            TransformationModelModel = new TransformationModelModel{Id = transformation.Id, 
                ModelGraph = transformation.ModelGraph, ModelGraphId = transformation.ModelGraphId};
            Transformations = new ObservableCollection<TransformationRuleModelModel>(transformation.TransformationRules);
            Name = transformation.Name;
            SaveCommand = new DelegateCommand(Save);
        }

        public bool IsValid => !string.IsNullOrEmpty(Name);

        public string Name { get; set; }

        public ObservableCollection<TransformationRuleModelModel> Transformations { get; set; }

        public TransformationRuleModelModel SelectedTransformationRuleModelModel { get; set; }

        public TransformationModelModel TransformationModelModel { get; set; }

        public DelegateCommand CloseCommand { get; set; }

        public SimpleCommand<bool?> SetDialogResultCommand { get; set; }

        public DelegateCommand SaveCommand { get; set; }

        public DelegateCommand AddTransformationCommand { get; set; }

        public DelegateCommand EditTransformationCommand { get; set; }

        public DelegateCommand DeleteTransformationCommand { get; set; }

        private void Save()
        {
            TransformationModelModel.TransformationRules = Transformations;
            TransformationModelModel.Name = Name;
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
            if (SelectedTransformationRuleModelModel == null) return;
            Transformations.Remove(SelectedTransformationRuleModelModel);
        }
    }


}