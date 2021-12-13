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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CheckDbBtn.Click += OnCheckDbClicked;
            reg_btn.Click += OnRegisterClicked;
            CheckAge.Click += OnCheckClicked;
        }

        private void OnCheckClicked(object sender, RoutedEventArgs e)
        {
            var loginToCheck = log_to_ch.Text;
            using var db = new UsersContext();
            var userModel = db.Users.FirstOrDefault(us => us.Login == loginToCheck);
            if (userModel != null)
            {
                var humId = userModel.Human_id;
                var human = db.Humans.FirstOrDefault(hum => hum.Id == humId);
                if (human != null)
                {
                    MessageBox.Show($"login:{userModel.Login}, name:{human.Name}, age:{human.Age}");
                }
            }
        }

        private void OnCheckDbClicked(object sender, RoutedEventArgs e)
        {
            using var db = new UsersContext();
            // Read
            var users = db.Users.ToArray();
            var names = users.Select(u => u.Login).ToArray();
            MessageBox.Show(String.Join(", ", names));
        }

        private void OnRegisterClicked(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(loginTxt.Text) || String.IsNullOrEmpty(pass1Txt.Password) || String.IsNullOrEmpty(pass2Txt.Password) || pass1Txt.Password != pass2Txt.Password)
            {
                MessageBox.Show("WRONG DATA!!");
                return;
            }
            using var db = new UsersContext();
            // Update
            var users = db.Users;
            users.Add(new User() { Login = loginTxt.Text, Pass = pass1Txt.Password });
            db.SaveChanges();
        }
    }
}
