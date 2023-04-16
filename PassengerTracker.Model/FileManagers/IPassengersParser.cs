namespace PassengerTracker.Model
{
    /// <summary>
    /// Интерфейс для парсеров данных о пассажирах из файлов
    /// </summary>
    public interface IPassengersParser
    {
        /// <summary>
        /// Попытаться получить данные о пассажирах из файла
        /// </summary>
        /// <param name="fileName">Имя файла, откуда будет осуществляться чтение информации</param>
        /// <param name="isSuccess">Удалось ли получить данные</param>
        /// <returns>Список пассажиров</returns>
        public List<Passenger> TryParse(string fileName, out bool isSuccess);
    }
}
