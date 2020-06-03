using MyLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleInterface
{
    public struct SiteInfoContext
    {
        public  Site site { set; get; }
        public  User user { set; get; }
        public  Heading heading { set; get; }
    }
}
