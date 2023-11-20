using System.Windows;
using KonyhásI;
using MódosI;

namespace Jedlik_RPG
{
    public partial class Választ1 : Window
    {
        public Választ1()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();

        }

        private void Ebédlő_Click(object sender, RoutedEventArgs e)
        {
            KonyhásIntro k = new KonyhásIntro();
            k.Show();
            this.Close();
        }

        private void Igazgatói_Click(object sender, RoutedEventArgs e)
        {
            MódosIntro m = new MódosIntro();
            m.Show();
            this.Close();
        }
    }
}
