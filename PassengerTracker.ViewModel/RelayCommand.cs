using System.Windows.Input;

namespace PassengerTracker.ViewModel
{
    /// <summary>
    /// Класс команды, унаследованный от <see cref="ICommand"/>, и хранящий одно действие <see cref="Action"/>
    /// </summary>
    public class RelayCommand : ICommand
    {

        /// <summary>
        /// Действие, которые выполняет команда
        /// </summary>
        private Action _action;

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public RelayCommand(Action action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
