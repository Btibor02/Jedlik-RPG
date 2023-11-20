using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.IO;
using Adatok;
using IntroAblak;

namespace Jedlik_RPG
{
    public partial class MainWindow : Window
    {
        public static List<Fegyver> Fegyverek;
        public static List<Páncél> Páncélok;
        public static bool KulcsNálad = false;
        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            FegyverFeltölt();
            PáncélFeltölt();
        }
        public void FegyverFeltölt()
        {
            Fegyverek = new List<Fegyver>();
            foreach (var fegyversor in File.ReadAllLines("../../fegyverek.txt").Skip(1))
            {
                Fegyverek.Add(new Fegyver(fegyversor));
            }
        }
        public void PáncélFeltölt()
        {
            Páncélok = new List<Páncél>();
            foreach (var páncélsor in File.ReadAllLines("../../pancelok.txt").Skip(1))
            {
                Páncélok.Add(new Páncél(páncélsor));
            }
        }

        private void StartGomb_Click(object sender, RoutedEventArgs e)
        {
            Intro i = new Intro();
            i.Show();
            this.Close();
        }
    }
}
