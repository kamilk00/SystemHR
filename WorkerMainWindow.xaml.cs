using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Sockets;
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
using System.Windows.Threading;
using System.Xml.Linq;
using LoginDBContext;

namespace SystemHR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WorkerMainWindow : Window
    {

        private MainWindow window;
        //timer declaration
        DispatcherTimer timer = new DispatcherTimer();

        public WorkerMainWindow(string login, MainWindow mainWindow)
        {

            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //saving inputs in memory
            userLabel.Content = login;
            window = mainWindow;

            dataGrid.IsReadOnly = true;
            showAllEmployees();
            timer.Interval = TimeSpan.FromSeconds(60);
            timer.Tick += Timer_Tick;
            timer.Start();

        }

        //logout
        private void logoutButton_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Are you sure to logout?", "Logout", MessageBoxButton.YesNo,
            MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                
                window.Show();
                this.Close();

            }

        }

        //showing all employees (only ID, Name and Phone)
        private void showAllEmployees()
        {

            HRDBContext context = new HRDBContext();
            dataGrid.ItemsSource = context.Workers.ToList().Select(worker => new{ worker.WorkerID, worker.Name, worker.Phone});

        }

        //refreshing datagrid
        private void Timer_Tick(object sender, EventArgs e)
        {

            showAllEmployees();

        }

        //refreshing datagrid on demand
        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {

            showAllEmployees();

        }

        //opening change data window
        private void changeDataButton_Click(object sender, RoutedEventArgs e)
        {

            HRDBContext context = new HRDBContext();
            var login = context.Logins.First(user => user.Login == userLabel.Content);
            var worker = context.Workers.First(wrk => wrk.WorkerID == login.WorkerID);
            ChangeDataWindow changeDataWindow = new ChangeDataWindow(this, worker);
            changeDataWindow.Show();
            this.Hide();

        }

        //opening change password window
        private void changePasswordButton_Click(object sender, RoutedEventArgs e)
        {

            HRDBContext context = new HRDBContext();
            var login = context.Logins.First(user => user.Login == userLabel.Content);
            ChangePasswordWindow changePasswordWindow = new ChangePasswordWindow(this, login);
            changePasswordWindow.Show();
            this.Hide();

        }

    }

}