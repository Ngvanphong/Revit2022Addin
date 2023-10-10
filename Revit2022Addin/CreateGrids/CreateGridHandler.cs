using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace Revit2022Addin.CreateGrids
{
    public class CreateGridHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            string txtX = CreateGridAppShow.formCreateGrid.txtAxisX.Text;
            string txtY = CreateGridAppShow.formCreateGrid.txtAxisY.Text;

            string[] listTxtX = txtX.Split('+');
            string[] listTxtY= txtY.Split('+');

            List<double> listLengthX= new List<double>();
            List<int>  listNumberX = new List<int>();
            List<double> listLengthY = new List<double>();
            List<int> listNumberY = new List<int>();

            double totalLengthX = 0;
            foreach (var item in listTxtX)
            {
                string[] stringItems = item.Split('x');
                double length = double.Parse(stringItems[0])/304.8;
                int count= int.Parse(stringItems[1]);
                totalLengthX += length * count;
                listLengthX.Add(length);
                listNumberX.Add(count);
            }

            double totalLengthY = 0;
            foreach (var item in listTxtY)
            {
                string[] stringItems = item.Split('x');
                double length = double.Parse(stringItems[0])/304.8;
                int count = int.Parse(stringItems[1]);
                totalLengthY += length * count;
                listLengthY.Add(length);
                listNumberY.Add(count);
            }

            XYZ pX = new XYZ(0, totalLengthY, 0);
            XYZ pY = new XYZ(totalLengthX, 0, 0);
            using(Transaction tx= new Transaction(doc, "CreateGridX"))
            {
                tx.Start();
                Grid.Create(doc, Line.CreateBound(XYZ.Zero, pX));
                double totalLengthItem = 0;
                for (int i = 0; i < listLengthX.Count; i++)
                {
                    for(int j= 1;j<= listNumberX[i];j++)
                    {
                        totalLengthItem += listLengthX[i];
                        XYZ p1 = new XYZ(totalLengthItem, 0, 0);
                        XYZ p2 = new XYZ(totalLengthItem, totalLengthY, 0);
                        Grid.Create(doc,Line.CreateBound(p1, p2));

                    }
                }



                Grid.Create(doc, Line.CreateBound(XYZ.Zero, pY));
                double totalLengthItemY = 0;
                for (int i = 0; i < listLengthY.Count; i++)
                {
                    for (int j = 1; j <= listNumberY[i]; j++)
                    {
                        totalLengthItemY += listLengthY[i];
                        XYZ p1 = new XYZ(0, totalLengthItemY, 0);
                        XYZ p2 = new XYZ(totalLengthX, totalLengthItemY, 0);
                        Grid.Create(doc, Line.CreateBound(p1, p2));

                    }
                }
                tx.Commit();
            }
           





        }

        public string GetName()
        {
            return "CreateGridHandler";
        }
    }
}
