using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _4Game.Pages
{
    /// <summary>
    /// Interaction logic for MainSurface.xaml
    /// </summary>
    public partial class MainSurface : UserControl
    {
        public static bool maxValueButtonClick = true;
        //internal _4GameLogic table;
        internal Player player1;
        internal Player player2;
        internal Player player3;
        internal Player player4;
        private const int MAXVALUE = 4;
        private int maxScore;
        private int fontSize;
        public byte row, column;

        public MainSurface()
        {
            InitializeComponent();
            this.Resources.MergedDictionaries.Add(Globalization.SetLanguage());
        }

    }
}
