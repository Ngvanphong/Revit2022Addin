using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revit2022Addin.CreateColumn
{
    public static class CreateColumnAppShow
    {
        public static CreateColumnWpf formCreateColumn;
        public static void ShowForm()
        {
            try { formCreateColumn.Close(); } catch { }

            CreateColumnHanlder createColumnHanlder = new CreateColumnHanlder();
            ExternalEvent createColumnEvent= ExternalEvent.Create(createColumnHanlder);


            formCreateColumn= new CreateColumnWpf(createColumnEvent);
            formCreateColumn.Show();
        }
    }
}
