using PassengerTracker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesGenerator
{
    /// <summary>
    /// Генератор данных для записи в файл
    /// </summary>
    public class DataGenerator
    {
        PassengerGenerator _maleGenerator;
        PassengerGenerator _femaleGenerator;
        FlightGenerator _flightGenerator;
        Random _random;
        
        public DataGenerator()
        {
            _random = new Random();
            _maleGenerator = new MalePassengerGenerator();
            _femaleGenerator = new FemalePassengerGenerator();
            _flightGenerator = new FlightGenerator();
        }

        /// <summary>
        /// Сгенерировать данные о пассажирах для записи в файл
        /// </summary>
        /// <param name="count">Количество пассажиров</param>
        /// <returns></returns>
        public List<Passenger> GeneratePassengers(int count)
        {
            var passengers = new List<Passenger>(count); 
            for (int i = 0; i < count; i++)
            {
                var flight = _flightGenerator.GetRandomFlight();

                int num = _random.Next(0, 2);
                Passenger passenger;
                if (num == 0)
                {
                    passenger = _maleGenerator.GeneratePassenger(flight);
                }
                else
                {
                    passenger = _femaleGenerator.GeneratePassenger(flight);
                }

                passengers.Add(passenger);
            }

            return passengers;
        }
    }
}
