using System.Windows;
using NitsI;
using Diákt;

namespace Jedlik_RPG
{
    public partial class Választ2 : Window
    {
        public Választ2()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();

        }

        private void Ebédlő_Click(object sender, RoutedEventArgs e)
        {
            NitsIntro n = new NitsIntro();
            n.Show();
            this.Close();
        }

        private void Igazgatói_Click(object sender, RoutedEventArgs e)
        {
            Diáktanya m = new Diáktanya();
            m.Show();
            this.Close();
        }
    }
}
