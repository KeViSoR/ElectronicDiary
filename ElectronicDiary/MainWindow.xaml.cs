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

namespace ElectronicDiary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SchoolDbContext context = new SchoolDbContext("Data Source=LAPTOP-PI8KR3G6\\SQLEXPRESS;Initial Catalog=SportSchoolVer4DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        public Department SelDepartament { get; set; }
        public Person SelTrainer { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
