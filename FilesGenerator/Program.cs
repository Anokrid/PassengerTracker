// See https://aka.ms/new-console-template for more information
using FilesGenerator;
using PassengerTracker.Model;

Console.WriteLine("===== Генерация файла с информацией по пассажирам =====");
Console.WriteLine();

#region Уточнение количества генерируемых пассажиров
bool isInputValid;
int count;
do
{
    Console.Write("Укажите количество пассажиров: ");
    string input = Console.ReadLine();
    isInputValid = Int32.TryParse(input, out count);
}
while (!isInputValid || count <= 0);

#endregion

#region Уточнение формата файла, в который необходимо сохранить данные
Console.WriteLine("Укажите формат файла, в котором необходимо сохранить сгененированные данные.");
Console.WriteLine("Введите число, соответствующее нужному формату:");
var formats = FileFormatManager.GetAvailableFileFormats();
for (int i = 0; i < formats.Count; i++)
{
    Console.WriteLine("{0} - {1}", i + 1, formats[i].ToString());
}
int formatId;
do
{
    Console.Write("Выбранный формат файла: ");
    string input = Console.ReadLine();
    isInputValid = Int32.TryParse(input, out formatId);
}
while (!isInputValid || formatId <= 0 || formatId > formats.Count);
#endregion

#region Гененация списка пассажиров

var generator = new DataGenerator();
List<Passenger> passengers = generator.GeneratePassengers(count);

#endregion

#region Запись в файл

FileFormat format = formats[formatId - 1];
IFileCreator creator = FileCreatorFabric.GetCreator(format);
bool isSuccess = creator.CreateFile(passengers);

if (isSuccess)
{
    Console.WriteLine("Файл успешно записан!");
}
else
{
    Console.WriteLine("Попытка создать файл закончилась ошибкой!");
}

Console.Read();
#endregion
