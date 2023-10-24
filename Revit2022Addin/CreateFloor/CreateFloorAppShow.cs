using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace Revit2022Addin.CreateFloor
{
    public static class CreateFloorAppShow
    {
        public static CreateFloorWpf formCreateFloors;
        public static double Xmin = 0;
        public static double Ymin = 0;
        public static double Xmax = 0;
        public static double Ymax = 0;
        public static List<RoomInformation> ListRoomInformation= new List<RoomInformation>();

        public static void ShowForm()
        {
            try { formCreateFloors.Close(); } catch { }
            CreateFloorHandler createFloorHandler= new CreateFloorHandler();
            ExternalEvent createFloorEvent= ExternalEvent.Create(createFloorHandler);
            formCreateFloors = new CreateFloorWpf(createFloorEvent);
            formCreateFloors.Show();
        }
    }
}
