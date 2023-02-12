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
    public partial class ChangeDataWindow : Window
    {

        private WorkerMainWindow _workerWindow;
        private Worker _worker;

        public ChangeDataWindow(WorkerMainWindow workerWindow, Worker worker)
        {

            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //saving inputs in memory
            _workerWindow = workerWindow;
            _worker = worker;
            name.Text = worker.Name;
            name.IsEnabled = false;
            address.Text = worker.Address;
            bankAccountNumber.Text = worker.BankAccountNumber;
            phone.Text = worker.Phone;
                        
        }

        private void changeButton_Click(object sender, RoutedEventArgs e)
        {

            //checking if all required fields are filled
            if (address.Text != "" && bankAccountNumber.Text != "" && phone.Text != "")
            {

                //submiting a change of data
                if (MessageBox.Show("Are you sure to edit your personal data?", "Edit Data", MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {

                    try
                    {

                        //saving updated data
                        HRDBContext context = new HRDBContext();
                        var worker = context.Workers.First(wrk => wrk.WorkerID == _worker.WorkerID);

                        worker.Address = address.Text;
                        worker.BankAccountNumber = bankAccountNumber.Text;
                        worker.Phone = phone.Text;

                        context.SaveChanges();
                        MessageBox.Show("Successfully updated!", "Edit Personal Data Success",
                                        MessageBoxButton.OK, MessageBoxImage.Information);

                        _workerWindow.Show();
                        this.Close();

                    }

                    catch
                    {

                        MessageBox.Show("Error occured during saving data!", "Edit Data Error",
                                        MessageBoxButton.OK, MessageBoxImage.Error);

                    }

                }

                else
                {

                    MessageBox.Show("Fill in all required fields!", "Edit Data Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);

                }
            
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
