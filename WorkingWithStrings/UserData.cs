using CsvHelper.Configuration.Attributes;

namespace WorkingWithStrings
{
    public class UserData
    {
        [Name("FullName")]
        public string FullName { get; set; }
        [Name("Email")]
        public string Email { get; set; }


        public UserData(string FullName, string Email)
        {
            this.FullName = FullName;
            this.Email = Email;
        }

        public override string ToString()
        {
            return $"{FullName}#{Email}";
        }
    }
}
