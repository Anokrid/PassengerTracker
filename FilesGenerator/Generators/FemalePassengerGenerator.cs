namespace FilesGenerator
{
    /// <summary>
    /// Генератор пассажиров женского пола
    /// </summary>
    public class FemalePassengerGenerator : PassengerGenerator
    {
        protected override void DeclareNames()
        {
            NamesDataSet = new string[]
            {
                "Алиса",
                "Анастасия",
                "Анжела",
                "Виктория",
                "Валерия",
                "Галина",
                "Дарья",
                "Евгения",
                "Екатерина",
                "Зинаида",
                "Маргарита",
                "Мария",
                "Любовь",
                "Людмила",
                "Наталья",
                "Надежда",
                "Ольга",
                "Полина",
                "Татьяна",
                "Светлана",
                "Юлия"
            };
        }

        protected override void DeclareSurnames()
        {
            base.DeclareSurnames();
            for (int i = 0; i < SurnamesDataSet.Length; i++)
            {
                SurnamesDataSet[i] += "а";
            }
        }

        protected override void DeclarePatronymics()
        {
            base.DeclarePatronymics();
            for (int i = 0; i < PatronymicDataSet.Length; i++)
            {
                PatronymicDataSet[i] += "на";
            }
        }
    }
}
