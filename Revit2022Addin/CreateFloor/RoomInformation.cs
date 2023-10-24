using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Revit2022Addin.CreateFloor
{
    public class RoomInformation
    {
        public List<Line> ListLine { set; get; }

        public string NameRoom { set; get; }
        
        public XYZ LocationRoom { set; get; }
    }
}
