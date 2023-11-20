using System.Windows;
using Adatok;
using Jedlik_RPG;

namespace KarakterV
{
    public partial class Karakterválasztó : Window
    {
        public Karakterválasztó()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void TibiGomb_Click(object sender, RoutedEventArgs e)
        {
            AlapAdatok.aktKarakterNév = "Tibi";
            AlapAdatok.aktKarakterForrás = "Képek/tibi.png";
            AlapAdatok.alapHP = 540;
            AlapAdatok.alapDMG = 19;
            AlapAdatok.aktFegyver = "Szlovák történelem zsebkönyve";
            AlapAdatok.aktPáncél = "MP4 gázmaszk";
            AlapAdatok.spell1Név = "Szlovák beszéd";
            AlapAdatok.spell1Leírás = "Ettől minden magyar fél";
            AlapAdatok.spell1MinDMG = 25;
            AlapAdatok.spell1MaxDMG = 30;
            AlapAdatok.spell1Effekt = "semmi";
            AlapAdatok.spell2Név = "Eső";
            AlapAdatok.spell2Leírás = "Valójában csak magasról rádköp";
            AlapAdatok.spell2MinDMG = 12;
            AlapAdatok.spell2MaxDMG = 15;
            AlapAdatok.spell2Effekt = "Undorító";
            AlapAdatok.spell3Név = "Légpisztoly lövés";
            AlapAdatok.spell3Leírás = "Szemen lövi ellenfelét";
            AlapAdatok.spell3MinDMG = 15;
            AlapAdatok.spell3MaxDMG = 19;
            AlapAdatok.spell3Effekt = "Vérzés";
            Választ1 v = new Választ1();
            v.Show();
            this.Close();
        }

        private void PatrikGomb_Click(object sender, RoutedEventArgs e)
        {
            AlapAdatok.aktKarakterNév = "Patrik";
            AlapAdatok.aktKarakterForrás = "Képek/patrik.png";
            AlapAdatok.alapHP = 500;
            AlapAdatok.alapDMG = 21;
            AlapAdatok.aktFegyver = "Forma 1-es makett autó";
            AlapAdatok.aktPáncél = "Összefonott viking haj";
            AlapAdatok.spell1Név = "Rúgás";
            AlapAdatok.spell1Leírás = "A vér úgyse látszik a piros cipőjén";
            AlapAdatok.spell1MinDMG = 29;
            AlapAdatok.spell1MaxDMG = 32;
            AlapAdatok.spell1Effekt = "semmi";
            AlapAdatok.spell2Név = "Forma 1";
            AlapAdatok.spell2Leírás = "Férfiasabbnak érzi magát tőle, de a rage-től égni kezd";
            AlapAdatok.spell2MinDMG = 10;
            AlapAdatok.spell2MaxDMG = 12;
            AlapAdatok.spell2Effekt = "DmgUp";
            AlapAdatok.spell3Név = "Haj ostor";
            AlapAdatok.spell3Leírás = "Gyönyörű lobonca akár véreztetésre is képes";
            AlapAdatok.spell3MinDMG = 14;
            AlapAdatok.spell3MaxDMG = 18;
            AlapAdatok.spell3Effekt = "Vérzés";
            Választ1 v = new Választ1();
            v.Show();
            this.Close();
        }

        private void GeriGomb_Click(object sender, RoutedEventArgs e)
        {
            AlapAdatok.aktKarakterNév = "Geri";
            AlapAdatok.aktKarakterForrás = "Képek/geri.png";
            AlapAdatok.alapHP = 520;
            AlapAdatok.alapDMG = 20;
            AlapAdatok.aktFegyver = "Üres kávés pohár";
            AlapAdatok.aktPáncél = "Corsair headset";
            AlapAdatok.spell1Név = "Picsapacsi";
            AlapAdatok.spell1Leírás = "Kollégiumban töltött idők alatt kifejlesztett technika";
            AlapAdatok.spell1MinDMG = 20;
            AlapAdatok.spell1MaxDMG = 50;
            AlapAdatok.spell1Effekt = "semmi";
            AlapAdatok.spell2Név = "For honor";
            AlapAdatok.spell2Leírás = "Kétélű penge: a győzelmektől sebzése nő, de a rage miatt lángra lobban. (Max 3-szor használtható)";
            AlapAdatok.spell2MinDMG = 10;
            AlapAdatok.spell2MaxDMG = 12;
            AlapAdatok.spell2Effekt = "DmgUp";
            AlapAdatok.spell3Név = "Kávé";
            AlapAdatok.spell3Leírás = "Automatás kávé, amit sokak számára undorító gyorsasággal húz le";
            AlapAdatok.spell3MinDMG = 45;
            AlapAdatok.spell3MaxDMG = 60;
            AlapAdatok.spell3Effekt = "GeriHeal";
            Választ1 v = new Választ1();
            v.Show();
            this.Close();
        }

        private void FoniGomb_Click(object sender, RoutedEventArgs e)
        {
            AlapAdatok.aktKarakterNév = "Foni";
            AlapAdatok.aktKarakterForrás = "Képek/foni.png";
            AlapAdatok.alapHP = 440;
            AlapAdatok.alapDMG = 27;
            AlapAdatok.aktFegyver = "Megkeményedett zokni";
            AlapAdatok.aktPáncél = "Kosaras cipő";
            AlapAdatok.spell1Név = "Ugrásütés";
            AlapAdatok.spell1Leírás = "A mortal kombatból jól ismert ugrás + ütés kombó";
            AlapAdatok.spell1MinDMG = 20;
            AlapAdatok.spell1MaxDMG = 25;
            AlapAdatok.spell1Effekt = "semmi";
            AlapAdatok.spell2Név = "Ásítás";
            AlapAdatok.spell2Leírás = "Hatalmas, nyitott szájú ásítás, kis eséllyel elundorodik tőle az ellenfél";
            AlapAdatok.spell2MinDMG = 13;
            AlapAdatok.spell2MaxDMG = 18;
            AlapAdatok.spell2Effekt = "Undorító";
            AlapAdatok.spell3Név = "Slam dunk";
            AlapAdatok.spell3Leírás = "Hatalmas zsákolás, lehet hogy lángra lobbantja az ellenfelet";
            AlapAdatok.spell3MinDMG = 15;
            AlapAdatok.spell3MaxDMG = 20;
            AlapAdatok.spell3Effekt = "Tűz";
            Választ1 v = new Választ1();
            v.Show();
            this.Close();
        }
    }
}
