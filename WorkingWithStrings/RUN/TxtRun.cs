using WorkingWithStrings.Interface;

namespace WorkingWithStrings.RUN
{
    public class TxtRun : IRun
    {
        public void Run(string path, List<string> date)
        {
            var csvDate = new List<UserData>();
            foreach (var dateItem in date)
            {
                csvDate.Add(FromString(dateItem, "#"));
            }
            File.WriteAllLines(path, date);
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
