using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace Revit2022Addin.CreateFloor
{
    public class CreateFloorHandler : IExternalEventHandler
    {
        void IExternalEventHandler.Execute(UIApplication app)
        {
            UIDocument uiDoc = app.ActiveUIDocument;
            Document doc= uiDoc.Document;


        }

        string IExternalEventHandler.GetName()
        {
            return "CreateFloorsHandler";
        }
    }
}
