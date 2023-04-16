namespace PassengerTracker.Core
{
    /// <summary>
    /// Интерфейс для взаимодействия с классом, создающим всплывающие окна
    /// </summary>
    public interface IUIManager
    {
        /// <summary>
        /// Создать предупреждающее окно
        /// </summary>
        /// <param name="message">Сообщение, отображаемое в окне</param>
        /// <param name="title">Заголовок окна</param>
        void ShowWarningMessage(string message, string title = "");

        /// <summary>
        /// Создать окно выбора файла
        /// </summary>
        /// <returns></returns>
        string ShowOpenFileDialog();
    }
}
