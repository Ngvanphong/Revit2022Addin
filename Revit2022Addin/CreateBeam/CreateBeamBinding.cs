using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revit2022Addin.CreateBeam
{
    [Transaction(TransactionMode.Manual)]
    public class CreateBeamBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            CreateBeamAppShow.ShowForm();
            Document doc = commandData.Application.ActiveUIDocument.Document;
            ElementId idWall = null;
            Element element = doc.GetElement(idWall);
            Wall wall = (Wall)element;
            if(wall!=null) 
            {

            }

            

            var collectionBeamFamily = new FilteredElementCollector(doc)
                .OfClass(typeof(Family)).Cast<Family>().Where(x => x.FamilyCategory != null &&
                x.FamilyCategory.Id.IntegerValue == (int)BuiltInCategory.OST_StructuralFraming);

            
            CreateBeamAppShow.formCreateBeam.comboboxFamilyBeam.ItemsSource= collectionBeamFamily;
            return Result.Succeeded;
        }
    }
}
