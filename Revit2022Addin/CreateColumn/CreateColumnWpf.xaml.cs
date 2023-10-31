
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
using Autodesk.Revit.UI;

namespace Revit2022Addin.CreateColumn
{
    /// <summary>
    /// Interaction logic for CreateColumnWpf.xaml
    /// </summary>
    public partial class CreateColumnWpf : Window
    {
        private readonly ExternalEvent _createColumnEvent;
        public CreateColumnWpf(ExternalEvent createColumnEvent)
        {
            InitializeComponent();
            _createColumnEvent = createColumnEvent;
        }

        private void btnCreateColumn(object sender, RoutedEventArgs e)
        {
            _createColumnEvent.Raise();
        }
    }
}
