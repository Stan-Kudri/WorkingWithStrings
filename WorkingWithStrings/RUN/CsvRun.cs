using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using WorkingWithStrings.Interface;

namespace WorkingWithStrings.RUN
{
    public class CsvRun : IRun
    {
        public void Run(string path, List<string> date)
        {
            var csvDate = new List<UserData>();
            foreach (var dateItem in date)
            {
                csvDate.Add(FromString(dateItem, "#"));
            }
            using (var file = new StreamWriter(path, false, System.Text.Encoding.UTF8))
            {
                var config = new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = "#", Encoding = System.Text.Encoding.UTF8 };
                using (var csv = new CsvWriter(file, config))
                {
                    csv.WriteRecords(csvDate);
                }
            }
        }

        private static UserData FromString(string data, string separator = ",")
        {
            var array = data.Split(separator);

            var dateStr = array[0];
            var mailStr = array[1].Replace(" ", "");

            return new UserData(dateStr, mailStr);
        }
    }
}
