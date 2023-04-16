using PassengerTracker.Model;

namespace FilesGenerator
{
    /// <summary>
    /// Интерфейс генераторов файлов с данными о пассажирах
    /// </summary>
    public interface IFileCreator
    {
        /// <summary>
        /// Создать файл и записать данные о пассажирах
        /// </summary>
        /// <returns></returns>
        bool CreateFile(List<Passenger> passengers);

    }
}
