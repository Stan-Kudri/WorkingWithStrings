namespace WorkingWithStrings
{
    public class ReadAndWriteFile
    {
        private readonly string _path;

        private string _pathFileMail;

        private List<string> _mail;

        public string PathFileMail => _pathFileMail;

        public ReadAndWriteFile(string path)
        {
            if (!File.Exists(path))
                throw new FieldAccessException("Нет файла!");
            _path = path;
            _pathFileMail = string.Empty;
            _mail = new List<string>();
        }

        public void ReadFile()
        {
            using (var readFile = new StreamReader(_path))
            {
                while (true)
                {
                    var line = readFile.ReadLine();

                    if (line == null)
                        break;

                    var serchMail = new SearchMail(line);

                    if (serchMail.Email != null)
                        _mail.Add(serchMail.Email);
                }
            }
        }

        public void WriteNewFile(string path)
        {
            if (path == _path && File.Exists(path))
                throw new FieldAccessException("Файл с таким путем есть!");
            if (_mail.Count() == 0)
                throw new ArgumentException("Пустой список!");
            _pathFileMail = path;
            File.WriteAllText(_pathFileMail, string.Empty);
            using (var writeFile = new StreamWriter(_pathFileMail, true))
            {
                foreach (var mail in _mail)
                    writeFile.WriteLine(mail);
            }
        }
    }
}
