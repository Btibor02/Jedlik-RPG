using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Adatok;
using System.Windows.Media.Animation;
using KonyhásH;
using Jedlik_RPG;


namespace KonyhásI
{
    public partial class KonyhásIntro : Window
    {
        public KonyhásIntro()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            karakterKép.Source = new BitmapImage(new Uri($"{AlapAdatok.aktKarakterForrás}", UriKind.RelativeOrAbsolute));
            ellenfélKép.Source = new BitmapImage(new Uri($"{"Képek/konyhas.png"}", UriKind.RelativeOrAbsolute));
            TbKarakter.Visibility = Visibility.Hidden;
            BubiKarakter.Visibility = Visibility.Hidden;
            TbKonyhás.Visibility = Visibility.Hidden;
            BubiKonyhás.Visibility = Visibility.Hidden;
            karakterKép.Visibility = Visibility.Hidden;
            ellenfélKép.Visibility = Visibility.Hidden;
            Történet();
        }
        public async void Történet()
        {
            await Task.Delay(2000);
            Tb1.Text = "* Belépsz a menzára *";
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
            TbKonyhás.Visibility = Visibility.Visible;
            BubiKonyhás.Visibility = Visibility.Visible;
            TypewriteTextblock("Hát szia drágaságom!", TbKonyhás, TimeSpan.FromSeconds(2));
            await Task.Delay(3000);
            TypewriteTextblock("Elkérhetem az ebédjegyed?", TbKonyhás, TimeSpan.FromSeconds(2));
            await Task.Delay(3000);
            if (AlapAdatok.aktKarakterNév == "Patrik")
            {
                TypewriteTextblock("Öhm... nekem olyanom nincs, nem vagyok menzás", TbKarakter, TimeSpan.FromSeconds(3));
                await Task.Delay(4000);
                TypewriteTextblock("", TbKarakter, TimeSpan.FromSeconds(1));
                TypewriteTextblock("HOGY MICSODA?!", TbKonyhás, TimeSpan.FromSeconds(1));
                await Task.Delay(2000);
                TypewriteTextblock("AKKOR MEG MIT KERESEL ITT??!", TbKonyhás, TimeSpan.FromSeconds(2));
                await Task.Delay(3000);
                TypewriteTextblock("TAKARODÁS KIFELE!!!", TbKonyhás, TimeSpan.FromSeconds(1));
                await Task.Delay(3000);
                KonyhásHarc k = new KonyhásHarc();
                k.Show();
                this.Close();
            }
            else
            {
                TypewriteTextblock("* odaadja *", TbKarakter, TimeSpan.FromSeconds(1));
                await Task.Delay(2000);
                TypewriteTextblock("", TbKarakter, TimeSpan.FromSeconds(1));
                TypewriteTextblock("Köszönöm kicsim, itt az ebéded. Jó étvágyat!", TbKonyhás, TimeSpan.FromSeconds(2));
                await Task.Delay(3000);
                ellenfélKép.Visibility = Visibility.Hidden;
                TbKonyhás.Visibility = Visibility.Hidden;
                BubiKonyhás.Visibility = Visibility.Hidden;
                TbKarakter.Visibility = Visibility.Hidden;
                BubiKarakter.Visibility = Visibility.Hidden;
                await Task.Delay(2000);
                Tb1.Visibility = Visibility.Visible;
                Bubi1.Visibility = Visibility.Visible;
                Tb1.Text = "* a finom ebédtől az életerőd megnőtt 100-al *";
                AlapAdatok.alapHP += 100;
                await Task.Delay(2000);
                karakterKép.Visibility = Visibility.Hidden;
                Tb1.Text = "* kimész az ebédlobol *";
                await Task.Delay(2000);
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
