using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

namespace Desktop
{
    /// <summary>
    /// Interaction logic for Doctor.xaml
    /// </summary>
    public partial class Doctor : Page
    {
        DesktopssEntities1 db = new DesktopssEntities1();
        public Doctor()
        {
            InitializeComponent();
            Dg_name.ItemsSource=db.Patients.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Dg_name.ItemsSource = db.Patients.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Patient pat = new Patient();
            int idfromtxt = int .Parse(id_txt.Text);
            pat=db.Patients.FirstOrDefault(x=>x.id == idfromtxt);
            pat.Room_Number = int.Parse( Room_txt.Text);
            db.Patients.AddOrUpdate( pat );
            MessageBox.Show("Updated Succ");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Patient pat = new Patient();
            int idfromtxt = int.Parse(id_txt.Text);
            pat = db.Patients.FirstOrDefault(x => x.id == idfromtxt);
            db.Patients.Remove( pat );
            db.SaveChanges();
            MessageBox.Show("Record Deleted");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Searsh_txt.Text!="" && Room_txt.Text!="")
            {
                int add = int.Parse(Room_txt.Text);
                Dg_name.ItemsSource = db.Patients.Where(x => x.Fname.Contains(Searsh_txt.Text) && x.Room_Number == add).ToList();
            }
            else if (Room_txt.Text=="" && Searsh_txt.Text!="")
            {
                Dg_name.ItemsSource = db.Patients.Where(x => x.Fname.Contains(Searsh_txt.Text)).ToList();
            }
            else if (Room_txt.Text != "" && Searsh_txt.Text == "")
            {
                int add = int.Parse(Room_txt.Text);
                Dg_name.ItemsSource = db.Patients.Where(x => x.Room_Number==add).ToList(); 
            }
            else 
            {
                MessageBox.Show("Please Write The Name Of Person");
            }

        }
    }
}
