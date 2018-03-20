using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Course2.ViewModels;
using WPFMVVMLib.Commands;

namespace Course2
{
    /// <summary>
    /// Interaction logic for AttributeWindow.xaml
    /// </summary>
    public partial class AttributeWindow : Window
    {
        public AttributeWindow(Model.Attribute attribute)
        {
            InitializeComponent();
            var vm = new AttributeWindowViewModel(attribute) { CloseCommand = new DelegateCommand(Close), 
                SetDialogResultCommand = new SimpleCommand<bool?>(SetDialogResult)};
            DataContext = vm;
        }

        private void SetDialogResult(bool? result)
        {
            DialogResult = result;
        }
    }
}
