namespace WorkingWithStrings.TXT
{
    public class MailFiderTxt
    {
        private readonly string _path;

        public MailFiderTxt(string path)
        {
            if (!File.Exists(path))
                throw new FieldAccessException("Нет файла!");
            _path = path;
        }

        public List<string> SearchMailInFile()
        {
            var mail = new List<string>();

            foreach (string line in File.ReadLines(_path))
            {
                var serchMail = SearchMail(line);
                mail.Add(serchMail);
            }

            return mail;
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
