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

namespace Revit2022Addin.CreateBeam
{
    /// <summary>
    /// Interaction logic for CreateBeamWpf.xaml
    /// </summary>
    public partial class CreateBeamWpf : Window
    {
        private readonly ExternalEvent _createBeamEvent;
        private readonly ExternalEvent _getTypeBeamEvent;
        public CreateBeamWpf(ExternalEvent createBeamEvent, ExternalEvent getTypeBeamEvent)
        {
            InitializeComponent();
            _createBeamEvent = createBeamEvent;
            _getTypeBeamEvent = getTypeBeamEvent;
        }

        private void btnCreateBeam(object sender, RoutedEventArgs e)
        {
            _createBeamEvent.Raise();
        }

        private void cbxSelectFamlilyChanged(object sender, SelectionChangedEventArgs e)
        {
            _getTypeBeamEvent.Raise();  
        }
    }
}
