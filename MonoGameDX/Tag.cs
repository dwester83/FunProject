using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game_DX
{
    public class Tag
    {
        private enum Type
        {
            Trees,
            Grass
        }

        public int TagType { get; set; }

        public Tag(int tagType)
        {
            TagType = tagType;
        }
    }
}
