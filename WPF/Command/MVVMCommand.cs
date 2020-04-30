using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF.Command
{
    class MVVMCommand : ICommand
    {
        Action<object> executeAction;
        Func<object, bool> canExecute;

        public MVVMCommand(Action<object> executeAction, Func<object, bool> canExecute)
        {
            this.canExecute = canExecute;
            this.executeAction = executeAction;
        }

        event EventHandler ICommand.CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        bool ICommand.CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute(parameter);
        }

        void ICommand.Execute(object parameter)
        {
            executeAction(parameter);
        }
    }
}
