using PassengerTracker.Model;
using System.Xml.Serialization;

namespace FilesGenerator.FileCreators
{
    /// <summary>
    /// Класс, сохраняющий данные о пассажирах в формате .xml
    /// </summary>
    public class XmlFileCreator : IFileCreator
    {
        public bool CreateFile(List<Passenger> passengers)
        {
            try
            {
                string fileName = "Passengers.xml";
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Passenger>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    xmlSerializer.Serialize(fs, passengers);
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
