using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revit2022Addin.CreateColumn
{
    [Transaction(TransactionMode.Manual)]
    public class CreaateColumnBinding : IExternalCommand
    {
        Result IExternalCommand.Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;
            CreateColumnAppShow.ShowForm();
            var typeColumns = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_StructuralColumns).
                WhereElementIsElementType().Cast<FamilySymbol>().ToList();

           CreateColumnAppShow.formCreateColumn.comboboxColumnType.ItemsSource= typeColumns;

            var levels= new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Levels).
                WhereElementIsNotElementType().Cast<Level>().ToList();

            CreateColumnAppShow.formCreateColumn.comboboxBottomLevel.ItemsSource= levels;
            


            return Result.Succeeded;
        }
    }
}
