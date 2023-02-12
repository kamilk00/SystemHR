using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Threading;
using System.Xml.Linq;
using LoginDBContext;

namespace SystemHR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {

        private MainWindow window;
        DispatcherTimer timer = new DispatcherTimer();
        bool contractsView;

        public AdminMainWindow(string login, MainWindow mainWindow)
        {

            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //saving inputs in memory
            userLabel.Content = login;
            window = mainWindow;
            showAllEmployees();
            timer.Interval = TimeSpan.FromSeconds(60);
            timer.Tick += Timer_Tick;
            timer.Start();
            contractsView = false;

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

        //adding new employee
        private void addEmployeeButton_Click(object sender, RoutedEventArgs e)
        {

            AddEmployeeWindow addEmployeeWindow = new AddEmployeeWindow(this);
            addEmployeeWindow.Show();
            this.Hide();

        }

        //showing all employees
        private void showAllEmployees()
        {

            HRDBContext context = new HRDBContext();
            dataGrid.ItemsSource = context.Workers.OrderBy(worker => worker.WorkerID).ToList();

        }

        //show all contracts
        private void showAllContracts()
        {

            HRDBContext context = new HRDBContext();
            dataGrid.ItemsSource = context.Contracts.OrderBy(worker => worker.Name).ToList();

        }

        //searching by name
        private void searchButton_Click(object sender, RoutedEventArgs e)
        {

            HRDBContext context = new HRDBContext();
            if (search.Text.Length > 0 && !contractsView)
                dataGrid.ItemsSource = context.Workers.Select(worker => worker.Name.Contains(search.Text));

            else if (search.Text.Length > 0)
                dataGrid.ItemsSource = context.Contracts.Select(contract => contract.Name.Contains(search.Text));

        }

        //refreshing on timer tick
        private void Timer_Tick(object sender, EventArgs e)
        {

            refresh();

        }

        //change view to employees
        private void employeesButton_Click(object sender, RoutedEventArgs e)
        {

            contractsView = false;
            refresh();

        }

        //change view to contracts
        private void contractsButton_Click(object sender, RoutedEventArgs e)
        {

            contractsView = true;
            refresh();

        }

        //remove an employee
        private void removeEmployeeButton_Click(object sender, RoutedEventArgs e)
        {

            //if employee is selected and window is in employee view
            if (!contractsView && dataGrid.SelectedItem != null)
            {

                Worker worker = dataGrid.SelectedItem as Worker;
                HRDBContext context = new HRDBContext();
                User user = context.Logins.First(usr => usr.WorkerID == worker.WorkerID);

                //worker cannot have valid contract
                if (worker.ContractID != null)
                    MessageBox.Show("This employee has valid contract!", "Remove Employee Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);

                else
                {

                    //submiting a removal of employee from tables: Logins and Workers
                    if (MessageBox.Show("Are you sure to remove?", "Remove Employee", MessageBoxButton.YesNo,
                        MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {

                        context.Workers.Remove(worker);
                        context.Logins.Remove(user);
                        context.SaveChanges();
                        MessageBox.Show("Successfully removed!", "Remove Employee Success",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                        refresh();

                    }

                }
            
            }

        }

        //adding new contract
        private void addContractButton_Click(object sender, RoutedEventArgs e)
        {

            //if window is in employee view and employee is selected
            if (!contractsView && dataGrid.SelectedItem != null)
            {

                Worker worker = dataGrid.SelectedItem as Worker;
                AddContractWindow addContractWindow = new AddContractWindow(this, worker);
                addContractWindow.Show();
                this.Hide();

            }

        }

        //ending a contract
        private void endContractButton_Click(object sender, RoutedEventArgs e)
        {

            //if window is in contract view and employee is selected
            if (contractsView && dataGrid.SelectedItem != null)
            {

                Contract contract = dataGrid.SelectedItem as Contract;
                HRDBContext context = new HRDBContext();

                var isContractValid = context.Workers.Any(wrk => wrk.ContractID == contract.ContractID);

                //if contract is valid
                if (isContractValid)
                {

                    if (MessageBox.Show("Are you sure to end contract?", "End Contract", MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        try
                        {

                            string date = DateTime.Now.ToString("dd-MM-yyyy");
                            var worker = context.Workers.First(
                                wrk => wrk.ContractID == contract.ContractID);
                            var contr = context.Contracts.First(
                                ctr => ctr.ContractID == contract.ContractID);
                            worker.ContractID = null;
                            worker.StartOfContract = null;
                            worker.EndOfContract = null;
                            worker.Salary = null;
                            contr.EndOfContract = date;

                            context.SaveChanges();
                            MessageBox.Show("Successfully ended!", "End Contract Success",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                            refresh();

                        }

                        catch
                        {

                            MessageBox.Show("Error occured during saving data!", "End Contract Error",
                            MessageBoxButton.OK, MessageBoxImage.Error);

                        }


                    }

                    else
                    {

                        MessageBox.Show("This contract isn't valid!", "End Contract Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);

                    }

                }

            }

        }

        //refresh datagrid
        private void refresh()
        {

            if (!contractsView)
                showAllEmployees();

            else
                showAllContracts();

        }

        //refresh datagrid on demand
        private void refreshButton_Click(object sender, RoutedEventArgs e)
        {

            refresh();

        }

        //changing a password
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