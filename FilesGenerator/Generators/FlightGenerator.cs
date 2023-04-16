using PassengerTracker.Model;

namespace FilesGenerator
{
    /// <summary>
    /// Класс, генерирующий рейсы
    /// </summary>
    public class FlightGenerator
    {
        /// <summary>
        /// Набор данных по доступным рейсам
        /// </summary>
        private Flight[] _flightDataSet;

        /// <summary>
        /// Генератор случайных чисел
        /// </summary>
        private Random _random;

        public FlightGenerator()
        {
            _random = new Random();

            _flightDataSet = new Flight[]
            {
                new Flight("WZ 9925", "16:40"),
                new Flight("SU 1192", "12:35"),
                new Flight("ЮВ 521", "17:20"),
                new Flight("S7 892", "10:15"),
                new Flight("SU 1168", "07:20"),
                new Flight("SU 1154", "20:00"),
                new Flight("S7 345", "18:45"),
                new Flight("U6 627", "19:50"),
                new Flight("U6 407", "12:00"),
                new Flight("WZ 841", "13:55"),
            };
        }

        /// <summary>
        /// Получить случайный номер рейса
        /// </summary>
        /// <returns></returns>
        public Flight GetRandomFlight()
        {
            int number = _random.Next(0, _flightDataSet.Length);
            return _flightDataSet[number];
        }
    }
}
