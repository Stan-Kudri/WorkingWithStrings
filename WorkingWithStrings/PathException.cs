namespace WorkingWithStrings
{
    public class PathException : Exception
    {
        public PathException(string message)
        : base(message) { }
    }

    public class StringNullException : Exception
    {
        public StringNullException(string message)
            : base(message) { }
    }
}
