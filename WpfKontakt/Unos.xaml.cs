using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfKontakt
{
    /// <summary>
    /// Interaction logic for Unos.xaml
    /// </summary>
    public partial class Unos : Window
    {
        ObservableCollection<Kontakt> Kontakti = new ObservableCollection<Kontakt>();
        public Unos()
        {
            InitializeComponent();
            BindingGroup = new BindingGroup();

        }
        

        private void Dodaj(object sender, RoutedEventArgs e)
        {
            BindingGroup.CommitEdit();
            MessageBox.Show("USPESNO STE DODALI NOVI KONTAKT!");
            MainWindow.dodao = true;
            this.Close();
        }

        private void Odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
