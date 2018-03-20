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
using Model;
using WPFMVVMLib.Commands;

namespace Course2
{
    /// <summary>
    /// Interaction logic for ModelWindow.xaml
    /// </summary>
    public partial class ModelWindow : Window
    {
        public ModelWindow(ModelGraph model)
        {
            InitializeComponent();
            var vm = new ModelWindowViewModel(model) { CloseCommand = new DelegateCommand(this.Close) };
            DataContext = vm;
        }
    }
}
