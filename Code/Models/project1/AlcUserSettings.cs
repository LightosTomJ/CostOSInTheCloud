using System;
using System.Collections.Generic;

namespace Models.project1
{
    public partial class AlcUserSettings
    {
        public Guid UserId { get; set; }
        public Guid SettingId { get; set; }
        public byte[] Value { get; set; }
    }
}
