using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game_DX
{
    public class Tag
    {
        public static int Trees = 1;
        public static int grass = 2;
        public int TagType { get; set; }

        public Tag(int tagType)
        {
            TagType = tagType;
        }
    }
}
