using CsvHelper;
using CsvHelper.Configuration;
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
                var config = new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = "#" };
                using (var csv = new CsvReader(reader, config))
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
