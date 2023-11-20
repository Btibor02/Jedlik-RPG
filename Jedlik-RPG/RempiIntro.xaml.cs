using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Adatok;
using System.Windows.Media.Animation;
using RempiH;


namespace RempiI
{
    public partial class RempiIntro : Window
    {
        public RempiIntro()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            karakterKép.Source = new BitmapImage(new Uri($"{AlapAdatok.aktKarakterForrás}", UriKind.RelativeOrAbsolute));
            ellenfélKép.Source = new BitmapImage(new Uri($"{"Képek/rempi.png"}", UriKind.RelativeOrAbsolute));
            TbKarakter.Visibility = Visibility.Hidden;
            BubiKarakter.Visibility = Visibility.Hidden;
            TbRempi.Visibility = Visibility.Hidden;
            BubiRempi.Visibility = Visibility.Hidden;
            karakterKép.Visibility = Visibility.Hidden;
            ellenfélKép.Visibility = Visibility.Hidden;
            Történet();
        }
        public async void Történet()
        {
            await Task.Delay(2000);
            Tb1.Text = "* Újra találkozol Rempivel *";
            await Task.Delay(2000);
            Tb1.Text = "";
            karakterKép.Visibility = Visibility.Visible;
            TbKarakter.Visibility = Visibility.Visible;
            BubiKarakter.Visibility = Visibility.Visible;
            Bubi1.Visibility = Visibility.Hidden;
            ellenfélKép.Visibility = Visibility.Visible;
            TbRempi.Visibility = Visibility.Visible;
            BubiRempi.Visibility = Visibility.Visible;
            TypewriteTextblock("Végre megvan tanár úr!", TbKarakter, TimeSpan.FromSeconds(1.5));
            await Task.Delay(2000);
            TypewriteTextblock("", TbKarakter, TimeSpan.FromSeconds(1));
            TypewriteTextblock("Itt van amit kért", TbKarakter, TimeSpan.FromSeconds(1.5));
            await Task.Delay(2000);
            TypewriteTextblock("", TbKarakter, TimeSpan.FromSeconds(1));
            TypewriteTextblock("Köszönöm...", TbRempi, TimeSpan.FromSeconds(1.5));
            await Task.Delay(2000);
            TypewriteTextblock("", TbRempi, TimeSpan.FromSeconds(1));
            TypewriteTextblock("hogy beleestél a csapdámba!!", TbRempi, TimeSpan.FromSeconds(1.5));
            await Task.Delay(3000);
            TypewriteTextblock("", TbRempi, TimeSpan.FromSeconds(1));
            TypewriteTextblock("Micsoda?!", TbKarakter, TimeSpan.FromSeconds(1));
            await Task.Delay(2000);
            TypewriteTextblock("", TbKarakter, TimeSpan.FromSeconds(1));
            Bubi1.Visibility = Visibility.Visible;
            Tb1.Text = "* Elkezd remegni a föld és minden megváltozik *";
            await Task.Delay(2000);
            for (double i = 0; i < 1; i += 0.05)
            {
                Feherkep.Opacity = i;
                await Task.Delay(100);
            }
            Tb1.Text = "";
            Bubi1.Visibility = Visibility.Hidden;
            hatter.ImageSource = new BitmapImage(new Uri("../../Képek/folyosocursed.png", UriKind.Relative));
            ellenfélKép.Source = new BitmapImage(new Uri($"{"Képek/rempigonosz.png"}", UriKind.RelativeOrAbsolute));
            for (double i = 1; i > 0; i -= 0.05)
            {
                Feherkep.Opacity = i;
                await Task.Delay(100);
            }
            
            TypewriteTextblock("MOST VÉGE!!!", TbRempi, TimeSpan.FromSeconds(1));
            await Task.Delay(4000);
            RempiHarc l = new RempiHarc();
            l.Show();
            this.Close();

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
