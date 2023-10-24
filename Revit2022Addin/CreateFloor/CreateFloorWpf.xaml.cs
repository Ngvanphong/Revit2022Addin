using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class CreateFloorWpf : Window
    {
        private readonly ExternalEvent _createFloorEvent;
        public CreateFloorWpf(ExternalEvent createFloorEvent)
        {
            InitializeComponent();
            _createFloorEvent = createFloorEvent;

        }

        private void btnCreateFloor(object sender, RoutedEventArgs e)
        {
            _createFloorEvent.Raise();
        }
    }
}
