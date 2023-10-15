using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revit2022Addin.CreateBeam
{
    public static class CreateBeamAppShow
    {
        public static CreateBeamWpf formCreateBeam;
        public static void ShowForm()
        {
            var handler = new CreateBeamHandler();
            ExternalEvent createBeamEvent = ExternalEvent.Create(handler);

            var handlerGetType = new GetTypeFamilyHandler();
            ExternalEvent getTypeEvent = ExternalEvent.Create(handlerGetType);

            formCreateBeam = new CreateBeamWpf(createBeamEvent, getTypeEvent);
            formCreateBeam.Show();  
        }
    }
}
