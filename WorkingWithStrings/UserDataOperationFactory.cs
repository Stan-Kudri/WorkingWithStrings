using WorkingWithStrings.Exception;
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

            switch (type)
            {
                case ".csv":
                    return new UserDataWriterCsv(_path);
                case ".txt":
                    return new UserDataWriterTxt(_path);
            }

            throw new NotSupportedExtensionException($"Доступные типы:  {string.Join("; ", _type)}");
        }

        public IUserDataReader CreateReader()
        {
            var type = Path.GetExtension(_path);

            switch (type)
            {
                case ".csv":
                    return new UserDataReaderCsv(_path);
                case ".txt":
                    return new UserDataReaderTxt(_path);
            }

            throw new NotSupportedExtensionException($"Доступные типы:  {string.Join("; ", _type)}");

        }

        private bool ValidFileTypes(string path)
        {
            var typeFile = Path.GetExtension(path);

            return _type.Any(x => x == typeFile);
        }
    }
}
