namespace Model.local
{
    public class ProjectAccessRuleTable
    {

        public long? id;
        public string title;
        public string accessCondition; // BOQ Item Access Condition
                                       // AT LEAST ONE MUST BE TRUE FOR THIS TO HAVE A POINT:
        public bool? allowAdd;
        public bool? allowUpdate;
        public bool? allowRemove;

        public ProjectUserTable userTable;

        public ProjectAccessRuleTable()
        { }
    }
}