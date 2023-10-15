using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revit2022Addin.CreateBeam
{
    public class GetTypeFamilyHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            Family family = CreateBeamAppShow.formCreateBeam.comboboxFamilyBeam.SelectedItem as Family;
            var typeOfFamilyIds = family.GetFamilySymbolIds();
            Document doc = app.ActiveUIDocument.Document;
            List<FamilySymbol> symbols = new List<FamilySymbol>();
            foreach(var id in typeOfFamilyIds)
            {
                FamilySymbol symbol = doc.GetElement(id) as FamilySymbol;
                symbols.Add(symbol);
            }
            CreateBeamAppShow.formCreateBeam.comboboxTypeBeam.ItemsSource = symbols;

        }

        public string GetName()
        {
            return "GetTypeFamilyHandler";
        }
    }
}
