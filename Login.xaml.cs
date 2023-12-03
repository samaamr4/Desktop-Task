﻿using System;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        DesktopssEntities1 db =new DesktopssEntities1();
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Comb_name.Text == "Doctor")
            {
                Doctor_Log doc = new Doctor_Log();
                doc = db.Doctor_Log.FirstOrDefault(x => x.User_namee == userN_txt.Text);
                if (doc.Passwordd == pass_txt.Text)
                {
                    Doctor dc = new Doctor();
                    this.NavigationService.Navigate(dc);
                }
                else if(doc.Passwordd!= pass_txt.Text)
                    MessageBox.Show("Invalide please write  password correct");
            }
            else if (Comb_name.Text == "Patient")
            {
                patients_log pat = new patients_log();
                pat = db.patients_log.FirstOrDefault(x => x.user_name_pat == userN_txt.Text);
                if (pat.password_pat == pass_txt.Text)
                {
                    Patient patient = new Patient();
                    this.NavigationService.Navigate(patient);
                }
               
                else if(pat.password_pat != pass_txt.Text)
                    MessageBox.Show("Invalide please write  password correct");
            }
            else
                MessageBox.Show("Please Choose Doctor Or Patient");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Comb_name.Text == "Doctor")
            {
                Sign_Up sign_Up = new Sign_Up();
                this.NavigationService.Navigate(sign_Up);
            }
            else if (Comb_name.Text == "Patient")
            {
                Sign_Up sign_Up = new Sign_Up();
                this.NavigationService.Navigate(sign_Up);
            }
            else
                MessageBox.Show("Please Choose Doctor Or Patient");
          
        }
    }
}
