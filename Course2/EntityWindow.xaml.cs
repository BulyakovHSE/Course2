﻿using System;
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
    /// Interaction logic for EntityWindow.xaml
    /// </summary>
    public partial class EntityWindow : Window
    {
        public EntityWindow(Entity entity)
        {
            InitializeComponent();
            var vm = new EntityWindowViewModel(entity) {CloseCommand = new DelegateCommand(Close), 
                SetDialogResultCommand = new SimpleCommand<bool?>(SetDialogResult)};
            DataContext = vm;
        }

        private void SetDialogResult(bool? result)
        {
            DialogResult = result;
        }
    }
}
