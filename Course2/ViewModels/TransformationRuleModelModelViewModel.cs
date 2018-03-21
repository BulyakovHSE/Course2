using Model;
using WPFMVVMLib;
using WPFMVVMLib.Commands;

namespace Course2.ViewModels
{
    public class TransformationRuleModelModelViewModel : ViewModelBase
    {
        public TransformationRuleModelModelViewModel(TransformationRuleModelModel transformationRule)
        {
            TransformationRuleModelModel = new TransformationRuleModelModel{Id = transformationRule.Id, 
                TransformationModelModel = transformationRule.TransformationModelModel, 
                TransformationModelModelId = transformationRule.TransformationModelModelId};
        }

        public TransformationRuleModelModel TransformationRuleModelModel { get; set; }

        public Entity InitialEntity { get; set; }

        public Entity FinalEntity { get; set; }

        public DelegateCommand CloseCommand { get; set; }

        public DelegateCommand SaveCommand { get; set; }

        public SimpleCommand<bool?> SetDialogResultCommand { get; set; }
    }
}