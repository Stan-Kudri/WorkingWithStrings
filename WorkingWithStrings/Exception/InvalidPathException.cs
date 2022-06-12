namespace WorkingWithStrings
{
    public class InvalidPathException : IOException
    {
        public InvalidPathException(string message)
        : base(message) { }
    }
}
