namespace WorkingWithStrings
{
    public class FinderMail
    {
        private readonly string _path;

        private List<string> _mail;

        public FinderMail(string path)
        {
            if (!File.Exists(path))
                throw new FieldAccessException("Нет файла!");
            _path = path;
            _mail = new List<string>();
        }

        public List<string> SearchMailInFile()
        {
            using (var readFile = new StreamReader(_path))
            {
                while (true)
                {
                    var line = readFile.ReadLine();

                    if (line == null)
                        break;

                    var serchMail = SearchMail(line);

                    if (serchMail != null)
                        _mail.Add(serchMail);
                }
            }
            return _mail;
        }

        private string SearchMail(string str)
        {
            var array = str.SkipWhile(x => x != '#').Skip(1).SkipWhile(x => x == ' ').ToArray();
            if (array != null && array.Count() > 0)
                return new string(array);
            else
                return string.Empty;
        }
    }
}
