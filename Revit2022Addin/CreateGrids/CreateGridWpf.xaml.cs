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

namespace Revit2022Addin.CreateGrids
{
    /// <summary>
    /// Interaction logic for CreateGridWpf.xaml
    /// </summary>
    public partial class CreateGridWpf : Window
    {
        private readonly ExternalEvent _createGridEvent;
        public CreateGridWpf(ExternalEvent createGridEvent)
        {
            InitializeComponent();
            _createGridEvent = createGridEvent;
        }

        private void btnCreate(object sender, RoutedEventArgs e)
        {
            _createGridEvent.Raise();
        }
    }
}
