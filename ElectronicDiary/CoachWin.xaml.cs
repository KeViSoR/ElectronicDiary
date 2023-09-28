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
using System.Windows.Shapes;

namespace ElectronicDiary
{
    /// <summary>
    /// Логика взаимодействия для CoachWin.xaml
    /// </summary>
    public partial class CoachWin : Window
    {
        public CoachWin()
        {
            InitializeComponent();
        }

        //Пример того, как заполнять ListBox из бд !!!!!!!!!!!!

        //public void FillList()
        //{
        //    using (GameAppContext db = new GameAppContext())
        //    {
        //        var games = db.Games.Include(g => g.Studios).Include(g => g.Styles).ToList();
        //        IList<Games> co1 = new List<Games>();
        //        foreach (var game in games)
        //        {
        //            co1.Add(new Games
        //            {
        //                GameName = game.GameName,
        //                Studios = game.Studios,
        //                Styles = game.Styles,
        //                imgPath = game.imgPath,
        //                Size = game.Size,
        //                Cost = game.Cost,
        //                DateRealese = game.DateRealese
        //            });
        //        }
        //        GamesList.ItemsSource = co1;
        //    }
        //}

        private void SearchGroup_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SignBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
