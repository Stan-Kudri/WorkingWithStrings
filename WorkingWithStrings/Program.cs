

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
using WorkingWithStrings.RUN;
using WorkingWithStrings.TXT;

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

var csv = new CSV();
csv.CreateFileForProgram(pathCsv, list);
PrintFile(pathCsv);
Console.WriteLine();
RunCsv(pathCsv, pathMailCsv);
Console.WriteLine();

var txt = new TXT();
txt.CreateFileForProgram(pathTxt, list);
PrintFile(pathCsv);
Console.WriteLine();
RunTxt(pathTxt, pathMailTxt);
Console.WriteLine();






void RunCsv(string pathCsv, string pathMailCsv)
{
    var fileReaderCsv = new MailFinder(pathCsv);
    var mailsCsv = fileReaderCsv.SearchMailInFile();

    var fileWriteCsv = new FileLinesToRecord(pathMailCsv);
    fileWriteCsv.WriteLineToFile(mailsCsv);
    PrintFile(pathMailCsv);
}

void RunTxt(string pathTxt, string pathMailTxt)
{
    var fileReaderTxt = new MailFiderTxt(pathTxt);
    var mailsTxt = fileReaderTxt.SearchMailInFile();

    var fileWriteTxt = new FileLinesToRecordTxt(pathMailTxt);
    fileWriteTxt.WriteLineToFile(mailsTxt);
    PrintFile(pathMailTxt);
}

void PrintFile(string path)
{
    if (!File.Exists(path))
        throw new FileNotFoundException("Файла нет!");
    foreach (string line in File.ReadLines(path))
    {
        Console.WriteLine(line);
    }
}
