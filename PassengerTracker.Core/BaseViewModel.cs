using System.ComponentModel;


namespace PassengerTracker.Core
{
    /// <summary>
    /// Базовый класс для всех ViewModel
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Событие, происходящее при изменении значения свойства (Property)
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Вызывается при изменении свойства (Property)
        /// </summary>
        /// <param name="name">Имя свойства (Property), изменившего значение</param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
