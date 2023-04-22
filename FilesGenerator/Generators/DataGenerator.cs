using PassengerTracker.Model;

namespace FilesGenerator
{
    /// <summary>
    /// Генератор данных для записи в файл
    /// </summary>
    public class DataGenerator
    {
        /// <summary>
        /// Генератор авиарейсов
        /// </summary>
        private FlightGenerator _flightGenerator;

        /// <summary>
        /// Набор генераторов пассажиров мужского и женского пола
        /// </summary>
        private PassengerGenerator[] _passengerGenerators;

        /// <summary>
        /// Генератор случайных чисел (для выбора индекса
        /// </summary>
        private Random _random;
        
        public DataGenerator()
        {
            _random = new Random();
            _passengerGenerators = new PassengerGenerator[]
            {
                new MalePassengerGenerator(),
                new FemalePassengerGenerator()
            }; 
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

                int generatorId = _random.Next(0, 2);
                Passenger passenger = _passengerGenerators[generatorId].GeneratePassenger(flight);
                passengers.Add(passenger);
            }

            return passengers;
        }
    }
}
