﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFAuction.ViewModels;

namespace WPFAuction.Command
{
    public class EditCommand : ICommand
    {
        MainViewModel vm;
        public event EventHandler CanExecuteChanged;
        public EditCommand(MainViewModel vm) { this.vm = vm; }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            vm.EditValue?.Invoke();
        }
    }
}
