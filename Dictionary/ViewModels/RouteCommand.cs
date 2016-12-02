using System;
using System.Windows.Input;

namespace Dictionary.ViewModels
{
    class RouteCommand : ICommand
    {
        private readonly Action<object> _command;

        public RouteCommand(Action<object> command)
        {
            _command = command;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _command(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}
