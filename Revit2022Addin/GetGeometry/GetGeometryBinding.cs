using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revit2022Addin.GetGeometry
{
    [Transaction(TransactionMode.Manual)]
    public class GetGeometryBinding : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = uiDoc.Document;

            var selectedIds = uiDoc.Selection.GetElementIds();
            Element element = doc.GetElement(selectedIds.First());

            Options options = new Options();
            options.DetailLevel = doc.ActiveView.DetailLevel;
            options.IncludeNonVisibleObjects = false;
            options.ComputeReferences = true;

            GeometryElement geoEle = element.get_Geometry(options);
            List<Solid> listSolid = new List<Solid>();

            if(element is FamilyInstance)
            {
                GetGeometryFromFamily(doc, element as FamilyInstance, ref listSolid);
            }
            

            //foreach (GeometryObject geoObj in geoEle)
            //{
            //    Solid solid = geoObj as Solid;
            //    if (solid != null && solid.Volume>0.0000001)
            //    {
            //        listSolid.Add(solid);
            //    }
            //    else
            //    {
            //        GeometryInstance geoIstance = geoObj as GeometryInstance;
            //        if (geoIstance != null)
            //        {
            //            GetSolidGeoInstance(geoIstance, ref listSolid);
            //        }
            //    }
            //}

           



            return Result.Succeeded;
        }

        public void GetGeometryFromFamily(Document doc,FamilyInstance familyInstance, ref List<Solid> listSolid)
        {
            //Net suppper ==null thi moi co list phu thuoc
            Options options = new Options();
            options.DetailLevel = doc.ActiveView.DetailLevel;
            options.IncludeNonVisibleObjects = false;
            options.ComputeReferences = true;
            GeometryElement geoEle = familyInstance.get_Geometry(options);
            foreach (GeometryObject geoObj in geoEle)
            {
                Solid solid = geoObj as Solid;
                if (solid != null && solid.Volume > 0.0000001)
                {
                    listSolid.Add(solid);
                }
                else
                {
                    GeometryInstance geoIstance = geoObj as GeometryInstance;
                    if (geoIstance != null)
                    {
                        GetSolidGeoInstance(geoIstance, ref listSolid);
                    }
                }
            }
            if (familyInstance.SuperComponent == null) 
            {
                var subIds = familyInstance.GetSubComponentIds();
                foreach(var subId in subIds)
                {
                    Element subEle= doc.GetElement(subId);
                    FamilyInstance faSub = subEle as FamilyInstance;
                    GetGeometryFromFamily(doc, faSub, ref listSolid);
                }
                
            }
            
        }

        public void GetSolidGeoInstance(GeometryInstance geoInst,ref List<Solid> listSolid)
        {
            GeometryElement geoEle = geoInst.GetInstanceGeometry();
            foreach(GeometryObject geoObj in geoEle)
            {
                Solid solid = geoObj as Solid;
                if(solid!= null && solid.Volume>0.000001)
                {
                    listSolid.Add(solid);
                }
                else
                {
                    GeometryInstance geoIns = geoObj as GeometryInstance;
                    if(geoIns != null)
                    {
                        GetSolidGeoInstance(geoIns, ref listSolid);
                    }
                }
            }

        }
        
    }
}
