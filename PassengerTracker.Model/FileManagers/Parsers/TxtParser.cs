using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassengerTracker.Model
{
    /// <summary>
    /// Класс, который парсит txt файлы с целью получения информации о пассажирах
    /// </summary>
    public class TxtParser : IPassengersParser
    {
        public List<Passenger> TryParse(string fileName, out bool isSuccess)
        {
            try
            {
                var passengers = new List<Passenger>();
                string[] lines = File.ReadAllLines(fileName);
                for (int i =  0; i < lines.Length; i++)
                {
                    string[] data = lines[i].Split(' ');
                    if (data.Length < 5 || data.Length > 7)
                    {
                        isSuccess = false;
                        return null;
                    }

                    var passenger = ParseData(data);
                    passengers.Add(passenger);
                }

                isSuccess = true;
                return passengers;
            }
            catch
            {
                isSuccess = false;
                return null;
            }
        }

        /// <summary>
        /// Получить данные о пассажире
        /// </summary>
        /// <param name="data">Набор данных, которые необходимо отсортировать</param>
        /// <returns></returns>
        private Passenger ParseData(string[] data)
        {
            Flight flight;
            if (data.Length == 5)
            {
                flight = new Flight(data[3], data[4]);
            }
            else
            {
                flight = new Flight(data[3] + data[4], data[5]);
            }

            string surname = data[0];
            string name = data[1];
            string patronymic = data[2];

            var passenger = new Passenger(name, surname, patronymic, flight);
            return passenger;
        }
    }
}
