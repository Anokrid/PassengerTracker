using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PassengerTracker.Model
{
    /// <summary>
    /// Парсер данных о пассажирах из файлов в формате .xml
    /// </summary>
    public class XmlParser : IPassengersParser
    {
        public List<Passenger> TryParse(string fileName, out bool isSuccess)
        {
            try
            {
                List<Passenger> passengers;
                var xmlSerializer = new XmlSerializer(typeof(List<Passenger>));
                using (var fs = new FileStream(fileName, FileMode.Open))
                {
                    passengers = xmlSerializer.Deserialize(fs) as List<Passenger>;
                }

                isSuccess = passengers != null && passengers.Count > 0;
                return passengers;
            }
            catch
            {
                isSuccess = false;
                return null;
            }
        }
    }
}
