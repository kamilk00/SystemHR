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
    public partial class AddContractWindow : Window
    {

        private AdminMainWindow _admin;
        private Worker _worker;

        public AddContractWindow(AdminMainWindow adminWindow, Worker worker)
        {

            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //saving inputs in memory
            _admin = adminWindow;
            _worker = worker;
            name.Text = worker.Name;
            name.IsEnabled = false;
                        
        }

        //adding new contract
        private void addButton_Click(object sender, RoutedEventArgs e)
        {

            //checking if all required field are filled
            if (typeOfContract.SelectedItem == null || startOfContract.Text == ""
                || endOfContract.Text == "")
                MessageBox.Show("Fill in all required fields!", "Add Contract Error",
                                MessageBoxButton.OK, MessageBoxImage.Error);

            //checking if salary is lower than 22.80 zl/h 
            else if (Salary.Value < 22.80)
                MessageBox.Show("Salary cannot be lower than 22.80!", "Add Contract Error",
                                MessageBoxButton.OK, MessageBoxImage.Error);

            else
            {

                HRDBContext context = new HRDBContext();

                //checking if worker has valid contract
                if (_worker.ContractID != null)
                {

                    var contract = context.Contracts.First(
                        contr => contr.ContractID == _worker.ContractID);
                    
                    contract.EndOfContract = startOfContract.Text;

                    try
                    {

                        //saving new contract
                        context.Contracts.Add(new Contract
                        {
                            ContractID = context.Contracts.Max(contr => contr.ContractID) + 1,
                            Name = name.Text,
                            StartOfContract = startOfContract.Text,
                            EndOfContract = endOfContract.Text,
                            Salary = (float)Salary.Value,
                            TypeOfContract = typeOfContract.Text
                        });

                        var worker = context.Workers.First(
                           wrk => wrk.ContractID == _worker.ContractID);
                        worker.ContractID = context.Contracts.Max(contr => contr.ContractID) + 1;
                        worker.StartOfContract = startOfContract.Text;
                        worker.EndOfContract = endOfContract.Text;
                        worker.Salary = (float)Salary.Value;
                        worker.TypeOfContract = typeOfContract.Text;
                        context.SaveChanges();
                        MessageBox.Show("Successfully added!", "Add Contract Success",
                                        MessageBoxButton.OK, MessageBoxImage.Information);

                    }

                    catch
                    {

                        MessageBox.Show("Error occured during saving data!", "Add Contract Error",
                                        MessageBoxButton.OK, MessageBoxImage.Error);

                    }

                }

                else
                {

                    int ID;

                    if (context.Contracts.Count() < 1)
                        ID = 1;

                    else
                        ID = context.Contracts.Max(contr => contr.ContractID) + 1;

                    try
                    {

                        //saving a contract
                        context.Contracts.Add(new Contract
                        {
                            ContractID = ID,
                            Name = name.Text,
                            StartOfContract = startOfContract.Text,
                            EndOfContract = endOfContract.Text,
                            Salary = (float)Salary.Value,
                            TypeOfContract = typeOfContract.Text
                        });

                        var worker = context.Workers.First(
                            wrk => wrk.WorkerID == _worker.WorkerID);

                        worker.ContractID = ID;
                        worker.StartOfContract = startOfContract.Text;
                        worker.EndOfContract = endOfContract.Text;
                        worker.Salary = (float)Salary.Value;
                        worker.TypeOfContract = typeOfContract.Text;

                        context.SaveChanges();

                        MessageBox.Show("Successfully added!", "Add Contract Success",
                                        MessageBoxButton.OK, MessageBoxImage.Information);

                    }

                    catch
                    {

                        MessageBox.Show("Error occured during saving data!", "Add Contract Error",
                                        MessageBoxButton.OK, MessageBoxImage.Error);

                    }


                }

                _admin.Show();
                this.Close();

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
