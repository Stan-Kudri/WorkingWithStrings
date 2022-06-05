using WorkingWithStrings.Interface;

namespace WorkingWithStrings.TXT
{
    public class UserDataWriterTxt : IFileToRecord
    {
        private readonly string _pathFileMail;

        public UserDataWriterTxt(string path)
        {
            _pathFileMail = path;
        }

        public void Write(List<UserData> line)
        {
            if (line.Count() == 0)
                throw new ArgumentException("Пустой список!");

            File.WriteAllText(_pathFileMail, string.Empty);
            File.WriteAllLines(_pathFileMail, line.Select(x => x.Email).ToArray());
        }
    }
}
