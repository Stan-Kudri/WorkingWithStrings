using CsvHelper;
using System.Globalization;

namespace WorkingWithStrings
{
    public class MailFinder
    {
        private readonly string _path;

        public MailFinder(string path)
        {
            if (!File.Exists(path))
                throw new FieldAccessException("Нет файла!");
            _path = path;
        }

        public List<UserData> SearchMailInFile()
        {
            var mail = new List<UserData>();

            using (var reader = new StreamReader(_path))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    while (csv.Read())
                    {
                        mail.Add(new UserData(csv.GetField<string>(1)));
                    }
                }
            }

            return mail;
        }
    }
}
