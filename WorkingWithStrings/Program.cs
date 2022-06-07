

/*
 * Работа со строками.
 * Дан текстовый файл,содержащий ФИО и e-mail адрес.
 * Разделителем между ФИО и адресом электронной почты является символ #: 
 * Иванов Иван Иванович # iviviv@mail.ru
 * Петров Петр Петрович # petr@mail.ru
 * Сформировать новый файл, содержащий список адресов электронной почты.
 * Предусмотреть метод, выделяющий из строки адрес почты.
 * Методу в качестве параметра передается символьная строка s,
 * e-mail возвращается в той же строке s:public string SearchMail (string s)*/
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using WorkingWithStrings;

var list = new List<string>()
{
    "Петров Петр Петрович # petr@mail.ru",
    "Широков Сергей Алексеевич # stan@mail.ru",
    "Сущевский Дмитрий Вячеславович # XanBaker@mail.ru",
    "Иванов Иван Иванович # iviviv@mail.ru"
};

var pathCsv = "C:\\TestFile.csv";
var pathMailCsv = "C:\\TestFileMail.csv";

var pathTxt = "C:\\TestFile.txt";
var pathMailTxt = "C:\\TestFileMail.txt";

Run(pathCsv, list);
PrintFile(pathCsv);

Run(pathTxt, list);
PrintFile(pathTxt);

//Чтение файла Csv и запись в переменную dataCsv списка типа <UserData>.
var readCsv = new UserDataOperationFactory(pathCsv).CreateReader();
var dataCsv = readCsv.SearchMailInFile();

//Запись списка типа <UserData> в файл по пути  pathMailCsv и вывод на печать c этого файла.  
var writeCsv = new UserDataOperationFactory(pathMailCsv).CreateWriter();
writeCsv.Write(dataCsv);
PrintFile(pathMailCsv);

//Чтение файла Csv и запись в переменную dataTxt списка типа <UserData> с помощью метода.
var data = DateFileToRead(pathTxt);
//Запись списка типа <UserData> в файл по пути pathMailTxt.
WriteFile(pathMailTxt, data);
//Печать файла по пути pathMailCsv.
PrintFile(pathMailTxt);


void PrintFile(string path)
{
    if (!File.Exists(path))
        throw new FileNotFoundException("Файла нет!");

    Console.WriteLine($"Вывод строк файла, по пути {path}");

    Console.WriteLine(string.Join("\n", File.ReadLines(path)) + "\n");
}

void Run(string path, List<string> data)
{
    var type = Path.GetExtension(path);

    switch (type)
    {
        case ".csv":
            var userData = new List<UserData>(ListConversion(data));

            using (var file = new StreamWriter(path, false, System.Text.Encoding.UTF8))
            {
                var config = new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = "#", Encoding = System.Text.Encoding.UTF8 };
                using (var csv = new CsvWriter(file, config))
                {
                    csv.WriteRecords(userData);
                }
            }
            return;

        case ".txt":
            File.WriteAllLines(path, data);
            return;
    }

    throw new TypeAccessException("Несогласованность типа файла!");
}

List<UserData> ListConversion(List<string> data)
{
    var userData = new List<UserData>();

    foreach (var dateItem in data)
    {
        userData.Add(FromString(dateItem, "#"));
    }
    return userData;
}

static UserData FromString(string data, string separator = ",")
{
    var array = data.Split(separator);

    var dateStr = array[0];
    var mailStr = array[1].Replace(" ", "");

    return new UserData(dateStr, mailStr);
}

List<UserData> DateFileToRead(string path)
{
    var readCsv = new UserDataOperationFactory(pathCsv).CreateReader();
    return readCsv.SearchMailInFile();
}

void WriteFile(string path, List<UserData> data)
{
    var writeCsv = new UserDataOperationFactory(path).CreateWriter();
    writeCsv.Write(data);
}
