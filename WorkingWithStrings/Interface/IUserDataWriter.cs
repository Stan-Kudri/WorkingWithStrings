namespace WorkingWithStrings.Interface
{
    public interface IUserDataWriter
    {
        public void WriteMail(List<UserData> line);

        public void WriteAllData(List<string> data);
    }
}
