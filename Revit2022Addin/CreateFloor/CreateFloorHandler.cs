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

            var floorType = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Floors).
                WhereElementIsElementType().Cast<FloorType>().First();

            using(Transaction t= new Transaction(doc, "CreateFloor"))
            {
                t.Start();
                foreach(var infoRoom in CreateFloorAppShow.ListRoomInformation)
                {
                    CurveLoop curveLoop= new CurveLoop();
                    foreach (var curve in infoRoom.ListLine) curveLoop.Append(curve);
                    Floor.Create(doc, new List<CurveLoop> { curveLoop }, floorType.Id,
                        doc.ActiveView.GenLevel.Id);
                }
                t.Commit();
            }



        }

        string IExternalEventHandler.GetName()
        {
            return "CreateFloorsHandler";
        }
    }
}
