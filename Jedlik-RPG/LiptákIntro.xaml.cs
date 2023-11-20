using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Adatok;
using System.Windows.Media.Animation;
using LiptákH;
using RempiI;


namespace LiptákI
{
    public partial class LiptákIntro : Window
    {
        public LiptákIntro()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            karakterKép.Source = new BitmapImage(new Uri($"{AlapAdatok.aktKarakterForrás}", UriKind.RelativeOrAbsolute));
            ellenfélKép.Source = new BitmapImage(new Uri($"{"Képek/liptak.png"}", UriKind.RelativeOrAbsolute));
            TbKarakter.Visibility = Visibility.Hidden;
            BubiKarakter.Visibility = Visibility.Hidden;
            TbLipták.Visibility = Visibility.Hidden;
            BubiLipták.Visibility = Visibility.Hidden;
            karakterKép.Visibility = Visibility.Hidden;
            ellenfélKép.Visibility = Visibility.Hidden;
            Történet();
        }
        public async void Történet()
        {
            await Task.Delay(2000);
            Tb1.Text = "* Belépsz a 116ba *";
            await Task.Delay(2000);
            Tb1.Text = "";
            karakterKép.Visibility = Visibility.Visible;
            
            
            if (AlapAdatok.aktKarakterNév == "Foni")
            {
                Tb1.Text = "* meglátod, hogy az egyik gépen meg van nyitva a minecraft *";
                await Task.Delay(3000);
                Tb1.Text = "* Nem bírsz ellenállni a kísértésnek és leülsz játszani *";
                await Task.Delay(3000);
                Tb1.Text = "";
                TbKarakter.Visibility = Visibility.Visible;
                BubiKarakter.Visibility = Visibility.Visible;
                Bubi1.Visibility = Visibility.Hidden;
                ellenfélKép.Visibility = Visibility.Visible;
                TbLipták.Visibility = Visibility.Visible;
                BubiLipták.Visibility = Visibility.Visible;
                TypewriteTextblock("ezt meg ki engedte meg neked?!!", TbLipták, TimeSpan.FromSeconds(2));
                await Task.Delay(3000);
                TypewriteTextblock("", TbLipták, TimeSpan.FromSeconds(1));
                TbKarakter.Visibility = Visibility.Visible;
                BubiKarakter.Visibility = Visibility.Visible;
                TypewriteTextblock("Csak meg volt nyitva és nem bírtam ellenállni", TbKarakter, TimeSpan.FromSeconds(1));
                await Task.Delay(2000);
                TypewriteTextblock("", TbKarakter, TimeSpan.FromSeconds(1));
                TypewriteTextblock("Ekkora szemtelenséget!!", TbLipták, TimeSpan.FromSeconds(2));
                await Task.Delay(3000);
                TypewriteTextblock("TAKARODÁS KIFELE!!!", TbLipták, TimeSpan.FromSeconds(1));
                await Task.Delay(3000);
                LiptákHarc l = new LiptákHarc();
                l.Show();
                this.Close();
            }
            else
            {
                Tb1.Text = "* az asztalon megtalálod Rempi irodakulcsát *";
                await Task.Delay(2000);
                karakterKép.Visibility = Visibility.Visible;
                await Task.Delay(2000);
                Tb1.Text = "* továbbmész *";
                await Task.Delay(2000);
                karakterKép.Visibility = Visibility.Hidden;
                RempiIroda t = new RempiIroda();
                t.Show();
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
