namespace WorkingWithStrings
{
    public class MailFinder
    {
        private readonly string _path;

        private List<string> _mail;

        public MailFinder(string path)
        {
            if (!File.Exists(path))
                throw new FieldAccessException("Нет файла!");
            _path = path;
            _mail = new List<string>();
        }

        public List<string> SearchMailInFile()
        {
            foreach (string line in File.ReadLines(_path))
            {
                var serchMail = SearchMail(line);
                _mail.Add(serchMail);
            }

            return _mail;
        }

        private string SearchMail(string str)
        {
            var array = str.Split("#");

            var mailStr = array[1].Replace(" ", "");

            if (mailStr != null && mailStr.Count() > 0)
                return new string(mailStr);
            else
                return string.Empty;
        }
    }
}
