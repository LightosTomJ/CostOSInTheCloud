using System;
using System.Collections.Generic;

namespace Models.projects
{
    [Serializable]
    public class ProjectTemplateTable
    {
        public long? id;
        public long? databaseId;
        public long? databaseCreateDate;
        public string title;
        public string editorId;
        public string userId;
        public DateTime lastUpdate;
        public DateTime createDate;
        public string createUserId;
        public bool? pblk;
        public bool? hasBuildUps;
        public bool? hasDistributors;
        public bool? allowForViewers;
        public string description;
        public bool? selected = false;
        public ISet<ProjectVariableTable> variableSet;
        public ISet<RateBuildUpTable> rateBuildUpSet;
        public ISet<RateBuildUpColumnsTable> rateBuildUpColumnsSet;
        public ISet<RateDistributorTable> rateDistributorSet;
        public ProjectExcelFile excelFile;
        public string templateUsersAndRoles;

        public ProjectTemplateTable()
        { }
    }
}