
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace Revit2022Addin.CreateBeam
{
    public class CreateBeamHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            var allGrid = new FilteredElementCollector(doc, doc.ActiveView.Id).OfClass(typeof(Grid)).
                WhereElementIsNotElementType().Cast<Grid>().ToList();

            FamilySymbol familySymbol= CreateBeamAppShow.formCreateBeam.comboboxTypeBeam.SelectedItem as FamilySymbol;
            using(TransactionGroup tg= new TransactionGroup(doc, "CreateBeamgroup"))
            {
                tg.Start();
                foreach (var grid in allGrid)
                {
                    List<Grid> listGridCheck = new List<Grid>(allGrid);
                    listGridCheck.Remove(grid);
                    var curveGridMain = grid.GetCurvesInView(DatumExtentType.ViewSpecific, doc.ActiveView).First();
                    List<XYZ> listIntersectionPoint = new List<XYZ>();
                    foreach (var gridCheck in listGridCheck)
                    {
                        var curveGridCheck = gridCheck.GetCurvesInView(DatumExtentType.ViewSpecific, doc.ActiveView).First();
                        var intesection = curveGridMain.Intersect(curveGridCheck, out var listPoint);
                        if (listPoint != null && listPoint.Size > 0)
                        {
                            foreach (IntersectionResult intesec in listPoint) listIntersectionPoint.Add(intesec.XYZPoint);
                        }
                    }
                    listIntersectionPoint = listIntersectionPoint.OrderBy(x => Math.Round(x.X, 3))
                        .ThenBy(x => Math.Round(x.Y, 3)).ToList();

                    using(Transaction t = new Transaction(doc, "CreateBeam"))
                    {
                        t.Start();
                        if (!familySymbol.IsActive) familySymbol.Activate();
                        for(int i= 0; i<listIntersectionPoint.Count-1; i++)
                        {
                            Line line = Line.CreateBound(listIntersectionPoint[i], listIntersectionPoint[i + 1]);
                            var beam= doc.Create.NewFamilyInstance(line, familySymbol, 
                                doc.ActiveView.GenLevel, Autodesk.Revit.DB.Structure.StructuralType.Beam);

                        }
                        t.Commit();
                    }
                }
                tg.Assimilate();
            }
           



        }

        public string GetName()
        {
            return "CreateBeamsHandler";
        }
    }
}
