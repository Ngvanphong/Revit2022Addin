using Autodesk.Revit.UI;
using Revit2022Addin.Button;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revit2022Addin
{
    internal class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {
            new CreateGridButton().CreateGrid(a);
            new CreateBeamButton().CreateBeam(a);
            new CreateFloorButton().CreateFloor(a); 
            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }
    }
}
