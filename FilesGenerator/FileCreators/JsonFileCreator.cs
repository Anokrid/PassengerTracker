using PassengerTracker.Model;
using System.Runtime.Serialization.Json;
using System.Text;

namespace FilesGenerator
{
    /// <summary>
    /// Класс, сохраняющий данные о пассажирах в формате .json
    /// </summary>
    public class JsonFileCreator : IFileCreator
    {
        public bool CreateFile(List<Passenger> passengers)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Passenger>));
            string fileName = "Passengers.json";
            try
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    using (var writer = JsonReaderWriterFactory.CreateJsonWriter(fs, Encoding.UTF8, true))
                    {
                        jsonFormatter.WriteObject(writer, passengers);
                        writer.Flush();
                    }
                }
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
