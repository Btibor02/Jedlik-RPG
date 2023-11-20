using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Adatok;

namespace RempiI
{
    public partial class RempiIroda : Window
    {
        public RempiIroda()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            karakterKép.Source = new BitmapImage(new Uri($"{AlapAdatok.aktKarakterForrás}", UriKind.RelativeOrAbsolute));
            karakterKép.Visibility = Visibility.Hidden;
            Történet();
        }
        private async void Történet()
        {
            await Task.Delay(2000);
            Tb1.Text = "* Belépsz Rempi irodájába *";
            await Task.Delay(2000);
            Tb1.Text = "";
            karakterKép.Visibility = Visibility.Visible;
            Tb1.Text = "* Meglátod az asztalán amit kért és elindulsz vele megkeresni*";
            await Task.Delay(2000);
            Tb1.Text = "";
            await Task.Delay(2000);
            RempiIntro r = new RempiIntro();
            r.Show();
            this.Close();
        }
    }
}
