using WorkingWithStrings.Interface;
using WorkingWithStrings.TXT;

namespace WorkingWithStrings
{
    public class UserDataOperationFactory
    {
        private readonly string _path;

        public UserDataOperationFactory(string path)
        {
            if (path == null)
                throw new ArgumentNullException("Пустая строка!");
            if (!ValidFileTypes(path))
                throw new FileLoadException("Типы файлов не верного формата!");
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

            throw new TypeAccessException("Несогласованность типа файла!");
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

            throw new TypeAccessException("Несогласованность типа файла!");
        }
        private bool ValidFileTypes(string path)
        {
            var type = new List<string> { ".csv", ".txt" };
            var typeFile = Path.GetExtension(path);

            if (type.Any(x => x == typeFile))
                return true;
            return false;
        }
    }
}
