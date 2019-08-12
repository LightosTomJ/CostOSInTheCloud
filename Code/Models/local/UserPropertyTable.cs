namespace Model.local
{
    public class UserPropertyTable
    {
        public long? id { get; set; }
        public string userId { get; set; }
        public string propKey { get; set; }
        public string propValue { get; set; }

        public UserPropertyTable()
        { }
    }
}