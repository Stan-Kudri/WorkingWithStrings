namespace WorkingWithStrings
{
    public class SearchMail
    {
        private readonly string _email;

        public string Email => _email;

        public SearchMail(string str)
        {
            var array = str.SkipWhile(x => x != '#').Skip(1).SkipWhile(x => x == ' ').ToArray();
            if (array != null && array.Count() > 0)
                _email = new string(array);
            else
                _email = string.Empty;
        }

        public override string ToString()
        {
            return _email;
        }
    }
}
