namespace PassengerTracker.Model
{
    /// <summary>
    /// Менеджер доступных форматов файлов, пригодных для извлечения информации о пассажирах
    /// </summary>
    public static class FileFormatManager
    {
        /// <summary>
        /// Форматы файлов, доступные для парсинга
        /// </summary>
        private static Dictionary<string, FileFormat> _availableFormats;

        static FileFormatManager()
        {
            _availableFormats = new Dictionary<string, FileFormat>
            {
                { ".txt", FileFormat.Txt },
                { ".json", FileFormat.Json },
                { ".xml", FileFormat.Xml },
            };
        }
        
        /// <summary>
        /// Получить формат файла
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <returns></returns>
        public static string GetFileFormat(string fileName)
        {
            string ext = Path.GetExtension(fileName);
            return ext;
        }

        /// <summary>
        /// Получить тип формата файла
        /// </summary>
        /// <param name="format">Текстовое описание форимата файла</param>
        /// <returns></returns>
        public static FileFormat GetFormat(string format)
        {
            return _availableFormats[format];
        }

        /// <summary>
        /// Является ли выбранный формат файла поддерживаемым приложением
        /// </summary>
        /// <param name="format">Формат файла, который необходимо проверить</param>
        /// <returns></returns>
        public static bool IsFileFormatValid(string format)
        {
            return _availableFormats.ContainsKey(format);
        }

        /// <summary>
        /// Получить список всех поддерживаемых форматов
        /// </summary>
        /// <returns></returns>
        public static List<FileFormat> GetAvailableFileFormats() 
        {
            var formats = new List<FileFormat>();
            foreach (var format in _availableFormats.Values)
            {
                formats.Add(format);
            }
            return formats;
        }
    }
}
