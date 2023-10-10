using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;

namespace Revit2022Addin.CreateGrids
{
    public static class CreateGridAppShow
    {
        public static CreateGridWpf formCreateGrid;
        public static void ShowForm()
        {
            try { formCreateGrid.Close(); } catch { }

            CreateGridHandler handler= new CreateGridHandler();
            ExternalEvent createGridEvent = ExternalEvent.Create(handler);
            formCreateGrid = new CreateGridWpf(createGridEvent);
            formCreateGrid.Show();

        }
    }
}
