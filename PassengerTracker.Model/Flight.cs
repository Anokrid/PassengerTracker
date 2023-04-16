using System.Runtime.Serialization;

namespace PassengerTracker.Model
{
    /// <summary>
    /// Пассажирский рейс
    /// </summary>
    [DataContract]
    [Serializable]
    public class Flight
    {
        /// <summary>
        /// Номер рейса
        /// </summary>
        [DataMember]
        public string Number { get; set; }

        /// <summary>
        /// Время отправления
        /// </summary>
        [DataMember]
        public string DepartureTime { get; set; }

        /// <summary>
        /// Создание нового пассажирского рейса
        /// </summary>
        /// <param name="number">Номер нового рейса</param>
        /// <param name="departureTime">Время вылета</param>
        public Flight(string number, string departureTime)
        {
            Number = number;
            DepartureTime = departureTime;
        }

        /// <summary>
        /// Конструктор для сериализации
        /// </summary>
        public Flight() { }
    }
}
