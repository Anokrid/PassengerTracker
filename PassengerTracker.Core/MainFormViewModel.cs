using PassengerTracker.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PassengerTracker.Core
{
    /// <summary>
    /// ViewModel для основного окна приложения
    /// </summary>
    public class MainFormViewModel : BaseViewModel
    {
        #region Публичные свойства

        /// <summary>
        /// Состояние открываемого файла
        /// </summary>
        public string FileState { get; set; }

        /// <summary>
        /// Список отображаемых пассажиров
        /// </summary>
        public ObservableCollection<Passenger> Passengers { get; set; }

        #endregion

        #region Команды

        /// <summary>
        /// Команда запуска поиска нужного файла
        /// </summary>
        public ICommand StartFileSearchCommand { get; set; }

        #endregion

        #region Конструктор

        public MainFormViewModel()
        {
            FileState = "Файл не выбран";
            StartFileSearchCommand = new RelayCommand(OpenFileSearchWindow);
            Passengers = new ObservableCollection<Passenger>();
        }

        #endregion

        #region Методы

        /// <summary>
        /// Открыть окно поиска файла
        /// </summary>
        private void OpenFileSearchWindow()
        {
            string fileName = IoC.UI.ShowOpenFileDialog();
            CheckIfIsNoFile(fileName);

            string format = FileFormatManager.GetFileFormat(fileName);
            bool isFileValid = FileFormatManager.IsFileFormatValid(format);

            if (isFileValid)
            {
                ParseData(fileName, format);
            }
            else
            {
                FileState = "Неподдерживаемый формат файла";
                IoC.UI.ShowWarningMessage("Данный формат файла не поддерживается для получения информации о пассажирах", "Неверный формат файла");
            }
        }

        /// <summary>
        /// Проверить, а был ли выбран файл
        /// </summary>
        /// <param name="fileName">Имя файла на проверку</param>
        private void CheckIfIsNoFile(string fileName)
        {
            if (fileName == "")
            {
                FileState = "Файл не выбран";
                return;
            }
        }

        /// <summary>
        /// Получить данные из файла
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <param name="format">Формат файла</param>
        private void ParseData(string fileName, string format)
        {
            FileFormat fileFormat = FileFormatManager.GetFormat(format);
            IPassengersParser parser = FileParserFabric.GetParser(fileFormat);
            bool isSuccess;
            FileState = "Началась загрузка данных из файла...";
            var passengers = parser.TryParse(fileName, out isSuccess);

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
            Passengers.Clear();
            for (int i = 0; i < passengers.Count; i++)
            {
                Passengers.Add(passengers[i]);
            }
            FileState = "Данные из выбранного файла получены успешно!";
        }

        #endregion
    }
}