using Model;
using WPFMVVMLib;
using WPFMVVMLib.Commands;

namespace Course2.ViewModels
{
    public class TransformationRuleModelTextViewModel : ViewModelBase
    {
        public TransformationRuleModelTextViewModel(TransformationRuleModelText transformationRule)
        {
            TransformationRuleModelText = new TransformationRuleModelText{Id = transformationRule.Id, 
                TransformationModelText = transformationRule.TransformationModelText, 
                TransformationModelTextId = transformationRule.TransformationModelTextId};
        }

        public TransformationRuleModelText TransformationRuleModelText { get; set; }

        public DelegateCommand CloseCommand { get; set; }

        public DelegateCommand SaveCommand { get; set; }

        public SimpleCommand<bool?> SetDialogResultCommand { get; set; }
    }
}