

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
writeCsv.WriteMail(dataCsv);
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

List<UserData> DateFileToRead(string path)
{
    var readCsv = new UserDataOperationFactory(pathCsv).CreateReader();
    return readCsv.SearchMailInFile();
}

void WriteFile(string path, List<UserData> data)
{
    var writeCsv = new UserDataOperationFactory(path).CreateWriter();
    writeCsv.WriteMail(data);
}

void Run(string path, List<string> data)
{
    var userData = new UserDataOperationFactory(path);

    userData.CreateWriter().WriteAllData(data);
}

