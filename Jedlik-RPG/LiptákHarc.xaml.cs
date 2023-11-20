using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using Adatok;
using Jedlik_RPG;
using Los;
using RempiI;

namespace LiptákH
{
    public partial class LiptákHarc : Window
    {
        private int helyiKarakterHP;
        private int helyiKarakterMaxHP;
        private int helyiKarakterDMG;
        private string helyiEllenfélNév;
        private int helyiEllenfélHP;
        private int helyiEllenfélMaxHP;
        private int helyiEllenfélDMG;
        private int helyiKarakterTűz;
        private int helyiKarakterUndorító;
        private int helyiKarakterVérzés;
        private int helyiKarakterFagyás;
        private Fegyver helyiFegyver;
        private Páncél helyiPáncél;
        private string helyiEllenfélSpell1Név;
        private int helyiEllenfélSpell1MinDMG;
        private int helyiEllenfélSpell1MaxDMG;
        private string helyiEllenfélSpell1Effekt;
        private string helyiEllenfélSpell2Név;
        private int helyiEllenfélSpell2MinDMG;
        private int helyiEllenfélSpell2MaxDMG;
        private string helyiEllenfélSpell2Effekt;
        private string helyiEllenfélSpell3Név;
        private int helyiEllenfélSpell3MinDMG;
        private int helyiEllenfélSpell3MaxDMG;
        private string helyiEllenfélSpell3Effekt;
        private int helyiEllenfélTűz;
        private int helyiEllenfélUndorító;
        private int helyiEllenfélVérzés;
        private int helyiEllenfélFagyás;
        private int használt = 0;
        private int GeriHonor = 0;

        Random rnd = new Random();

        public LiptákHarc()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            foreach (var i in MainWindow.Fegyverek)
            {
                if (AlapAdatok.aktFegyver == i.Név)
                {
                    helyiFegyver = i;
                }
            }
            foreach (var s in MainWindow.Páncélok)
            {
                if (AlapAdatok.aktPáncél == s.Név)
                {
                    helyiPáncél = s;
                }
            }
            karakterKép.Source = new BitmapImage(new Uri($"{AlapAdatok.aktKarakterForrás}", UriKind.RelativeOrAbsolute));
            ellenfélKép.Source = new BitmapImage(new Uri($"{"Képek/liptak.png"}", UriKind.RelativeOrAbsolute));
            helyiKarakterHP = AlapAdatok.alapHP + helyiPáncél.HP;
            helyiKarakterMaxHP = AlapAdatok.alapHP + helyiPáncél.HP;
            helyiKarakterDMG = AlapAdatok.alapDMG + helyiFegyver.DMG;
            Spell1Gomb.Content = $"{AlapAdatok.spell1Név}";
            Spell2Gomb.Content = $"{AlapAdatok.spell2Név}";
            Spell3Gomb.Content = $"{AlapAdatok.spell3Név}";
            Spell1LeírásTb.Text = $"{AlapAdatok.spell1Leírás}";
            Spell2LeírásTb.Text = $"{AlapAdatok.spell2Leírás}";
            Spell3LeírásTb.Text = $"{AlapAdatok.spell3Leírás}";
            KarakterNévLabel.Content = $"{AlapAdatok.aktKarakterNév}";


            helyiEllenfélNév = "Lipták";
            EllenfélNévLabel.Content = $"{helyiEllenfélNév}";
            helyiEllenfélHP = 500;
            helyiEllenfélDMG = 20;
            helyiEllenfélMaxHP = 500;
            helyiEllenfélSpell1Név = "Egyes bevágás";
            helyiEllenfélSpell1MinDMG = 30;
            helyiEllenfélSpell1MaxDMG = 35;
            helyiEllenfélSpell1Effekt = "semmi";
            helyiEllenfélSpell2Név = "Füzetellenőrzés";
            helyiEllenfélSpell2MinDMG = 20;
            helyiEllenfélSpell2MaxDMG = 25;
            helyiEllenfélSpell2Effekt = "Tűz";
            helyiEllenfélSpell3Név = "Word rajzoltatás";
            helyiEllenfélSpell3MinDMG = 18;
            helyiEllenfélSpell3MaxDMG = 22;
            helyiEllenfélSpell3Effekt = "Fagyás";
            HPváltozott();

        }
        public void HPváltozott()
        {
            karakterHP.Value = (int)Math.Round((double)(100 * helyiKarakterHP) / helyiKarakterMaxHP);
            ellenfélHP.Value = (int)Math.Round((double)(100 * helyiEllenfélHP) / helyiEllenfélMaxHP);
            karakterHPszöveg.Content = $"{helyiKarakterHP} / {helyiKarakterMaxHP}";
            ellenfélHPszöveg.Content = $"{helyiEllenfélHP} / {helyiEllenfélMaxHP}";
        }

