
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls; // line chinh
using System.Windows.Media;
using System.Windows.Shapes;
using DB = Autodesk.Revit.DB; // line revit


namespace Revit2022Addin.CreateFloor
{
    public class CanvasUnitilies
    {
        public static void CreateLine(DB.Line lineRevit,Canvas canvas,
           double xMidRe, double yMidRe,double widthRe)
        {
            Line lineCavas= new Line();
            lineCavas.X1 = lineRevit.GetEndPoint(0).X * 304.8 * 3.77  + xMidRe * 304.8 * 3.77;
            lineCavas.Y1 = -lineRevit.GetEndPoint(0).Y * 304.8 * 3.77 + yMidRe * 304.8 * 3.77 +   40;
            lineCavas.X2 = lineRevit.GetEndPoint(1).X * 304.8 * 3.77 + xMidRe * 304.8 * 3.77;
            lineCavas.Y2 = -lineRevit.GetEndPoint(1).Y * 304.8 * 3.77 + yMidRe * 304.8 * 3.77 +    40;

            lineCavas.Stroke = new SolidColorBrush(Colors.Green);
            lineCavas.StrokeThickness = 2;
            lineCavas.Visibility= System.Windows.Visibility.Visible;
          
            
            canvas.Children.Add(lineCavas);

        }

        public double GetZoom(double x, double y,double xMid, double yMid,double widthCavas, double heightCanvas,double widthRe)
        {
            DB.XYZ vectorMove = DB.XYZ.Zero - new DB.XYZ(xMid, yMid, 0);
            double xToMid = (new DB.XYZ(x, y, 0) + vectorMove).X;
            double yToMid = (new DB.XYZ(x, y, 0) + vectorMove).Y;

            double sclale = widthCavas / widthRe;






        }
    }
}
