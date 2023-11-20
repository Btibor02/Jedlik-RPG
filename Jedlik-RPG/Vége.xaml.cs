using System.Windows;
using System.Media;

namespace Vég
{
    public partial class Vége : Window
    {
        public Vége()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            SoundPlayer player = new SoundPlayer("../../Képek/muzsika2.wav");
            player.Load();
            player.Play();
        }
    }
}
