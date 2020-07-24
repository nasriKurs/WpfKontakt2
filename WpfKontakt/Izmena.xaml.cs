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
using System.Windows.Shapes;

namespace WpfKontakt
{
    /// <summary>
    /// Interaction logic for Izmena.xaml
    /// </summary>
    public partial class Izmena : Window
    {
        public Izmena()
        {
            InitializeComponent();
            BindingGroup = new BindingGroup();

        }

        private void Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Izmeni(object sender, RoutedEventArgs e)
        {
            BindingGroup.CommitEdit();
            MessageBox.Show("USPESNO STE IZMENILI KONTAKT!");
            MainWindow.izmenio = true;
            this.Close();
        }
    }
}
