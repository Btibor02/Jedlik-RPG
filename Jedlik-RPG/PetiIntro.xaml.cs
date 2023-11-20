using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using Adatok;
using PetiH;
using RempiI;

namespace PetiI
{
    public partial class PetiIntro : Window
    {
        private int Helyes = 0;
        public PetiIntro()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            karakterKép.Source = new BitmapImage(new Uri($"{AlapAdatok.aktKarakterForrás}", UriKind.RelativeOrAbsolute));
            ellenfélKép.Source = new BitmapImage(new Uri($"{"Képek/peti.png"}", UriKind.RelativeOrAbsolute));
            TbKarakter.Visibility = Visibility.Hidden;
            BubiKarakter.Visibility = Visibility.Hidden;
            TbPeti.Visibility = Visibility.Hidden;
            BubiPeti.Visibility = Visibility.Hidden;
            karakterKép.Visibility = Visibility.Hidden;
            ellenfélKép.Visibility = Visibility.Hidden;
            Történet();
        }
        private async void Történet()
        {
            await Task.Delay(2000);
            Tb1.Text = "* A folyosón találkozol Petinénivel *";
            await Task.Delay(2000);
            Tb1.Text = "";
            karakterKép.Visibility = Visibility.Visible;
            ellenfélKép.Visibility = Visibility.Visible;
            Bubi1.Visibility = Visibility.Hidden;
            TbKarakter.Visibility = Visibility.Visible;
            BubiKarakter.Visibility = Visibility.Visible;
            TypewriteTextblock("Jó napot!", TbKarakter, TimeSpan.FromSeconds(0.5));
            await Task.Delay(1000);
            TypewriteTextblock("", TbKarakter, TimeSpan.FromSeconds(1));
            TbPeti.Visibility = Visibility.Visible;
            BubiPeti.Visibility = Visibility.Visible;
            TypewriteTextblock("Szép napot!", TbPeti, TimeSpan.FromSeconds(0.5));
            await Task.Delay(1000);
            TypewriteTextblock("Te nem feleltél a memoriterekből még, ugye?", TbPeti, TimeSpan.FromSeconds(2));
            await Task.Delay(3000);
            TypewriteTextblock("", TbPeti, TimeSpan.FromSeconds(1));
            TypewriteTextblock("Öhm... deee lehet, de sajnálom most siete-", TbKarakter, TimeSpan.FromSeconds(2));
            await Task.Delay(2500);
            TypewriteTextblock("Neeeem, gyorsan megleszünk", TbPeti, TimeSpan.FromSeconds(2));
            TypewriteTextblock("", TbKarakter, TimeSpan.FromSeconds(1));
            await Task.Delay(3000);
            BubiKarakter.Visibility = Visibility.Hidden;
            TypewriteTextblock("Fejezd be a szöveget:", TbPeti, TimeSpan.FromSeconds(1));
            await Task.Delay(2000);
            TbPeti.FontSize = 14;
            TypewriteTextblock("Férfiuról szólj nékem, Múzsa, ki sokfele bolygott s hosszan hányódott, földúlván szentfalu...", TbPeti, TimeSpan.FromSeconds(3));
            await Task.Delay(4000);
            Lbl_Válasz.Visibility = Visibility.Visible;
            Tb_Válasz.Visibility = Visibility.Visible;

        }
        private async void Tb_Válasz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (Helyes == 2)
                {
                    if (Tb_Válasz.Text.ToLower() == "csepp vért")
                    {
                        Tb_Válasz.IsEnabled = false;
                        TypewriteTextblock("Helyes válasz!", TbPeti, TimeSpan.FromSeconds(1));
                        Tb_Válasz.Visibility = Visibility.Hidden;
                        Lbl_Válasz.Visibility = Visibility.Hidden;
                        Tb_Válasz.IsEnabled = false;
                        await Task.Delay(3000);
                        TypewriteTextblock("Rendben, megkapod az 5-öst", TbPeti, TimeSpan.FromSeconds(2));
                        await Task.Delay(3000);
                        kep.Visibility = Visibility.Visible;
                        ellenfélKép.Visibility = Visibility.Hidden;
                        TbPeti.Visibility = Visibility.Hidden;
                        BubiPeti.Visibility = Visibility.Hidden;
                        TbKarakter.Visibility = Visibility.Hidden;
                        BubiKarakter.Visibility = Visibility.Hidden;
                        await Task.Delay(2000);
                        Tb1.Visibility = Visibility.Visible;
                        Bubi1.Visibility = Visibility.Visible;
                        Tb1.Text = "* az 5-östől megnőtt a büszkeséged és a sebzésed *";
                        AlapAdatok.alapDMG += 5;
                        await Task.Delay(3500);
                        karakterKép.Visibility = Visibility.Hidden;
                        kep.Visibility = Visibility.Hidden;
                        Tb1.Text = "* továbbmész a folyoson *";
                        await Task.Delay(2000);
                        RempiIroda t = new RempiIroda();
                        t.Show();
                        this.Close();
                    }
                    else
                    {
                        Tb_Válasz.Visibility = Visibility.Hidden;
                        Lbl_Válasz.Visibility = Visibility.Hidden;
                        TypewriteTextblock("ROSSZ VÁLASZ!!!", TbPeti, TimeSpan.FromSeconds(1));
                        await Task.Delay(2000);
                        TypewriteTextblock("HOGY NEM LEHET EZT MEGTANULNI?!!", TbPeti, TimeSpan.FromSeconds(1));
                        await Task.Delay(3000);
                        PetiHarc n = new PetiHarc();
                        n.Show();
                        this.Close();
                    }
                }
                if (Helyes == 1)
                {
                    if (Tb_Válasz.Text.ToLower() == "szép dalokat" || Tb_Válasz.Text.ToLower() == "szépdalokat")
                    {
                        Tb_Válasz.IsEnabled = false;
                        Helyes++;
                        TypewriteTextblock("Helyes válasz!", TbPeti, TimeSpan.FromSeconds(1));
                        Tb_Válasz.Text = "";
                        await Task.Delay(3000);
                        TypewriteTextblock("Láng van szivemben, égbül-eredt láng, Fölforraló minden...", TbPeti, TimeSpan.FromSeconds(2));
                        Tb_Válasz.IsEnabled = true;
                    }
                    else
                    {
                        Tb_Válasz.Visibility = Visibility.Hidden;
                        Lbl_Válasz.Visibility = Visibility.Hidden;
                        TypewriteTextblock("ROSSZ VÁLASZ!!!", TbPeti, TimeSpan.FromSeconds(1));
                        await Task.Delay(2000);
                        TypewriteTextblock("HOGY NEM LEHET EZT MEGTANULNI?!!", TbPeti, TimeSpan.FromSeconds(1));
                        await Task.Delay(3000);
                        PetiHarc n = new PetiHarc();
                        n.Show();
                        this.Close();
                    }
                }
                if (Helyes == 0)
                {
                    if (Tb_Válasz.Text.ToLower() == "tróját")
                    {
                        Tb_Válasz.IsEnabled = false;
                        Helyes++;
                        TypewriteTextblock("Helyes válasz!", TbPeti, TimeSpan.FromSeconds(1));
                        Tb_Válasz.Text = "";
                        await Task.Delay(3000);
                        TypewriteTextblock("Eddig Itália földjén termettek csak a könyvek, S most Pannónia is ontja a...", TbPeti, TimeSpan.FromSeconds(3));
                        Tb_Válasz.IsEnabled = true;
                    }
                    else
                    {
                        Tb_Válasz.Visibility = Visibility.Hidden;
                        Lbl_Válasz.Visibility = Visibility.Hidden;
                        TypewriteTextblock("ROSSZ VÁLASZ!!!", TbPeti, TimeSpan.FromSeconds(1));
                        await Task.Delay(2000);
                        TypewriteTextblock("HOGY NEM LEHET EZT MEGTANULNI?!!", TbPeti, TimeSpan.FromSeconds(1));
                        await Task.Delay(3000);
                        PetiHarc n = new PetiHarc();
                        n.Show();
                        this.Close();
                    }
                }
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

