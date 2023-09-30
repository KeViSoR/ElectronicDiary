using ElectronicDiary.Entity;
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
        SchoolDbContext context = new SchoolDbContext("Data Source=DESKTOP-1AUEF7A\\SQLEXPRESS;Initial Catalog=SportSchoolVer4DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        public Department SelDepartament { get; set; }
        public Person SelTrainer { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            UpdateSportList();
        }

        private void SignBtn_Click(object sender, RoutedEventArgs e)
        { }
        private void UpdateSportList()
        {
            SportList.ItemsSource = context.Departments.ToList();
        }



        private void SportList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelDepartament = SportList.SelectedItem as Department;
            //CoachList.ItemsSource = context.Groups.Where(z => z.DepartmentId == SelDepartament.Id).Select(y => y.Trainer).ToList();
            CoachList.ItemsSource = context.Groups.Where(x => x.DepartmentId == SelDepartament.Id).Select(x => x.Trainer).Distinct().ToList();
        }

        private void CoachList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<CategoryGroupTrainer> listsg = new List<CategoryGroupTrainer> { };
            List<Group> sGroup = context.Groups.ToList();
            //InitialGroup.ItemsSource;
            SelTrainer = CoachList.SelectedItem as Person;
            if (SelTrainer is null) return;
            List<Stage>? listStage = context.Groups.Where(x => x.TrainerId == SelTrainer.Id).Select(st => st.Stage).Distinct().ToList();
            List<SportsmensGroup> listSportsmensGroup = context.SportsmensGroups.ToList();
            if (listStage is null) return;
            foreach (var Stage in listStage)
            {
                listsg.Add(new CategoryGroupTrainer(Stage, SelTrainer.Id, sGroup, listSportsmensGroup));
            }
            TrainerList.ItemsSource = listsg;
        }
    }
}
