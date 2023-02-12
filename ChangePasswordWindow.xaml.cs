using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
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
using LoginDBContext;

namespace SystemHR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {

        private WorkerMainWindow _workerWindow;
        private AdminMainWindow _adminWindow;
        private User _user;

        public ChangePasswordWindow(WorkerMainWindow workerWindow, User user)
        {

            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //saving inputs in memory
            _workerWindow = workerWindow;
            _user = user;
                        
        }

        public ChangePasswordWindow(AdminMainWindow adminWindow, User user)
        {

            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //saving inputs in memory
            _adminWindow = adminWindow;
            _user = user;

        }

        private void changeButton_Click(object sender, RoutedEventArgs e)
        {

            //if password is null
            if (password.Password != "" && newPassword.Password != "")
            {

                //checking if the entered password is correct
                HashPassword hash = new HashPassword($"{password.Password}{_user.Salt}");

                //password is incorrect
                if (hash.hashedPassword != _user.Password)
                    MessageBox.Show("Incorrect password!", "Login Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);

                else
                {

                    //submiting a change of password
                    if (MessageBox.Show("Are you sure to edit your personal data?", "Edit Data", MessageBoxButton.YesNo,
                        MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {

                        try
                        {

                            //creating a salt and new hashed password
                            var salt = DateTime.Now.ToString();
                            HashPassword hashedNew = new HashPassword($"{newPassword.Password}{salt}");
                            
                            //saving new password and salt in database
                            HRDBContext context = new HRDBContext();
                            var usr = context.Logins.First(u => u.WorkerID == _user.WorkerID);

                            usr.Salt = salt;
                            usr.Password = hashedNew.hashedPassword;
                            context.SaveChanges();

                            MessageBox.Show("Successfully changed!", "Edit Password Success",
                                            MessageBoxButton.OK, MessageBoxImage.Information);

                            if (_workerWindow!= null)
                                _workerWindow.Show();
                            
                            else if (_adminWindow != null)
                                _adminWindow.Show();

                            this.Close();

                        }

                        catch
                        {

                            MessageBox.Show("Error occured during saving data!", "Edit Data Error",
                                            MessageBoxButton.OK, MessageBoxImage.Error);

                        }

                    }

                }

            }

            else
            {

                MessageBox.Show("Fill in all required fields!", "Edit Password Error",
                                MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Are you sure to cancel?", "Cancel", MessageBoxButton.YesNo,
            MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                _workerWindow.Show();
                this.Close();

            }

        }

    }

}
