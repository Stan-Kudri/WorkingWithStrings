namespace WorkingWithStrings.Exception
{
    public class ExtensionException : IOException
    {
        public ExtensionException(string message)
        : base(message) { }
    }
}
