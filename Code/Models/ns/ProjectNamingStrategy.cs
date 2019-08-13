namespace Models.ns
{
    public class ProjectNamingStrategy
    {
        public string prefix { get; set; }
        //	public ProjectServerDBUtil projectServerDBUtil { get; set; }

        public ProjectNamingStrategy()
        { }

        public ProjectNamingStrategy(string prefix)
        {
            this.prefix = prefix;
        }
    }
}