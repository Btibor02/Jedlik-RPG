using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adatok
{
    public static class AlapAdatok
    {
        public static string aktKarakterNév { get; set; }
        public static string aktKarakterForrás { get; set; }
        public static int alapHP { get; set; }
        public static int alapDMG { get; set; }
        public static string aktFegyver { get; set; }
        public static string aktPáncél { get; set; }
        public static string spell1Név { get; set; }
        public static string spell1Leírás { get; set; }
        public static int spell1MinDMG { get; set; }
        public static int spell1MaxDMG { get; set; }
        public static string spell1Effekt { get; set; }
        public static string spell2Név { get; set; }
        public static string spell2Leírás { get; set; }
        public static int spell2MinDMG { get; set; }
        public static int spell2MaxDMG { get; set; }
        public static string spell2Effekt { get; set; }
        public static string spell3Név { get; set; }
        public static string spell3Leírás { get; set; }
        public static int spell3MinDMG { get; set; }
        public static int spell3MaxDMG { get; set; }
        public static string spell3Effekt { get; set; }
    }
    public class Fegyver
    {
        public string Név { get; set; }
        public int DMG { get; set; }
        public string Leírás { get; set; }
        public Fegyver(string fegyversor)
        {
            string[] m = fegyversor.Split(';');
            Név = m[0];
            DMG = int.Parse(m[1]);
            Leírás = m[2];
        }


    }
    public class Páncél
    {
        public string Név { get; set; }
        public int HP { get; set; }
        public string Leírás { get; set; }
        public Páncél(string páncélsor)
        {
            string[] m = páncélsor.Split(';');
            Név = m[0];
            HP = int.Parse(m[1]);
            Leírás = m[2];
        }

    }
}
