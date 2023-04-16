namespace FilesGenerator
{
    /// <summary>
    /// Гененратор пассажиров мужского пола
    /// </summary>
    public class MalePassengerGenerator : PassengerGenerator
    {
        protected override void DeclareNames()
        {
            NamesDataSet = new string[]
            {
                "Александр",
                "Андрей",
                "Алексей",
                "Антон",
                "Артём",
                "Борис",
                "Валерий",
                "Виктор",
                "Генадий",
                "Дмитрий",
                "Иван",
                "Константин",
                "Николай",
                "Павел",
                "Пётр",
                "Роман",
                "Руслан",
                "Сергей",
                "Станислав",
                "Ярослав"
            };
        }

        protected override void DeclarePatronymics()
        {
            base.DeclarePatronymics();
            for (int i = 0; i < PatronymicDataSet.Length; i++)
            {
                PatronymicDataSet[i] += "ич";
            }
        }
    }
}
