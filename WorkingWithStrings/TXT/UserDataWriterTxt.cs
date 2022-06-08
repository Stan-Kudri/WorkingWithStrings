using WorkingWithStrings.Interface;

namespace WorkingWithStrings.TXT
{
    public class UserDataWriterTxt : IUserDataWriter
    {
        private readonly string _pathFile;

        public UserDataWriterTxt(string path)
        {
            _pathFile = path;
        }

        public void WriteMail(List<UserData> line)
        {
            if (line.Count() == 0)
                throw new ArgumentException("Пустой список!");

            File.WriteAllText(_pathFile, string.Empty);
            File.WriteAllLines(_pathFile, line.Select(x => x.Email).ToArray());
        }

        public void WriteAllData(List<string> data) => File.WriteAllLines(_pathFile, data);
    }
}
