using PassengerTracker.Model;

namespace FilesGenerator
{
    /// <summary>
    /// Генератор случайных пассажиров
    /// </summary>
    public abstract class PassengerGenerator
    {
        /// <summary>
        /// Генератор случайных чисел
        /// </summary>
        protected Random _random;

        /// <summary>
        /// Набор возможных имён пассажиров
        /// </summary>
        protected string[] NamesDataSet;

        /// <summary>
        /// Набор возможных фамилий пассажиров
        /// </summary>
        protected string[] SurnamesDataSet;

        /// <summary>
        /// Набор возможных отчеств пассажиров
        /// </summary>
        protected string[] PatronymicDataSet;

        public PassengerGenerator()
        {
            _random = new Random();
            DeclareNames();
            DeclareSurnames();
            DeclarePatronymics();
        }

        /// <summary>
        /// Создать набор возможных имён
        /// </summary>
        protected abstract void DeclareNames();

        /// <summary>
        /// Создать набор возможных фамилий
        /// </summary>
        protected virtual void DeclareSurnames()
        {
            SurnamesDataSet = new string[]
            {
                "Богданов",
                "Васильев",
                "Виноградов",
                "Волков",
                "Голубев",
                "Зайцев",
                "Иванов",
                "Козлов",
                "Кузнецов",
                "Лебедев",
                "Михайлов",
                "Морозов",
                "Новиков",
                "Орлов",
                "Петров",
                "Попов",
                "Соловьёв",
                "Соколов",
                "Смиронов",
                "Фёдоров"
            };
        }

        /// <summary>
        /// Создать набор возможных отчеств
        /// </summary>
        protected virtual void DeclarePatronymics()
        {
            PatronymicDataSet = new string[]
            {
                "Александров",
                "Андреев",
                "Алексеев",
                "Антонов",
                "Артёмов",
                "Борисов",
                "Валериев",
                "Викторов",
                "Генадиев",
                "Дмитриев",
                "Иванов",
                "Николаев",
                "Константинов",
                "Павлов",
                "Петров",
                "Романов",
                "Русланов",
                "Сергеев",
                "Станиславов",
                "Ярославов"
            };
        }

        /// <summary>
        /// Сгененрировать случайного пассажира на конкретный рейс
        /// </summary>
        /// <param name="flight">Рейс, на который регистрируются все пассажиры</param>
        /// <returns></returns>
        public Passenger GeneratePassenger(Flight flight)
        {
            int nameId = _random.Next(0, NamesDataSet.Length);
            int surnameId = _random.Next(0, SurnamesDataSet.Length);
            int patronymicId = _random.Next(0, PatronymicDataSet.Length);

            string name = NamesDataSet[nameId];
            string surname = SurnamesDataSet[surnameId];
            string patronymic = PatronymicDataSet[patronymicId];

            return new Passenger(name, surname, patronymic, flight);
        }
    }
}
