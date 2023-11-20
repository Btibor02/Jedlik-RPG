using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Adatok;
using System.Windows.Media.Animation;
using Módi;
using Jedlik_RPG;

namespace MódosI
{
    public partial class MódosIntro : Window
    {
        public MódosIntro()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            karakterKép.Source = new BitmapImage(new Uri($"{AlapAdatok.aktKarakterForrás}", UriKind.RelativeOrAbsolute));
            ellenfélKép.Source = new BitmapImage(new Uri($"{"Képek/módos.png"}", UriKind.RelativeOrAbsolute));
            TbKarakter.Visibility = Visibility.Hidden;
            BubiKarakter.Visibility = Visibility.Hidden;
            TbMódos.Visibility = Visibility.Hidden;
            BubiMódos.Visibility = Visibility.Hidden;
            karakterKép.Visibility = Visibility.Hidden;
            ellenfélKép.Visibility = Visibility.Hidden;
            Történet();

        }
        private async void Történet()
        {
            await Task.Delay(2000);
            Tb1.Text = "* Belépsz az irodába *";
            await Task.Delay(2000);
            Tb1.Text = "";
            karakterKép.Visibility = Visibility.Visible;
            ellenfélKép.Visibility = Visibility.Visible;
            Bubi1.Visibility = Visibility.Hidden;
            TbKarakter.Visibility = Visibility.Visible;
            BubiKarakter.Visibility = Visibility.Visible;
            TypewriteTextblock("Jó napot!", TbKarakter, TimeSpan.FromSeconds(1));
            await Task.Delay(2000);
            TypewriteTextblock("", TbKarakter, TimeSpan.FromSeconds(1));
            TbMódos.Visibility = Visibility.Visible;
            BubiMódos.Visibility = Visibility.Visible;
            if (AlapAdatok.aktKarakterNév == "Tibi" || AlapAdatok.aktKarakterNév == "Geri")
            {
                TypewriteTextblock("Jó napot, de ne ilyen gyorsan fiacskám", TbMódos, TimeSpan.FromSeconds(2));
                await Task.Delay(3000);
                TypewriteTextblock("Mi ez a szag amit rajtad érzek?", TbMódos, TimeSpan.FromSeconds(2));
                await Task.Delay(3000);
                TypewriteTextblock("Csak nem cigaretta?!", TbMódos, TimeSpan.FromSeconds(2));
                await Task.Delay(3000);
                TypewriteTextblock("Ez nem megengedett ebben az iskolában!!!", TbMódos, TimeSpan.FromSeconds(2));
                await Task.Delay(4000);
                MódosHarc m = new MódosHarc();
                m.Show();
                this.Close();
            }
            else
            {
                TypewriteTextblock("Kedves fiú, miben segíthetek?", TbMódos, TimeSpan.FromSeconds(2));
                await Task.Delay(3000);
                TbMódos.Text = "";
                TypewriteTextblock("Remport tanár úr irodájába szeretnék eljutni,", TbKarakter, TimeSpan.FromSeconds(2));
                await Task.Delay(3000);
                TypewriteTextblock("illetve megtudni hogy mi történt az iskolában", TbKarakter, TimeSpan.FromSeconds(2));
                await Task.Delay(3000);
                TbKarakter.Text = "";
                TypewriteTextblock("Az egyetlen amivel tudok segíteni az a 110 kulcsa", TbMódos, TimeSpan.FromSeconds(2));
                await Task.Delay(4000);
                TbMódos.Text = "";
                TbKarakter.Visibility = Visibility.Hidden;
                BubiKarakter.Visibility = Visibility.Hidden;
                TbMódos.Visibility = Visibility.Hidden;
                BubiMódos.Visibility = Visibility.Hidden;
                kulcs.Visibility = Visibility.Visible;
                for (int i = 871; i > 225; i-= 5)
                {
                    kulcs.Margin = new Thickness(i, 338, 0, 0);
                    await Task.Delay(TimeSpan.FromMilliseconds(0.5));
                }
                kulcs.Visibility = Visibility.Hidden;
                MainWindow.KulcsNálad = true;
                await Task.Delay(1000);
                Bubi1.Visibility = Visibility.Visible;
                Tb1.Text = "* kimész az irodából *";
                karakterKép.Visibility = Visibility.Hidden;
                ellenfélKép.Visibility = Visibility.Hidden;
                Választ2 v = new Választ2();
                v.Show();
                this.Close();
            }

        }




        private void TypewriteTextblock(string textToAnimate, TextBlock txt, TimeSpan timeSpan)
        {
            Storyboard story = new Storyboard();
            story.FillBehavior = FillBehavior.HoldEnd;

            DiscreteStringKeyFrame discreteStringKeyFrame;
            StringAnimationUsingKeyFrames stringAnimationUsingKeyFrames = new StringAnimationUsingKeyFrames();
            stringAnimationUsingKeyFrames.Duration = new Duration(timeSpan);

            string tmp = string.Empty;
            foreach (char c in textToAnimate)
            {
                discreteStringKeyFrame = new DiscreteStringKeyFrame();
                discreteStringKeyFrame.KeyTime = KeyTime.Paced;
                tmp += c;
                discreteStringKeyFrame.Value = tmp;
                stringAnimationUsingKeyFrames.KeyFrames.Add(discreteStringKeyFrame);
            }
            Storyboard.SetTargetName(stringAnimationUsingKeyFrames, txt.Name);
            Storyboard.SetTargetProperty(stringAnimationUsingKeyFrames, new PropertyPath(TextBlock.TextProperty));
            story.Children.Add(stringAnimationUsingKeyFrames);

            story.Begin(txt);

        }
    }
}
