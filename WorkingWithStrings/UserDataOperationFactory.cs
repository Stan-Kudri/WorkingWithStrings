using WorkingWithStrings.Interface;
using WorkingWithStrings.TXT;

namespace WorkingWithStrings
{
    public class UserDataOperationFactory
    {
        private static readonly List<string> _type = new List<string> { ".csv", ".txt" };
        private readonly string _path;

        public UserDataOperationFactory(string path)
        {
            if (path == null)
                throw new ArgumentNullException("Пустая строка");
            if (!ValidFileTypes(path))
                throw new ArgumentException($"Типы файлов не верного формата.\nДоступные типы:  {string.Join(";   ", _type)}");
            _path = path;
        }

        public IUserDataWriter CreateWriter()
        {
            var type = Path.GetExtension(_path);

            if (type == ".csv")
                return new UserDataWriterCsv(_path);
            else
                return new UserDataWriterTxt(_path);
        }

        public IUserDataReader CreateReader()
        {
            var type = Path.GetExtension(_path);

            if (type == ".csv")
                return new UserDataReaderCsv(_path);
            else
                return new UserDataReaderTxt(_path);
        }

        private bool ValidFileTypes(string path)
        {
            var typeFile = Path.GetExtension(path);

            return _type.Any(x => x == typeFile);
        }
    }
}
