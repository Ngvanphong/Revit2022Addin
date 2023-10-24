using Autodesk.Revit.UI;
using Revit2022Addin.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Revit2022Addin.Button
{
    internal class CreateFloorButton
    {
        public void CreateFloor(UIControlledApplication application)
        {
            try
            {
                application.CreateRibbonTab(AppConstants.RibbonName1); // tao riboon neu ribbon da ton tai thi xuong ham catch
            }
            catch { }
            RibbonPanel panelArchitect = null;
            List<RibbonPanel> allPanelOfRevitAPI = application.GetRibbonPanels(AppConstants.RibbonName1); // de get toan bo panel cua ribbon
            foreach (RibbonPanel panelItem in allPanelOfRevitAPI) // kiem tra panel da ton tai hay chua
            {
                if (panelItem.Name == AppConstants.Panel1)
                {
                    panelArchitect = panelItem;
                    break;
                }
            }
            if (panelArchitect == null) // tao panel
            {
                panelArchitect = application.CreateRibbonPanel(AppConstants.RibbonName1, AppConstants.Panel1); // tao panel
            }

            ImageSource imageSource = Extension.GetImageSource(Resources.topo);
            PushButtonData testButton = new PushButtonData("CreateFloors", "Create \n Floors",
                Assembly.GetExecutingAssembly().Location, "Revit2022Addin.CreateFloor.CreateFloorBinding");
            testButton.ToolTip = "Create floors";
            testButton.LongDescription = "Create floors";
            testButton.Image = imageSource;
            testButton.LargeImage = imageSource;
            panelArchitect.AddItem(testButton).Enabled = true;
        }
    }
}