        private async void Spell1Gomb_Click(object sender, RoutedEventArgs e)
        {
            Spell1Gomb.IsEnabled = false;
            Spell2Gomb.IsEnabled = false;
            Spell3Gomb.IsEnabled = false;
            int dmg = rnd.Next(AlapAdatok.spell1MinDMG, AlapAdatok.spell1MaxDMG);
            helyiEllenfélHP -= dmg + helyiKarakterDMG;
            történésLabel.Content = $"{AlapAdatok.aktKarakterNév} használta a(z) {AlapAdatok.spell1Név}-t és {dmg + helyiKarakterDMG}-t sebzett!";
            if (helyiEllenfélHP <= 0)
            {
                HPváltozott();
                await Task.Delay(2000);
                Win();
            }
            else
            {
                HPváltozott();
                await Task.Delay(2000);
                történésLabel.Content = "";
                EllenfélJön();
            }


        }

        private async void Spell2Gomb_Click(object sender, RoutedEventArgs e)
        {
            Spell1Gomb.IsEnabled = false;
            Spell2Gomb.IsEnabled = false;
            Spell3Gomb.IsEnabled = false;
            if (AlapAdatok.spell2Effekt == "Heal")
            {
                int heal = rnd.Next(AlapAdatok.spell2MinDMG, AlapAdatok.spell2MaxDMG);
                if (helyiKarakterHP + heal > helyiKarakterMaxHP)
                {
                    heal = helyiKarakterMaxHP - helyiKarakterHP;
                }
                helyiKarakterHP += heal;
                történésLabel.Content = $"{AlapAdatok.aktKarakterNév} használta a {AlapAdatok.spell2Név}-t és {heal}-t gyógyult";
                HPváltozott();
                await Task.Delay(2000);
                EllenfélJön();
            }
            else
            {
                if (AlapAdatok.spell2Effekt == "DmgUp")
                {
                    helyiKarakterTűz = 3;
                    történésLabel.Content = $"{AlapAdatok.aktKarakterNév} meggyújtotta saját magát!";
                    await Task.Delay(2000);
                    int dmgup = rnd.Next(AlapAdatok.spell2MinDMG, AlapAdatok.spell2MaxDMG);
                    helyiKarakterDMG += dmgup;
                    történésLabel.Content = $"{AlapAdatok.aktKarakterNév} {dmgup}-al növelte a sebzését!";
                    await Task.Delay(2000);
                    GeriHonor++;
                    EllenfélJön();
                }
                else
                {
                    int dmg = rnd.Next(AlapAdatok.spell2MinDMG, AlapAdatok.spell2MaxDMG);
                    helyiEllenfélHP -= dmg + helyiKarakterDMG;
                    történésLabel.Content = $"{AlapAdatok.aktKarakterNév} használta a(z) {AlapAdatok.spell2Név}-t és {dmg + helyiKarakterDMG}-t sebzett!";
                    if (helyiEllenfélHP <= 0)
                    {
                        HPváltozott();
                        await Task.Delay(2000);
                        Win();
                    }
                    else
                    {
                        HPváltozott();
                        await Task.Delay(2000);
                        történésLabel.Content = "";
                        if (AlapAdatok.spell2Effekt == "Tűz")
                        {
                            int tűz = rnd.Next(1, 4);
                            if (tűz == 3)
                            {
                                helyiEllenfélTűz = 2;
                                történésLabel.Content = $"{AlapAdatok.aktKarakterNév} meggyújtotta {helyiEllenfélNév}-t!";
                            }

                        }
                        if (AlapAdatok.spell2Effekt == "Undorító")
                        {
                            int undor = rnd.Next(1, 4);
                            if (undor == 3)
                            {
                                helyiEllenfélUndorító = 1;
                                történésLabel.Content = $"{helyiEllenfélNév} elundorodott!";
                            }

                        }
                        if (AlapAdatok.spell2Effekt == "Vérzés")
                        {
                            int vér = rnd.Next(1, 4);
                            if (vér == 3)
                            {
                                helyiEllenfélVérzés = 2;
                                történésLabel.Content = $"{AlapAdatok.aktKarakterNév} megvágta {helyiEllenfélNév}-t és vérezni kezdett!";
                            }

                        }
                        if (AlapAdatok.spell2Effekt == "Fagyás")
                        {
                            int fagy = rnd.Next(1, 4);
                            if (fagy == 3)
                            {
                                helyiEllenfélFagyás = 1;
                                történésLabel.Content = $"{helyiEllenfélNév} megfagyott!";
                            }

                        }
                        EllenfélJön();
                    }

                }
            }
        }

