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
using LoginDBContext;

namespace SystemHR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {

        private AdminMainWindow _admin;
        public AddEmployeeWindow(AdminMainWindow adminWindow)
        {

            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //saving input in memory
            _admin = adminWindow;
                        
        }


        //adding a new employee
        private void addButton_Click(object sender, RoutedEventArgs e)
        {

            //checking if all required fields are filled
            if (typeOfAccount.SelectedItem == null || name.Text == "" || dateOfBirth.Text == ""
                || pesel.Text == "" || bankAccountNumber.Text == "" || address.Text == ""
                || phone.Text == "" || login.Text == "" || password.Password == "")
                MessageBox.Show("Fill in all required fields!", "Add Employee Error",
                MessageBoxButton.OK, MessageBoxImage.Error);

            else
            {

                HRDBContext context = new HRDBContext();
                var isUserFound = context.Logins.Any(user => user.Login == login.Text) |
                    context.Workers.Any(worker => worker.PESEL == pesel.Text);

                //checking if new account exists
                if (isUserFound)
                    MessageBox.Show("This account already exists!", "Add Employee Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);

                else
                {

                    int id;

                    //creating ID
                    if (typeOfAccount.SelectedItem == adminCombo)
                        id = context.Logins.Min(user => user.WorkerID) - 1;
                    
                    else
                        id = context.Logins.Max(user => user.WorkerID) + 1;

                    //preparing salt and hashed password
                    var salt = DateTime.Now.ToString();
                    HashPassword hashed = new HashPassword($"{password.Password}{salt}");

                    try
                    {

                        //updating "Logins" Table
                        context.Logins.Add(new User
                        {
                            WorkerID = id,
                            Login = login.Text,
                            Password = hashed.hashedPassword,
                            Salt = salt
                        });

                        //updating "Workers" Table
                        context.Workers.Add(new Worker
                        {
                            WorkerID = id,
                            Name = name.Text,
                            Address = address.Text,
                            BankAccountNumber = bankAccountNumber.Text,
                            DateOfBirth = dateOfBirth.Text,
                            PESEL = pesel.Text,
                            Phone = phone.Text
                        });

                        //saving changes in database
                        context.SaveChanges();

                        MessageBox.Show("Successfully added!", "Add Employee Success",
                        MessageBoxButton.OK, MessageBoxImage.Information);

                    }

                    catch
                    {

                        MessageBox.Show("Error occured during saving data!", "Add Employee Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);

                    }

                    _admin.Show();
                    this.Close();

                }

            }

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Are you sure to cancel?", "Cancel", MessageBoxButton.YesNo,
            MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                _admin.Show();
                this.Close();

            }

        }

    }

}
