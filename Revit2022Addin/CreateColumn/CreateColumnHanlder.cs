using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revit2022Addin.CreateColumn
{
    public class CreateColumnHanlder : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            var typeColumn = CreateColumnAppShow.formCreateColumn
                .comboboxColumnType.SelectedItem as FamilySymbol;
            var level = CreateColumnAppShow.formCreateColumn.comboboxBottomLevel.SelectedItem as Level;

            using(Transaction t= new Transaction(doc, "CreateColumn"))
            {
                t.Start();
                var column = doc.Create.NewFamilyInstance(new XYZ(0, 0, 0), typeColumn, level,
                    Autodesk.Revit.DB.Structure.StructuralType.Column);
                column.get_Parameter(BuiltInParameter.FAMILY_TOP_LEVEL_PARAM).Set(level.Id);
                column.get_Parameter(BuiltInParameter.SLANTED_COLUMN_TYPE_PARAM).Set(1);
                column.get_Parameter(BuiltInParameter.FAMILY_TOP_LEVEL_OFFSET_PARAM).Set(1500/304.8);

                Parameter para = column.LookupParameter("TenCuaParameter");
                string value = para.AsString();
                double value2 = para.AsDouble();
                para.Set("stringng");
                para.Set(1500 / 304.8);

                IList<Parameter> paras = column.GetParameters("TenCuaParameter");

                t.Commit();
            }

        }

        public string GetName()
        {
            return "CreateColumnHandler";
        }
    }
}