        private async void Spell3Gomb_Click(object sender, RoutedEventArgs e)
        {
            Spell1Gomb.IsEnabled = false;
            Spell2Gomb.IsEnabled = false;
            Spell3Gomb.IsEnabled = false;
            if (AlapAdatok.spell3Effekt == "Heal")
            {
                int heal = rnd.Next(AlapAdatok.spell3MinDMG, AlapAdatok.spell3MaxDMG);
                if (helyiKarakterHP + heal > helyiKarakterMaxHP)
                {
                    heal = helyiKarakterMaxHP - helyiKarakterHP;
                }
                helyiKarakterHP += heal;
                történésLabel.Content = $"{AlapAdatok.aktKarakterNév} használta a {AlapAdatok.spell3Név}-t és {heal}-t gyógyult";
                HPváltozott();
                await Task.Delay(2000);
                EllenfélJön();
            }
            else
            {
                if (AlapAdatok.spell3Effekt == "GeriHeal")
                {
                    int heal = rnd.Next(AlapAdatok.spell3MinDMG, AlapAdatok.spell3MaxDMG);
                    if (helyiKarakterHP + heal > helyiKarakterMaxHP)
                    {
                        heal = helyiKarakterMaxHP - helyiKarakterHP;
                    }
                    helyiKarakterHP += heal;
                    történésLabel.Content = $"{AlapAdatok.aktKarakterNév} használta a {AlapAdatok.spell3Név}-t és {heal}-t gyógyult";
                    HPváltozott();
                    await Task.Delay(2000);
                    int undor = rnd.Next(1, 4);
                    if (undor == 3)
                    {
                        helyiEllenfélUndorító = 1;
                        történésLabel.Content = $"{helyiEllenfélNév} Gergő gyors kávéivásától elundorodott!";
                        await Task.Delay(2000);
                    }

                    EllenfélJön();
                }
                else
                {
                    int dmg = rnd.Next(AlapAdatok.spell3MinDMG, AlapAdatok.spell3MaxDMG);
                    helyiEllenfélHP -= dmg + helyiKarakterDMG;
                    történésLabel.Content = $"{AlapAdatok.aktKarakterNév} használta a(z) {AlapAdatok.spell3Név}-t és {dmg + helyiKarakterDMG}-t sebzett!";
                    if (helyiEllenfélHP <= 0)
                    {
                        HPváltozott();
                        await Task.Delay(2000);
                        Win();
                    }
                    else
                    {
                        HPváltozott();
                        await Task.Delay(2000);
                        történésLabel.Content = "";
                        if (AlapAdatok.spell3Effekt == "Tűz")
                        {
                            int tűz = rnd.Next(1, 4);
                            if (tűz == 3)
                            {
                                helyiEllenfélTűz = 2;
                                történésLabel.Content = $"{AlapAdatok.aktKarakterNév} meggyújtotta {helyiEllenfélNév}-t!";
                            }

                        }
                        if (AlapAdatok.spell3Effekt == "Undorító")
                        {
                            int undor = rnd.Next(1, 4);
                            if (undor == 3)
                            {
                                helyiEllenfélUndorító = 1;
                                történésLabel.Content = $"{helyiEllenfélNév} elundorodott!";
                            }

                        }
                        if (AlapAdatok.spell3Effekt == "Vérzés")
                        {
                            int vér = rnd.Next(1, 4);
                            if (vér == 3)
                            {
                                helyiEllenfélVérzés = 2;
                                történésLabel.Content = $"{AlapAdatok.aktKarakterNév} megvágta {helyiEllenfélNév}-t és vérezni kezdett!";
                            }

                        }
                        if (AlapAdatok.spell3Effekt == "Fagyás")
                        {
                            int fagy = rnd.Next(1, 4);
                            if (fagy == 3)
                            {
                                helyiEllenfélFagyás = 1;
                                történésLabel.Content = $"{helyiEllenfélNév} megfagyott!";
                            }

                        }
                        EllenfélJön();
                    }

                }
            }
        }

