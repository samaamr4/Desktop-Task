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

namespace Desktop
{
    /// <summary>
    /// Interaction logic for Sign_Up.xaml
    /// </summary>
    public partial class Sign_Up : Page
    {
        DesktopssEntities1 db = new DesktopssEntities1();
        public Sign_Up()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IsValid(pass_txt.Text))
            {
                if (Com_name.Text=="Doctor")
                {
                    Doctor_Log doc = new Doctor_Log();
                    doc.User_namee = userN_txt.Text;
                    doc.Passwordd = pass_txt.Text;
                    Conf_txt.Text = pass_txt.Text;
                    db.Doctor_Log.Add(doc);
                    db.SaveChanges();
                    MessageBox.Show("Doctor Added Succ");
                }
                else if (Com_name.Text == "Patient")
                {
                    patients_log pa = new patients_log();
                    pa.user_name_pat = userN_txt.Text;
                    pa.password_pat = pass_txt.Text;
                    if (Conf_txt.Text!=pass_txt.Text)
                    {
                        MessageBox.Show("Please enter the password Againe");
                    }
                    else
                    {
                        db.patients_log.Add(pa);
                        db.SaveChanges();
                        MessageBox.Show("Patient Added Succ");
                    }
                    
                }
              
            }
            else
                MessageBox.Show("The Name Should Be Contain (Uppercase , LowerCase , Number , Spatiel Character ");
            
        }
        bool IsValid(String Pass)
        {
            bool upper, lower, num, sympole;
            upper = lower = num = sympole = false;
            string spatiel = "!@#$%^&*()";
            foreach(char c in Pass)
            {
                if (c >= 'A' && c<='Z' )
                {
                    upper= true;
                }
                else if (c>='a' && c<='z')
                {
                    lower= true;
                }
                else if (c>='0' && c<='9')
                {
                    num = true;
                }
                else if (spatiel.Contains(c))
                {
                    sympole= true;
                } 
            }
            return upper && lower && num &&sympole;
        }
    }
}
