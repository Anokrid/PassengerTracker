using PassengerTracker.Model;
using System.Windows.Input;

namespace PassengerTracker.Core
{
    /// <summary>
    /// ViewModel для основного окна приложения
    /// </summary>
    public class MainFormViewModel : BaseViewModel
    {
        /// <summary>
        /// Контекст синхронизации с основным потоком приложения
        /// </summary>
        private SynchronizationContext _uiContext;

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

        public MainFormViewModel()
        {
            _uiContext = SynchronizationContext.Current;

            FileState = "Файл с данными не выбран";
            StartFileSearchCommand = new RelayCommand(() => Task.Run(OpenFileSearchWindow));
            Passengers = new List<Passenger>();
        }

        #endregion

        #region Методы

        /// <summary>
        /// Открыть окно поиска файла
        /// </summary>
        private async Task OpenFileSearchWindow()
        {
            string fileName = IoC.UI.ShowOpenFileDialog();
            CheckIfIsNoFile(fileName);

            string format = FileFormatManager.GetFileFormat(fileName);
            bool isFileValid = FileFormatManager.IsFileFormatValid(format);

            if (isFileValid)
            {
                await ParseData(fileName, format);
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
                FileState = "Файл с данными не выбран";
                return;
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
            IPassengersParser parser = FileParserFabric.GetParser(fileFormat);
            bool isSuccess = false;
            FileState = "Началась загрузка данных из файла...";
            var passengers = await Task.Run(()=> parser.TryParse(fileName, out isSuccess));

            if (isSuccess)
            {
                _uiContext.Send(x => SetData(passengers), null);
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