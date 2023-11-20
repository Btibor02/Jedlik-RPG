using System.Windows;
using System.Media;

namespace Los
{
    public partial class Lose : Window
    {
        public Lose()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            SoundPlayer player = new SoundPlayer("../../Képek/szomi.wav");
            player.Load();
            player.Play();
        }
    }
}
