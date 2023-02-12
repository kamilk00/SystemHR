using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {

            //if login or password is null
            if (login.Text == "" || password.Password == "")
                MessageBox.Show("Fill in all required fields!", "Login Error", 
                MessageBoxButton.OK, MessageBoxImage.Error);


            else
            {

                try
                {

                    //searching for username
                    HRDBContext context = new HRDBContext();
                    var isUserFound = context.Logins.Any(user => user.Login == login.Text);

                    //user not found
                    if (!isUserFound)
                        MessageBox.Show("User not found!", "Login Error", MessageBoxButton.OK,
                        MessageBoxImage.Error);

                    else
                    {
                        
                        //checking if the entered password is correct
                        var loginUser = context.Logins.FirstOrDefault(user => user.Login == login.Text);
                        HashPassword hash = new HashPassword($"{password.Password}{loginUser.Salt}");

                        //password is incorrect
                        if (hash.hashedPassword != loginUser.Password)
                            MessageBox.Show("Incorrect password!", "Login Error", MessageBoxButton.OK,
                            MessageBoxImage.Error);

                        //password is correct - admin
                        else if (loginUser.WorkerID < 1)
                        {

                            AdminMainWindow admin = new AdminMainWindow(loginUser.Login, this);
                            admin.Show();
                            this.Hide();
                            login.Text = "";
                            password.Password = "";

                        }

                        //password is correct - worker
                        else
                        {

                            WorkerMainWindow worker = new WorkerMainWindow(loginUser.Login, this);
                            worker.Show();
                            this.Hide();
                            login.Text = "";
                            password.Password = "";

                        }

                    }

                }

                catch
                {

                    MessageBox.Show("Error establishing a database connection!", "Login Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);

                }

            }

        }

    }

}
