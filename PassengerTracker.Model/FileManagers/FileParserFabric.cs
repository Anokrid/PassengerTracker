namespace PassengerTracker.Model
{
    /// <summary>
    /// Класс, создающий парсеры, подходящие под нужны формат данных
    /// </summary>
    public static class FileParserFabric
    {
        /// <summary>
        /// Получить парсер данных для выбранного формата файлов
        /// </summary>
        /// <param name="format">Формат файла, откуда необходимо получить данные</param>
        /// <returns></returns>
        public static IPassengersParser GetParser(FileFormat format)
        {
            switch (format)
            {
                case FileFormat.Xml:
                    return new XmlParser();
                case FileFormat.Json:
                    return new JsonParser();
                default:
                    return new TxtParser();
            }
        }
    }
}
