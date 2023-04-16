using System.Runtime.Serialization.Json;

namespace PassengerTracker.Model
{
    /// <summary>
    /// Парсер данных о пассажирах из файлов в формате .json
    /// </summary>
    public class JsonParser : IPassengersParser
    {
        public List<Passenger> TryParse(string fileName, out bool isSuccess)
        {
            try
            {
                List<Passenger> passengers;

                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Passenger>));
                using (FileStream fs = new FileStream(fileName, FileMode.Open))
                {
                    passengers = (List<Passenger>) jsonFormatter.ReadObject(fs);
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
