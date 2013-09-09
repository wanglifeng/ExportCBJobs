using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliCSSSDK.Models
{
    public abstract class BaseModel
    {
        public String id { get; set; }
        public String title { get; set; }
        public String body { get; set; }
        public string url { get; set; }
        public string author { get; set; }
        public string thumbnail { get; set; }
        public string source { get; set; }
        public int create_timestamp { get; set; }
        public int update_timestamp { get; set; }
        public int hit_num { get; set; }
        public int focus_count { get; set; }
        public int grade { get; set; }
        public int comment_count { get; set; }
        public byte boost { get; set; }
        public int integer_1 { get; set; }
        public int integer_2 { get; set; }
        public int integer_3 { get; set; }
        public String tag { get; set; }
        public String[] display_text { get; set; }
    }
}
