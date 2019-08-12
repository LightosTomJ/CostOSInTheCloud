using System;

namespace Model.view.data
{

	using ResizableCloneableIcon = nomitech.common.ui.ResizableCloneableIcon;


	public class ProjectData
	{

		private string name;
		private string url;
		private DateTime submissionDate;
		private string type;
		private ResizableCloneableIcon icon;


		public ProjectData(string url, string name, DateTime submissionDate, string type, ResizableCloneableIcon icon) : base()
		{
			this.name = name;
			this.url = url;
			this.submissionDate = submissionDate;
			this.type = type;
			this.icon = icon;
		}
		public virtual string Name
		{
			get
			{
				return name;
			}
			set
			{
				this.name = value;
			}
		}
		public virtual DateTime SubmissionDate
		{
			get
			{
				return submissionDate;
			}
			set
			{
				this.submissionDate = value;
			}
		}
		public virtual string Type
		{
			get
			{
				return type;
			}
			set
			{
				this.type = value;
			}
		}
		public virtual ResizableCloneableIcon Icon
		{
			get
			{
				return icon;
			}
			set
			{
				this.icon = value;
			}
		}
		public virtual string Url
		{
			get
			{
				return url;
			}
			set
			{
				this.url = value;
			}
		}
	}

}