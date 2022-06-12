namespace WorkingWithStrings
{
    public class InvalidPathException : Exception
    {
        public InvalidPathException(string message)
        : base(message) { }
    }

    public class InvalidExtensionException : Exception
    {
        public InvalidExtensionException(string message)
        : base(message) { }
    }
}
