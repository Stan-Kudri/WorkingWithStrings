﻿

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

Console.WriteLine("Hello, World!");



var str = "Петров Петр Петрович # petr@mail.ru";
var mail = new SearchMail(str);
Console.WriteLine(mail);

var list = new List<string>()
{
    "Петров Петр Петрович # petr@mail.ru",
    "Широков Сергей Алексеевич # stan@mail.ru",
    "Сущевский Дмитрий Вячеславович # XanBaker@mail.ru",
    "Иванов Иван Иванович # iviviv@mail.ru"
};
var path = "C:\\TestFile.txt";
CreateFileForProgram(path, list);

StreamFileLine(path);

var pathMail = "C:\\TestFileMail.txt";

var fileReader = new ReadAndWriteFile(path);
fileReader.ReadFile();
fileReader.WriteNewFile(pathMail);

StreamFileLine(fileReader.PathFileMail);

void CreateFileForProgram(string path, List<string> date)
{
    if (!File.Exists(path))
        File.Create(path);
    else
        File.WriteAllText(path, string.Empty);

    using (var file = new StreamWriter(path))
    {
        foreach (var item in date)
            file.WriteLine(item);
    }
}

void StreamFileLine(string path)
{
    if (!File.Exists(path))
        throw new FileNotFoundException("Файла нет!");
    using (var file = new StreamReader(path, true))
    {
        while (true)
        {
            var line = file.ReadLine();
            if (line == null)
                break;
            Console.WriteLine(line);
        }
    }
}