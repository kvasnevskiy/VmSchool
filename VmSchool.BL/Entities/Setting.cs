using System;
using System.Collections.Generic;
using System.Text;

namespace VmSchool.BL.Entities
{
    public class Setting
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
