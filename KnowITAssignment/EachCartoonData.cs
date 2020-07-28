using System;
using System.Collections.Generic;
using System.Text;

namespace KnowITAssignment
{
    public class EachCartoonData
    {
        public EachCartoonData()
        {
            EachCartoonStorage = new List<EachCartoon>();
        }
        public List<EachCartoon> EachCartoonStorage { get; set; }
    }
}
