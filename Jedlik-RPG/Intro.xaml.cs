using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Media;
using IntroAblak2;



namespace IntroAblak
{

    public partial class Intro : Window
    {
        public Intro()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            muzsika();
            yes();
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
        private void muzsika()
        {
            SoundPlayer maro = new SoundPlayer("../../Képek/kezdes_zene.wav");
            maro.Load();
            maro.Play();
        }
        private async void yes()
        {
            FoniBubi.Visibility = Visibility.Visible;
            TypewriteTextblock("Készültetek a dogára?", SzövegFoni, TimeSpan.FromSeconds(2));
            await Task.Delay(2500);
            TypewriteTextblock("", SzövegFoni, TimeSpan.FromSeconds(2));
            FoniBubi.Visibility = Visibility.Hidden;
            TibiBubi.Visibility = Visibility.Visible;
            TypewriteTextblock("Nem", SzövegTibi, TimeSpan.FromSeconds(0.25));
            
            GeriBubi.Visibility = Visibility.Visible;
            TypewriteTextblock("Nem", SzövegGeri, TimeSpan.FromSeconds(0.25));
            await Task.Delay(1750);
            TypewriteTextblock("", SzövegTibi, TimeSpan.FromSeconds(1));
            TypewriteTextblock("", SzövegGeri, TimeSpan.FromSeconds(1));
            TibiBubi.Visibility = Visibility.Hidden;
            GeriBubi.Visibility = Visibility.Hidden;
            PatrikBubi.Visibility = Visibility.Visible;
            TypewriteTextblock("Milyen dogára?", SzövegPatrik, TimeSpan.FromSeconds(2));
            await Task.Delay(3000);
            TypewriteTextblock("", SzövegPatrik, TimeSpan.FromSeconds(1));
            PatrikBubi.Visibility = Visibility.Hidden;
            await Task.Delay(1000);
            Intro2 i = new Intro2();
            i.Show();
            this.Close();
        }
    }
}
