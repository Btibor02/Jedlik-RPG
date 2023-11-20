using System.Threading.Tasks;
using System.Windows;
using Adatok;
using LiptákI;

namespace Diákt
{
    public partial class Diáktanya : Window
    {
        public Diáktanya()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            Btn_Spell1.Content = $"{AlapAdatok.spell1Név}";
            Btn_Spell2.Content = $"{AlapAdatok.spell2Név}";
            Btn_Spell3.Content = $"{AlapAdatok.spell3Név}";
        }

        private async void Btn_Spell1_Click(object sender, RoutedEventArgs e)
        {
            AlapAdatok.spell1MinDMG += 10;
            AlapAdatok.spell1MaxDMG += 10;
            Btn_Spell1.IsEnabled = false;
            Btn_Spell2.IsEnabled = false;
            Btn_Spell3.IsEnabled = false;
            await Task.Delay(2000);
            LiptákIntro l = new LiptákIntro();
            l.Show();
            this.Close();

        }

        private async void Btn_Spell2_Click(object sender, RoutedEventArgs e)
        {
            AlapAdatok.spell2MinDMG += 10;
            AlapAdatok.spell2MaxDMG += 10;
            Btn_Spell1.IsEnabled = false;
            Btn_Spell2.IsEnabled = false;
            Btn_Spell3.IsEnabled = false;
            await Task.Delay(2000);
            LiptákIntro l = new LiptákIntro();
            l.Show();
            this.Close();
        }

        private async void Btn_Spell3_Click(object sender, RoutedEventArgs e)
        {
            AlapAdatok.spell3MinDMG += 10;
            AlapAdatok.spell3MaxDMG += 10;
            Btn_Spell1.IsEnabled = false;
            Btn_Spell2.IsEnabled = false;
            Btn_Spell3.IsEnabled = false;
            await Task.Delay(2000);
            LiptákIntro l = new LiptákIntro();
            l.Show();
            this.Close();
        }
    }
}
