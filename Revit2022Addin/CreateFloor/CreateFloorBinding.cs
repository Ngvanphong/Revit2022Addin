using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revit2022Addin.CreateFloor
{
    [Transaction(TransactionMode.Manual)]
    public class CreateFloorBinding : IExternalCommand
    {
        Result IExternalCommand.Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc= uiDoc.Document;

            CreateFloorAppShow.ShowForm();

            var allRoom = new FilteredElementCollector(doc, doc.ActiveView.Id)
                .OfCategory(BuiltInCategory.OST_Rooms).WhereElementIsNotElementType().Cast<Room>().ToList();

            SpatialElementBoundaryOptions optionRoom= new SpatialElementBoundaryOptions();
            optionRoom.SpatialElementBoundaryLocation = SpatialElementBoundaryLocation.Finish;
            
            
            List<List<Line>> listLineRoomsCavas= new List<List<Line>>();
            List<List<Curve>> listCurveRooms = new List<List<Curve>>();

            foreach ( var room in allRoom )
            {
                if (room.Area > 0)
                {
                    var roomSegments = room.GetBoundarySegments(optionRoom);
                    IList<BoundarySegment> boundarySegmentMaxs = new List<BoundarySegment>();
                    // Tim max boundary
                    double lengthMax = 0;
                    foreach(var segementItems in roomSegments )
                    {
                        double lengthItem = 0;
                        foreach (var item in segementItems) lengthItem += item.GetCurve().Length;
                        if(lengthItem > lengthMax) 
                        {
                            lengthMax = lengthItem;
                            boundarySegmentMaxs = segementItems;
                        }
                    }
                    List<Curve> listCurve = new List<Curve>();
                    List<Line> listLine = new List<Line>();
                    foreach(var cureSeg in boundarySegmentMaxs )
                    {
                        Curve curve= cureSeg.GetCurve();
                        listCurve.Add( curve );
                        Line line = curve as Line;
                        if (line != null) listLine.Add(line );
                        
                    }
                    listCurveRooms.Add( listCurve );
                    listLineRoomsCavas.Add( listLine );

                }
            }

            double xMin = 100000000000;
            double yMin = 100000000000;
            double xMax = -100000000000;
            double yMax = -100000000000;
            foreach (var listLine in listLineRoomsCavas)
            {
                foreach (Line line in listLine)
                {
                    double x1 = line.GetEndPoint(0).X;
                    double x2= line.GetEndPoint(1).X;
                    double y1 = line.GetEndPoint(0).Y;
                    double y2 = line.GetEndPoint(1).Y;

                    double minX= Math.Min(x1, x2);
                    xMin= Math.Min(minX, xMin);
                    double minY = Math.Min(y1, y2);
                    yMin = Math.Min(yMin, minY);

                    double maxX = Math.Max(x1, x2);
                    xMax = Math.Max(xMax, maxX);
                    double maxY = Math.Max(y1, y2);
                    yMax = Math.Max(yMax, maxY);

                }
            }

            double xMidRe = (xMin + xMax) / 2; // diem giua revit
            double yMidRe= (yMin + yMax) / 2;//
            double widthRe = (xMax - xMin);
            


            foreach (var listLine in listLineRoomsCavas)
            {
                foreach(Line line in listLine )
                {
                    CanvasUnitilies.CreateLine(line, CreateFloorAppShow.formCreateFloors.canvasFloor,xMidRe,yMidRe, widthRe);
                }
            }



            return Result.Succeeded;
        }
    }
}
