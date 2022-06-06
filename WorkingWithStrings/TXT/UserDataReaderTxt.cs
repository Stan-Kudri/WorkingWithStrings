using WorkingWithStrings.Interface;

namespace WorkingWithStrings.TXT
{
    public class UserDataReaderTxt : IUserDataReader
    {
        private readonly string _path;

        public UserDataReaderTxt(string path)
        {
            if (!File.Exists(path))
                throw new FieldAccessException("Нет файла!");
            _path = path;
        }

        public List<UserData> SearchMailInFile()
        {
            var data = new List<UserData>();

            foreach (string line in File.ReadLines(_path))
            {
                var serchMail = SearchMail(line);
                data.Add(serchMail);
            }

            return data;
        }

        private UserData SearchMail(string str)
        {
            var array = str.Split("#");

            var nameStr = array[0].Replace(" ", "");
            var mailStr = array[1].Replace(" ", "");


            if (mailStr != null && nameStr != null && mailStr.Count() > 0 && nameStr.Count() > 0)
                return new UserData(nameStr, mailStr);
            else
                return new UserData(string.Empty, string.Empty);
        }
    }
}
