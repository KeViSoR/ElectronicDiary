using ElectronicDiary.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для GroupsList.xaml
    /// </summary>
    public partial class GroupsList : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public GroupsList(int groupId, SchoolDbContext context)
        {
            InitializeComponent();
            ThisGroup = context.Groups.FirstOrDefault(x => x.Id == groupId);
            GroupList.ItemsSource = context.SportsmensGroups.Where(x => x.GroupId == groupId).Select(x => x.Persons).ToList();
            GroupWindow.DataContext = this;
        }
        Person selPerson;
        public Person SelPerson
        {
            get => selPerson; set
            {
                selPerson = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelPerson)));
            }
        }
        Group thisGroup;
        public Group ThisGroup
        {
            get => thisGroup; set
            {
                thisGroup = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(thisGroup)));
            }
        }

        private void SignBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Когда-то потом");
        }
    }
}
