using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Catalog_Level_WPF_Model
{
    public class DelegateCommand : ICommand
    {
        private Action<object> execute; // выполняет логику команды

        private Func<object, bool> canExecute; // определяет, может ли команда выполняться

        public event EventHandler CanExecuteChanged // вызывается при изменении условий, указывающий, может ли команда выполняться
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public DelegateCommand(Action<object> _execute, Func<object,bool> _canExecute = null)
        {
            execute = _execute;
            canExecute = _canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
