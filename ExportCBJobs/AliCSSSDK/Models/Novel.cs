using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliCSSSDK.Models
{
    public class Novel : BaseModel
    {
        public Novel() : base() { }

        public string isbn { get; set; }
        public uint group_id { get; set; }
        public string type { get; set; }
        public string cat { get; set; }
        public string style { get; set; }
        public string era { get; set; }
        public byte vip { get; set; }
        public string character { get; set; }
        public string press { get; set; }
        public float price { get; set; }
        public byte finish { get; set; }
        public uint recommend_count { get; set; }
        public uint subscribe_count { get; set; }
        public uint word_count { get; set; }
    }
}
