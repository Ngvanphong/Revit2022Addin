using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;

namespace Revit2022Addin.CreateFloor
{
    public static class CreateFloorAppShow
    {
        public static CreateFloorWpf formCreateFloors;
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
