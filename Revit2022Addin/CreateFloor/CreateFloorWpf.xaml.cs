using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Revit2022Addin.CreateFloor
{
    /// <summary>
    /// Interaction logic for CreateFloorWpf.xaml
    /// </summary>
    public partial class CreateFloorWpf : Window, INotifyPropertyChanged // dung de thong bao giao dien thay doi property scale
    {
        private readonly ExternalEvent _createFloorEvent;


        /// <summary>
        /// Cu phap de phat thong bao thay doi den giao dien
        /// </summary>
        #region
        public event PropertyChangedEventHandler PropertyChanged; // su kien de ban cho giao dien nhan duoc tin hieu thay doi slace

        private double _scale;
        public double Scale
        {
            get { return _scale; }
            set
            {
                _scale = value;
                OnPropertyChanged("Scale"); // ban su kien thay doi property 
            }
        }
        #endregion



        public CreateFloorWpf(ExternalEvent createFloorEvent)
        {
            InitializeComponent();
            this.DataContext = this;// de chi ra data binding den giao dien chinh la class nay
            _createFloorEvent = createFloorEvent;

        }

        private void btnCreateFloor(object sender, RoutedEventArgs e)
        {
            _createFloorEvent.Raise();
        }

        private void Loading_Loaded(object sender, RoutedEventArgs e) // ve line tai day
        {
            double width = CreateFloorAppShow.Xmax - CreateFloorAppShow.Xmin;
            double height= CreateFloorAppShow.Ymax -  CreateFloorAppShow.Ymin;
            canvasFloor.Width = width * 304.8 * 3.7;
            canvasFloor.Height = height * 304.8 * 3.7;

            double scaleX = 400 / (width * 304.8 * 3.7);
            double scaleY = 400 / (height * 304.8 * 3.7);
            Scale= Math.Min(scaleX, scaleY);
            foreach(var items in CreateFloorAppShow.ListRoomInformation)
            {
                foreach(var lineRe in items.ListLine)
                {
                    XYZ p1 = lineRe.GetEndPoint(0);
                    XYZ p2= lineRe.GetEndPoint(1);

                    double xP1Canvas = (p1.X - CreateFloorAppShow.Xmin) * 304.8 * 3.7;
                    double yP1Canvas= (p1.Y- CreateFloorAppShow.Ymin) * 304.8 * 3.7;

                    double xP2Canvas = (p2.X - CreateFloorAppShow.Xmin) * 304.8 * 3.7;
                    double yP2Canvas = (p2.Y - CreateFloorAppShow.Ymin) * 304.8 * 3.7;
                    CanvasUnitilies.CreateLine(xP1Canvas, yP1Canvas, xP2Canvas, yP2Canvas, canvasFloor,Scale);
                }

                double xCenterRoom = (items.LocationRoom.X - CreateFloorAppShow.Xmin) * 304.8 * 3.7;
                double yCenterRoom = (items.LocationRoom.Y - CreateFloorAppShow.Ymin) * 304.8 * 3.7;
                CanvasUnitilies.CreateText(xCenterRoom, yCenterRoom, items.NameRoom, canvasFloor, Scale);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }


}
