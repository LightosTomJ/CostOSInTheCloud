using System;

namespace Model.local
{
    [Serializable]
    public class MediaLibraryTable
    {
        public const int Image_Media_Type = 0;
        public const int Project_Design_Media_Type = 1;
        public string id { get; set; }
        public string name { get; set; }
        public int type { get; set; }
        public sbyte[] mediaBlob { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime updateDate { get; set; }
        public string userId { get; set; }

        public MediaLibraryTable()
        {
            //		type = Image_Media_Type;
        }
    }
}