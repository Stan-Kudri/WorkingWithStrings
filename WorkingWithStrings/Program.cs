

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

var pathMailCsv = "C:\\TestFileMail.csv";
var pathMailTxt = "C:\\TestFileMail.txt";

var pathTxt = "C:\\TestFile.txt";
var pathCsv = "C:\\TestFile.csv";

Run(pathCsv, pathMailCsv);
Run(pathTxt, pathMailTxt);



void PrintFile(string path)
{
    if (!File.Exists(path))
        throw new FileNotFoundException("Файла нет!");

    Console.WriteLine($"Вывод строк файла, по пути {path}");

    Console.WriteLine(string.Join("\n", File.ReadLines(path)) + "\n");
}


void Run(string path, string pathMail)
{
    if (!ValidFileTypes(path) && !ValidFileTypes(pathMail))
        throw new FileLoadException("Типы файлов не верного формата!");

    var data = new List<string>()
    {
    "Петров Петр Петрович # petr@mail.ru",
    "Широков Сергей Алексеевич # stan@mail.ru",
    "Сущевский Дмитрий Вячеславович # XanBaker@mail.ru",
    "Иванов Иван Иванович # iviviv@mail.ru"
    };


    var firstFileOperation = new UserDataOperationFactory(path);

    firstFileOperation.CreateWriter().WriteAllData(data);

    //Чтение файла и запись в переменную dataFile списка типа <UserData>.
    var readFile = firstFileOperation.CreateReader();
    var dataFile = readFile.SearchMailInFile();

    PrintFile(path);

    //Запись списка типа <UserData> в файл по пути  pathMailCsv и вывод на печать c этого файла.
    var secondFileOperationeFile = new UserDataOperationFactory(pathMail);
    var writeFile = secondFileOperationeFile.CreateWriter();
    writeFile.WriteMail(dataFile);

    PrintFile(pathMail);
}

bool ValidFileTypes(string path)
{
    var type = new List<string> { ".csv", ".txt" };
    var typeFile = Path.GetExtension(path);

    if (type.Any(x => x == typeFile))
        return true;
    return false;
}