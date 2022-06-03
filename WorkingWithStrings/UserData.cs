namespace WorkingWithStrings
{
    public class UserData
    {
        public string FullName { get; set; }
        public string Email { get; set; }

        public UserData(string email)
        {
            Email = email;
            FullName = string.Empty;
        }

        public UserData(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }
    }
}
