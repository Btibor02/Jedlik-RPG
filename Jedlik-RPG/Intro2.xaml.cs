using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using KarakterV;

namespace IntroAblak2
{
    
    public partial class Intro2 : Window
    {
        public Intro2()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            No();
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
        public async void No()
        {
            TypewriteTextblock("A srácok találkoznak a Tanár úrral a bejáratnál.", TextBNar, TimeSpan.FromSeconds(4));
            await Task.Delay(6000);
            TypewriteTextblock("", TextBNar, TimeSpan.FromSeconds(2));
            Bubi1.Visibility = Visibility.Hidden;
            BubiRempi.Visibility = Visibility.Visible;
            TypewriteTextblock("Jó reggelt bogyókák!", TbRempi, TimeSpan.FromSeconds(2));
            await Task.Delay(4000);
            TypewriteTextblock("Úgy hallottam valami baj van az iskolában.", TbRempi, TimeSpan.FromSeconds(3));
            await Task.Delay(5000);
            TypewriteTextblock("Valamelyikőtök lenne szíves segíteni?", TbRempi, TimeSpan.FromSeconds(2));
            await Task.Delay(4000);
            TypewriteTextblock("Az irodámból kéne valamit elhozni", TbRempi, TimeSpan.FromSeconds(2));
            await Task.Delay(3000);
            TypewriteTextblock("", TbRempi, TimeSpan.FromSeconds(2));
            BubiRempi.Visibility = Visibility.Hidden;
            BubiSrácok.Visibility = Visibility.Visible;
            TypewriteTextblock("Persze, Tanár úr!", TbSrácok, TimeSpan.FromSeconds(2));
            await Task.Delay(4000);
            Karakterválasztó i = new Karakterválasztó();
            i.Show();
            
            this.Close();

        }
    }
}
