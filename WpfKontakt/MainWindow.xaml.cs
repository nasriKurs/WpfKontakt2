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
using System.IO;

namespace WpfKontakt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
         ObservableCollection<Kontakt> Kontakti = new ObservableCollection<Kontakt>();
        public static bool dodao = false;
        public static bool izmenio = false;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Kontakt();
            ImportKontakata();
            Imenik.ItemsSource = Kontakti;
            
        }
        private void ImportKontakata()
        {
            if (File.Exists("imenik.txt"))
            {
                foreach (string art in File.ReadLines("imenik.txt"))
                {
                    string[] polja = art.Split(';');
                    Kontakti.Add(new Kontakt() { Ime = polja[0], Prezime = polja[1], BrojT = polja[2] });
                    //Kontakti.Add(new Kontakt(polja[0], polja[1], double.Parse(polja[2]), int.Parse(polja[3]), int.Parse(polja[4])));
                }
            }
        }
        private void Unos(object sender, RoutedEventArgs e)
        {
            Unos un = new Unos();
            if (Imenik.SelectedItem != null)
                DataContext = new Kontakt();
            un.DataContext = DataContext;
            un.Owner = this;
            un.ShowDialog();
            if(dodao)
            {
                Kontakti.Add(DataContext as Kontakt);
                DataContext = new Kontakt();
                dodao = false;
            }
            
        }

        private void Brisanje(object sender, RoutedEventArgs e)
        {
            if (Imenik.SelectedItem != null)
            {
                Kontakti.Remove(Imenik.SelectedItem as Kontakt);
                MessageBox.Show("USPESNO STE OBRISALI OSOBU!");
            }
                
        }

        private void Izmena(object sender, RoutedEventArgs e)
        {
            if (Imenik.SelectedItem != null)
            {
                Izmena izm = new Izmena();
                izm.DataContext = DataContext;
                izm.Owner = this;
                izm.ShowDialog();
                if (izmenio)
                    izmenio = false;

            }
             
        }

        private void Selekcija(object sender, SelectionChangedEventArgs e)
        {
            if(Imenik.SelectedItem != null)
            {
                DataContext = Imenik.SelectedItem;
            }
        }

        private void Sacuvaj(object sender, EventArgs e)
        {
            File.WriteAllText("imenik.txt","");
            foreach (Kontakt kont in Kontakti)
                File.AppendAllText("imenik.txt", $"{kont.Ime};{kont.Prezime};{kont.BrojT}" + Environment.NewLine);
        }
    }
}
