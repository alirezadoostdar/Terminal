using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Terminal.WPF.Views.UserControls;

namespace Terminal.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            spContent.Children.Add(new BusUserControl());
        }

        private void btnBus_Click(object sender, RoutedEventArgs e)
        {
            spContent.Children.Clear();
            spContent.Children.Add(new BusUserControl());
        }

        private void btnRoute_Click(object sender, RoutedEventArgs e)
        {
            spContent.Children.Clear();
            spContent.Children.Add(new RouteUserControl());
        }

        private void btnTrip_Click(object sender, RoutedEventArgs e)
        {
            spContent.Children.Clear();
            spContent.Children.Add(new TripUserControl());
        }

        private void btnTicket_Click(object sender, RoutedEventArgs e)
        {
            spContent.Children.Clear();
            spContent.Children.Add(new TicketUserControl());
        }
    }
}