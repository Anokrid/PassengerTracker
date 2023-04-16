using System.Runtime.Serialization;

namespace PassengerTracker.Model
{
    /// <summary>
    /// Пассажир рейса самолёта
    /// </summary>
    [DataContract]
    [Serializable]
    public class Passenger
    {
        /// <summary>
        /// Имя пассажира
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Фамилия пассажира
        /// </summary>
        [DataMember]
        public string Surname { get; set; }

        /// <summary>
        /// Отчество пассажира
        /// </summary>
        [DataMember]
        public string Patronymic { get; set; }

        /// <summary>
        /// Рейс пассажира
        /// </summary>
        [DataMember]
        public Flight AssignedFlight { get; set; }

        /// <summary>
        /// Конструктор класса Пассажир авиарейса
        /// </summary>
        /// <param name="name">Имя пассажира</param>
        /// <param name="surname">Фамилия пассажира</param>
        /// <param name="patronymic">Отчество пассажира</param>
        /// <param name="assignedFlight">Рейс, на который зарегистрирован пассажир</param>
        public Passenger(string name, string surname, string patronymic, Flight assignedFlight)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            AssignedFlight = assignedFlight;
        }

        /// <summary>
        /// Конструктор для сериализации
        /// </summary>
        public Passenger() { }
    }
}