        private async void EllenfélJön()
        {
            await Task.Delay(2000);
            if (helyiEllenfélTűz > 0 || helyiEllenfélVérzés > 0 || helyiEllenfélUndorító > 0 || helyiEllenfélFagyás > 0)
            {
                bool ellenfélJön = true;
                if (helyiEllenfélTűz > 0)
                {
                    int dmg = rnd.Next(5, 11);
                    történésLabel.Content = $"{helyiEllenfélNév} ég ezért {dmg}-t sebződött";
                    helyiEllenfélTűz -= 1;
                    helyiEllenfélHP -= dmg;
                    HPváltozott();
                    await Task.Delay(2000);
                    történésLabel.Content = "";
                }
                if (helyiEllenfélVérzés > 0)
                {
                    int dmg = rnd.Next(5, 11);
                    történésLabel.Content = $"{helyiEllenfélNév} vérzik ezért {dmg}-t sebződött";
                    helyiEllenfélVérzés -= 1;
                    helyiEllenfélHP -= dmg;
                    HPváltozott();
                    await Task.Delay(2000);
                    történésLabel.Content = "";
                }
                if (helyiEllenfélUndorító > 0)
                {
                    történésLabel.Content = $"{helyiEllenfélNév} behányt az undortól, ezért {AlapAdatok.aktKarakterNév} támad újra";
                    helyiEllenfélUndorító -= 1;
                    await Task.Delay(2000);
                    történésLabel.Content = "";
                    ellenfélJön = false;
                }

                if (helyiEllenfélFagyás > 0)
                {
                    történésLabel.Content = $"{helyiEllenfélNév} meg van fagyva, ezért {AlapAdatok.aktKarakterNév} támad újra";
                    helyiEllenfélFagyás -= 1;
                    await Task.Delay(2000);
                    történésLabel.Content = "";
                    ellenfélJön = false;
                }
                if (ellenfélJön == true)
                {
                    EllenfélTámad();
                }
                if (ellenfélJön == false)
                {
                    KarakterJön();
                }

            }
            else
            {
                EllenfélTámad();
            }


        }
        private async void EllenfélTámad()
        {
            int melyikSpell = rnd.Next(1, 4);

            if (melyikSpell == 1)
            {
                if (helyiEllenfélSpell1Effekt == "Heal")
                {
                    int heal = rnd.Next(helyiEllenfélSpell1MinDMG, helyiEllenfélSpell1MaxDMG);
                    if (helyiEllenfélHP + heal > helyiEllenfélMaxHP)
                    {
                        heal = helyiEllenfélMaxHP - helyiEllenfélHP;
                    }
                    helyiKarakterHP += heal;
                    történésLabel.Content = $"{helyiEllenfélNév} használta a {helyiEllenfélSpell1Név}-t és {heal}-t gyógyult";
                    HPváltozott();
                    await Task.Delay(2000);
                    KarakterJön();
                }
                else
                {


                    int dmg = rnd.Next(helyiEllenfélSpell1MinDMG, helyiEllenfélSpell1MaxDMG);
                    helyiKarakterHP -= dmg + helyiEllenfélDMG;
                    történésLabel.Content = $"{helyiEllenfélNév} használta a(z) {helyiEllenfélSpell1Név}-t és {dmg + helyiEllenfélDMG}-t sebzett";
                    HPváltozott();
                    await Task.Delay(2000);
                    történésLabel.Content = "";

                    KarakterJön();
                }
            }
            if (melyikSpell == 2)
            {
                if (helyiEllenfélSpell2Effekt == "Heal")
                {
                    int heal = rnd.Next(helyiEllenfélSpell2MinDMG, helyiEllenfélSpell2MaxDMG);
                    if (helyiEllenfélHP + heal > helyiEllenfélMaxHP)
                    {
                        heal = helyiEllenfélMaxHP - helyiEllenfélHP;
                    }
                    helyiEllenfélHP += heal;
                    történésLabel.Content = $"{helyiEllenfélNév} használta a {helyiEllenfélSpell2Név}-t és {heal}-t gyógyult";
                    HPváltozott();
                    await Task.Delay(2000);
                    KarakterJön();
                }
                else
                {
                    int dmg = rnd.Next(helyiEllenfélSpell2MinDMG, helyiEllenfélSpell2MaxDMG);
                    helyiKarakterHP -= dmg + helyiEllenfélDMG;
                    történésLabel.Content = $"{helyiEllenfélNév} használta a(z) {helyiEllenfélSpell2Név}-t és {dmg + helyiEllenfélDMG}-t sebzett";
                    HPváltozott();
                    await Task.Delay(2000);
                    történésLabel.Content = "";
                    if (helyiEllenfélSpell2Effekt == "Tűz")
                    {
                        int tűz = rnd.Next(1, 4);
                        if (tűz == 3)
                        {
                            helyiKarakterTűz = 2;
                            történésLabel.Content = $"{helyiEllenfélNév} meggyújtotta {AlapAdatok.aktKarakterNév}-t!";
                        }

                    }
                    if (helyiEllenfélSpell2Effekt == "Undorító")
                    {
                        int undor = rnd.Next(1, 4);
                        if (undor == 3)
                        {
                            helyiKarakterUndorító = 1;
                            történésLabel.Content = $"{AlapAdatok.aktKarakterNév} elundorodott!";
                        }

                    }
                    if (helyiEllenfélSpell2Effekt == "Vérzés")
                    {
                        int vér = rnd.Next(1, 4);
                        if (vér == 3)
                        {
                            helyiKarakterVérzés = 2;
                            történésLabel.Content = $"{helyiEllenfélNév} megvágta {AlapAdatok.aktKarakterNév}-t és vérezni kezdett!";
                        }

                    }
                    if (helyiEllenfélSpell2Effekt == "Fagyás")
                    {
                        int fagy = rnd.Next(1, 4);
                        if (fagy == 3)
                        {
                            helyiKarakterFagyás = 1;
                            történésLabel.Content = $"{AlapAdatok.aktKarakterNév} lefagyott!";
                        }

                    }
                    KarakterJön();
                }
            }
            if (melyikSpell == 3)
            {
                if (helyiEllenfélSpell3Effekt == "Heal")
                {
                    int heal = rnd.Next(helyiEllenfélSpell3MinDMG, helyiEllenfélSpell3MaxDMG);
                    if (helyiEllenfélHP + heal > helyiEllenfélMaxHP)
                    {
                        heal = helyiEllenfélMaxHP - helyiEllenfélHP;
                    }
                    helyiKarakterHP += heal;
                    történésLabel.Content = $"{helyiEllenfélNév} használta a {helyiEllenfélSpell3Név}-t és {heal}-t gyógyult";

                    HPváltozott();
                    await Task.Delay(2000);
                    KarakterJön();
                }
                else
                {
                    int dmg = rnd.Next(helyiEllenfélSpell3MinDMG, helyiEllenfélSpell3MaxDMG);
                    helyiKarakterHP -= dmg + helyiEllenfélDMG;
                    történésLabel.Content = $"{helyiEllenfélNév} használta a(z) {helyiEllenfélSpell3Név}-t és {dmg + helyiEllenfélDMG}-t sebzett";
                    HPváltozott();
                    await Task.Delay(2000);
                    történésLabel.Content = "";
                    if (helyiEllenfélSpell3Effekt == "Tűz")
                    {
                        int tűz = rnd.Next(1, 4);
                        if (tűz == 3)
                        {
                            helyiKarakterTűz = 3;
                            történésLabel.Content = $"{AlapAdatok.aktKarakterNév} meggyulladt!";
                        }

                    }
                    if (helyiEllenfélSpell3Effekt == "Undorító")
                    {
                        int undor = rnd.Next(1, 4);
                        if (undor == 3)
                        {
                            helyiKarakterUndorító = 1;
                            történésLabel.Content = $"{AlapAdatok.aktKarakterNév} elundorodott!";
                        }

                    }
                    if (helyiEllenfélSpell3Effekt == "Vérzés")
                    {
                        int vér = rnd.Next(1, 4);
                        if (vér == 3)
                        {
                            helyiKarakterVérzés = 2;
                            történésLabel.Content = $"{helyiEllenfélNév} megvágta {AlapAdatok.aktKarakterNév}-t és vérezni kezdett!";
                        }

                    }
                    if (helyiEllenfélSpell3Effekt == "Fagyás")
                    {
                        int fagy = rnd.Next(1, 4);
                        if (fagy == 3)
                        {
                            helyiKarakterFagyás = 1;
                            történésLabel.Content = $"{AlapAdatok.aktKarakterNév} megfagyott!";
                        }

                    }
                    KarakterJön();
                }

            }
        }
        private async void KarakterJön()
        {
            await Task.Delay(2000);
            if (helyiKarakterTűz > 0 || helyiKarakterVérzés > 0 || helyiKarakterUndorító > 0 || helyiKarakterFagyás > 0)
            {
                bool karakterJön = true;
                if (helyiKarakterTűz > 0)
                {
                    int dmg = rnd.Next(5, 11);
                    történésLabel.Content = $"{AlapAdatok.aktKarakterNév} ég ezért {dmg}-t sebződött";
                    helyiKarakterTűz -= 1;
                    helyiKarakterHP -= dmg;
                    HPváltozott();
                    await Task.Delay(2000);
                    történésLabel.Content = "";
                }
                if (helyiKarakterVérzés > 0)
                {
                    int dmg = rnd.Next(5, 11);
                    történésLabel.Content = $"{AlapAdatok.aktKarakterNév} vérzik ezért {dmg}-t sebződött";
                    helyiKarakterVérzés -= 1;
                    helyiKarakterHP -= dmg;
                    HPváltozott();
                    await Task.Delay(2000);
                    történésLabel.Content = "";
                }
                if (helyiKarakterUndorító > 0)
                {
                    történésLabel.Content = $"{AlapAdatok.aktKarakterNév} behányt az undortól, ezért {helyiEllenfélNév} támad újra";
                    helyiKarakterUndorító -= 1;
                    await Task.Delay(2000);
                    történésLabel.Content = "";
                    karakterJön = false;

                }
                if (helyiKarakterFagyás > 0)
                {
                    történésLabel.Content = $"{AlapAdatok.aktKarakterNév} meg van fagyva, ezért {helyiEllenfélNév} támad újra";
                    helyiKarakterFagyás -= 1;
                    await Task.Delay(2000);
                    történésLabel.Content = "";
                    karakterJön = false;
                }
                if (helyiKarakterHP <= 0)
                {
                    HPváltozott();
                    await Task.Delay(2000);
                    Vesztés();
                }
                if (karakterJön == true)
                {
                    if (GeriHonor >= 3)
                    {
                        Spell1Gomb.IsEnabled = true;
                        Spell3Gomb.IsEnabled = true;
                    }
                    else
                    {
                        Spell1Gomb.IsEnabled = true;
                        Spell2Gomb.IsEnabled = true;
                        Spell3Gomb.IsEnabled = true;
                    }

                }
                if (karakterJön == false)
                {
                    EllenfélJön();
                }
            }
            else
            {
                if (helyiKarakterHP <= 0)
                {
                    HPváltozott();
                    await Task.Delay(2000);
                    Vesztés();
                }
                else
                {
                    if (GeriHonor >= 3)
                    {
                        Spell1Gomb.IsEnabled = true;
                        Spell3Gomb.IsEnabled = true;
                    }
                    else
                    {
                        Spell1Gomb.IsEnabled = true;
                        Spell2Gomb.IsEnabled = true;
                        Spell3Gomb.IsEnabled = true;
                    }
                }
            }


        }
        private async void Win()
        {
            történésLabel.Content = $"Legyőzted {helyiEllenfélNév}-t";
            await Task.Delay(2000);
            történésLabel.Content = $"";
            endScreen.Visibility = Visibility.Visible;
            await Task.Delay(2000);
            történésLabel.Visibility = Visibility.Visible;
            történésLabel.Content = "kimész a teremből";
            await Task.Delay(4000);
            RempiIroda t = new RempiIroda();
            t.Show();
            this.Close();
        }
        private async void Vesztés()
        {
            történésLabel.Content = $"Vesztettél!";
            await Task.Delay(4000);
            történésLabel.Content = $"";
            Lose t = new Lose();
            t.Show();
            this.Close();
        }

    }
}



