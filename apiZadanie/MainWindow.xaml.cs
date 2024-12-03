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

namespace apiZadanie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PobierzStrefy();
        }

        private async void WybierzStrefe(object sender, RoutedEventArgs e)
        {
            try
            {
                string strefa = strefyLista.SelectedItem.ToString();

                var data = await Timezone.WybierzStrefeCzasowa(strefa);

                timezonetxt.Text = data;
            }
            catch (Exception ex)
            {
                timezonetxt.Text = "Nie można pobrać wartosci" + ex.Message;
            }
        }
        private async void PobierzStrefy()
        {
            strefyLista.ItemsSource = await Timezone.PobierzStrefy();
        }
        
    }
}