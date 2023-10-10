using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;

namespace Revit2022Addin.CreateGrids
{
    [Transaction(TransactionMode.Manual)]
    public class CreateGridBinding : IExternalCommand

    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            CreateGridAppShow.ShowForm();
            return Result.Succeeded;
        }
    }
}
