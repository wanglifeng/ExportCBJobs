using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliCSSSDK.Models
{
    public class News : BaseModel
    {
        
        public short type_id { get; set; }
        public short[] cat_id { get; set; }
       
        
    }
}
