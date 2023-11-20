using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using NitsH;
using Adatok;
using Büf;

namespace NitsI
{
    public partial class NitsIntro : Window
    {
        private int Helyes = 0;
        public NitsIntro()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            karakterKép.Source = new BitmapImage(new Uri($"{AlapAdatok.aktKarakterForrás}", UriKind.RelativeOrAbsolute));
            ellenfélKép.Source = new BitmapImage(new Uri($"{"Képek/nits.png"}", UriKind.RelativeOrAbsolute));
            TbKarakter.Visibility = Visibility.Hidden;
            BubiKarakter.Visibility = Visibility.Hidden;
            TbNits.Visibility = Visibility.Hidden;
            BubiNits.Visibility = Visibility.Hidden;
            karakterKép.Visibility = Visibility.Hidden;
            ellenfélKép.Visibility = Visibility.Hidden;
            Történet();
        }
        private async void Történet()
        {
            await Task.Delay(2000);
            Tb1.Text = "* Belépsz a 102-be *";
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
            TbNits.Visibility = Visibility.Visible;
            BubiNits.Visibility = Visibility.Visible;
            TypewriteTextblock("Szép napot!", TbNits, TimeSpan.FromSeconds(0.5));
            await Task.Delay(1000);
            TypewriteTextblock("Nem te vagy az aki nem írt dolgozatot?", TbNits, TimeSpan.FromSeconds(2));
            await Task.Delay(3000);
            TypewriteTextblock("", TbNits, TimeSpan.FromSeconds(1));
            TypewriteTextblock("Öhm... deee lehet", TbKarakter, TimeSpan.FromSeconds(1));
            await Task.Delay(2000);
            TypewriteTextblock("", TbKarakter, TimeSpan.FromSeconds(1));
            TypewriteTextblock("Akkor pótoljuk most be", TbNits, TimeSpan.FromSeconds(2));
            await Task.Delay(3000);
            BubiKarakter.Visibility = Visibility.Hidden;
            TypewriteTextblock("Mire gondolok? Karakterek tárolására alkalmas típus", TbNits, TimeSpan.FromSeconds(2));
            await Task.Delay(3000);
            Lbl_Válasz.Visibility = Visibility.Visible;
            Tb_Válasz.Visibility = Visibility.Visible;

        }
        private async void Tb_Válasz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (Helyes == 2)
                {
                    if (Tb_Válasz.Text.ToLower() == "hamis" || Tb_Válasz.Text.ToLower() == "nem")
                    {
                        Tb_Válasz.IsEnabled = false;
                        TypewriteTextblock("Helyes válasz!", TbNits, TimeSpan.FromSeconds(1));
                        Tb_Válasz.Visibility = Visibility.Hidden;
                        Lbl_Válasz.Visibility = Visibility.Hidden;
                        Tb_Válasz.IsEnabled = false;
                        await Task.Delay(3000);
                        TypewriteTextblock("Rendben, megkapod az 5-öst", TbNits, TimeSpan.FromSeconds(2));
                        await Task.Delay(3000);
                        kep.Visibility = Visibility.Visible;
                        ellenfélKép.Visibility = Visibility.Hidden;
                        TbNits.Visibility = Visibility.Hidden;
                        BubiNits.Visibility = Visibility.Hidden;
                        TbKarakter.Visibility = Visibility.Hidden;
                        BubiKarakter.Visibility = Visibility.Hidden;
                        await Task.Delay(2000);
                        Tb1.Visibility = Visibility.Visible;
                        Bubi1.Visibility = Visibility.Visible;
                        Tb1.Text = "* az 5-östől megnőtt a büszkeséged és a sebzésed *";
                        AlapAdatok.alapDMG += 10;
                        await Task.Delay(3500);
                        karakterKép.Visibility = Visibility.Hidden;
                        kep.Visibility = Visibility.Hidden;
                        Tb1.Text = "* kimész a terembol *";
                        await Task.Delay(2000);
                        Büfé b = new Büfé();
                        b.Show();
                        this.Close();
                    }
                    else
                    {
                        Tb_Válasz.Visibility = Visibility.Hidden;
                        Lbl_Válasz.Visibility = Visibility.Hidden;
                        TypewriteTextblock("ROSSZ VÁLASZ!!!", TbNits, TimeSpan.FromSeconds(1));
                        await Task.Delay(2000);
                        TypewriteTextblock("KIFELÉ A TERMEMBŐL!!!", TbNits, TimeSpan.FromSeconds(1));
                        await Task.Delay(3000);
                        NitsHarc n = new NitsHarc();
                        n.Show();
                        this.Close();
                    }
                }
                if (Helyes == 1)
                {
                    if (Tb_Válasz.Text.ToLower() == "igaz" || Tb_Válasz.Text.ToLower() == "igen")
                    {
                        Tb_Válasz.IsEnabled = false;
                        Helyes++;
                        TypewriteTextblock("Helyes válasz!", TbNits, TimeSpan.FromSeconds(1));
                        Tb_Válasz.Text = "";
                        await Task.Delay(3000);
                        TypewriteTextblock("Igaz vagy hamis? Bármennyi osztálya lehet egy konstruktornak", TbNits, TimeSpan.FromSeconds(2));
                        Tb_Válasz.IsEnabled = true;
                    }
                    else
                    {
                        Tb_Válasz.Visibility = Visibility.Hidden;
                        Lbl_Válasz.Visibility = Visibility.Hidden;
                        TypewriteTextblock("ROSSZ VÁLASZ!!!", TbNits, TimeSpan.FromSeconds(1));
                        await Task.Delay(2000);
                        TypewriteTextblock("KIFELÉ A TERMEMBŐL!!!", TbNits, TimeSpan.FromSeconds(1));
                        await Task.Delay(3000);
                        NitsHarc n = new NitsHarc();
                        n.Show();
                        this.Close();
                    }
                }
                if (Helyes == 0)
                {
                    if (Tb_Válasz.Text.ToLower() == "string" || Tb_Válasz.Text.ToLower() == "char")
                    {
                        Tb_Válasz.IsEnabled = false;
                        Helyes++;
                        TypewriteTextblock("Helyes válasz!", TbNits, TimeSpan.FromSeconds(1));
                        Tb_Válasz.Text = "";
                        await Task.Delay(3000);
                        TypewriteTextblock("Igaz vagy hamis? A szövegliterál mindig idézőjelek közé kerül", TbNits, TimeSpan.FromSeconds(2));
                        Tb_Válasz.IsEnabled = true;
                    }
                    else
                    {
                        Tb_Válasz.Visibility = Visibility.Hidden;
                        Lbl_Válasz.Visibility = Visibility.Hidden;
                        TypewriteTextblock("ROSSZ VÁLASZ!!!", TbNits, TimeSpan.FromSeconds(1));
                        await Task.Delay(2000);
                        TypewriteTextblock("KIFELÉ A TERMEMBŐL!!!", TbNits, TimeSpan.FromSeconds(1));
                        await Task.Delay(3000);
                        NitsHarc n = new NitsHarc();
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
