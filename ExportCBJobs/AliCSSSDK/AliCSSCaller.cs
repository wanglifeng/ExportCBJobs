using AliCSSSDK.Callers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliCSSSDK
{
    public class AliCSSCaller
    {
        private const String CLIENT_ID = "6100428794848982";
        private const String CLIENT_SECRET = "04b10a740bb0cef1373ac9ff837eab49";

        private readonly AliCSSClient CLIENT;

        public AliCSSCaller()
        {
            CLIENT = new AliCSSClient(CLIENT_ID, CLIENT_SECRET);
        }
        public Index Index
        {
            get
            {
                return new Index(CLIENT);
            }
        }

        public Doc Doc
        {
            get
            {
                return new Doc(CLIENT);
            }
        }

        public Search Search
        {
            get
            {
                return new Search(CLIENT);
            }
        }

       
    }
}
