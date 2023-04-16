using FilesGenerator.FileCreators;
using PassengerTracker.Model;

namespace FilesGenerator
{
    /// <summary>
    /// Класс, создающий генератор файлов специально под нужный формат
    /// </summary>
    public static class FileCreatorFabric
    {
        /// <summary>
        /// Получить генератор файла под нужный формат
        /// </summary>
        /// <param name="fileFormat">Формат, в котором должен быть сохранён фал</param>
        /// <returns></returns>
        public static IFileCreator GetCreator(FileFormat fileFormat)
        {
            switch (fileFormat)
            {
                case FileFormat.Txt:
                    return new TxtFileCreator();
                case FileFormat.Xml:
                    return new XmlFileCreator();
                case FileFormat.Json:
                    return new JsonFileCreator();
            }
            return null;
        }
    }
}
