using PassengerTracker.Model;
using System.Windows.Input;

namespace PassengerTracker.ViewModel
{
    /// <summary>
    /// ViewModel для основного окна приложения
    /// </summary>
    public class MainFormViewModel : BaseViewModel
    {
        /// <summary>
        /// Доступ к UI для взаимодействия со всплывающими окнами
        /// </summary>
        private IUIManager _uiManager;

        #region Публичные свойства

        /// <summary>
        /// Состояние открываемого файла
        /// </summary>
        public string FileState { get; set; }

        /// <summary>
        /// Список отображаемых пассажиров
        /// </summary>
        public List<Passenger> Passengers { get; set; }

        #endregion

        #region Команды

        /// <summary>
        /// Команда запуска поиска нужного файла
        /// </summary>
        public ICommand StartFileSearchCommand { get; set; }

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор ViewModel для основного окна приложения
        /// </summary>
        /// <param name="uiManager">Объект, отвечающий за взаимодействие со всплывающими окнами</param>
        public MainFormViewModel(IUIManager uiManager)
        {
            _uiManager = uiManager;

            FileState = "Файл с данными не выбран";
            StartFileSearchCommand = new RelayCommand(OpenFileSearchWindow);
            Passengers = new List<Passenger>();
        }

        #endregion

        #region Методы

        /// <summary>
        /// Открыть окно поиска файла
        /// </summary>
        private void OpenFileSearchWindow()
        {
            string fileName = _uiManager.ShowOpenFileDialog();

            string format = FileFormatManager.GetFileFormat(fileName);
            bool isFileValid = FileFormatManager.IsFileFormatValid(format);

            if (isFileValid)
            {
                ParseData(fileName, format);
            }
            else
            {
                FileState = "Неподдерживаемый формат файла";
                _uiManager.ShowWarningMessage("Данный формат файла не поддерживается для получения информации о пассажирах", "Неверный формат файла");
            }
        }

        /// <summary>
        /// Получить данные из файла
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <param name="format">Формат файла</param>
        private async Task ParseData(string fileName, string format)
        {
            FileFormat fileFormat = FileFormatManager.GetFormat(format);
            IPassengersParser parser = FileParserFactory.GetParser(fileFormat);
            bool isSuccess = false;
            FileState = "Началась загрузка данных из файла...";
            var passengers = await Task.Run(()=> parser.TryParse(fileName, out isSuccess));

            if (isSuccess)
            {
                SetData(passengers);
            }
            else
            {
                FileState = "Выбранный файл не содержит данные, доступные для обработки";
            }
        }

        /// <summary>
        /// Обновить форму, добавив данные о пассажирах
        /// </summary>
        /// <param name="passengers"></param>
        private void SetData(List<Passenger> passengers)
        {
            Passengers = passengers;
            FileState = "Данные из выбранного файла успешно получены!";
        }

        #endregion
    }
}