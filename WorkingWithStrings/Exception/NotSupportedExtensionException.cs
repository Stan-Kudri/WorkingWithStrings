namespace WorkingWithStrings.Exception
{
    public class NotSupportedExtensionException : IOException
    {
        public NotSupportedExtensionException(string message)
        : base(message) { }
    }
}
