using PassengerTracker.Model;
using System.Text;

namespace FilesGenerator
{
    /// <summary>
    /// Класс, сохраняющий данные о пассажирах в формате .txt
    /// </summary>
    public class TxtFileCreator : IFileCreator
    {
        public bool CreateFile(List<Passenger> passengers)
        {
            string fileName = "Passengers.txt";
            try
            {
                StreamWriter writer = new StreamWriter(fileName);
                StringBuilder builder = new StringBuilder(64);

                for (int i = 0; i < passengers.Count; i++)
                {
                    string line = GetLine(passengers[i], builder);
                    writer.WriteLine(line);
                }
                writer.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Сгенерировать строку с данными о пассажирах
        /// </summary>
        /// <param name="passenger">Данные о пассажире</param>
        /// <param name="builder"></param>
        /// <returns></returns>
        private string GetLine(Passenger passenger, StringBuilder builder)
        {
            builder.Append(passenger.Surname).Append(' ');
            builder.Append(passenger.Name).Append(' ');
            builder.Append(passenger.Patronymic).Append(' ');
            builder.Append(passenger.AssignedFlight.Number).Append(' ');
            builder.Append(passenger.AssignedFlight.DepartureTime).Append(' ');
            string output = builder.ToString();
            builder.Clear();
            return output;
        }
    }
}
