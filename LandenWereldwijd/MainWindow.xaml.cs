using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using Newtonsoft.Json;

namespace LandenWereldwijd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();

            string jsondata = await client.GetStringAsync("https://restcountries.eu/rest/v2/");

            // MessageBox.Show(jsondata.Substring(0, 1000));

            List<Country> lijst = JsonConvert.DeserializeObject<List<Country>>(jsondata);

            var query = from c in lijst
                        where c.Region == "Europe"
                        orderby c.Population descending
                        select c;

            dg.ItemsSource = query.ToList();
        }
    }
}
