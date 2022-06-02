using CsvHelper;
using System.Globalization;

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
            using (var reader = File.OpenText(_path))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    while (csv.Read())
                    {
                        _mail.Add(csv.GetField<string>(1));
                    }
                }
            }

            return _mail;
        }
    }
}
