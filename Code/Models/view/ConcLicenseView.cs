namespace Models.view
{
    public class ConcLicenseView
    {
        public long? id { get; set; }
        public string computerId { get; set; }
        public string userId { get; set; }
        public string lastLoginDate { get; set; }
        public string plugins { get; set; }
        public string email { get; set; }
        public string fullName { get; set; }

        public ConcLicenseView()
        { }
    }
}