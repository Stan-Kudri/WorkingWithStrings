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
    }
}
