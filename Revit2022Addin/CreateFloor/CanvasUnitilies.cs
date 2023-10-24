
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
        public static void CreateLine(double x1,double y1, double x2, double y2,Canvas canvas,double scale)
        {
            Line lineCavas= new Line();
            lineCavas.X1 = x1;
            lineCavas.Y1 = y1;
            lineCavas.X2 = x2;
            lineCavas.Y2 = y2;
            lineCavas.Stroke = new SolidColorBrush(Colors.Green);
            lineCavas.StrokeThickness = 2 / scale;
            lineCavas.Visibility= System.Windows.Visibility.Visible;
            canvas.Children.Add(lineCavas);

        }

        public static void CreateText(double x1, double y1, string nameRoom, Canvas canvas,double scale)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = nameRoom;
            textBlock.Foreground = new SolidColorBrush(Colors.Red);
            textBlock.FontSize = 13 / scale;

            Canvas.SetTop(textBlock, y1);
            Canvas.SetLeft(textBlock, x1);
            canvas.Children.Add(textBlock);
        }

       
    }
}
