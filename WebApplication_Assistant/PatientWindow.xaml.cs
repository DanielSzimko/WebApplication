using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WebApplication_Assistant.DataProviders;
using WebApplication_Server.Models;

namespace WebApplication_Assistant
{
    /// <summary>
    /// Interaction logic for PatientWindow.xaml
    /// </summary>
    public partial class PatientWindow : Window


    {

        public PatientWindow()
        {
            InitializeComponent();
        }


        private void AddPatientButton_Click(object sender, RoutedEventArgs e)
        {
            Patient _Patient = new Patient();
            if (ValidatePatient())
            {
                _Patient.Name = NameTextBox.Text;
                _Patient.Address = AddressTextBox.Text;
                _Patient.TAJNumber = TAJNumberTextBox.Text;
                _Patient.Complaint = ComplaintTextBox.Text;
                _Patient.AddedDate = DateTime.Now;

                PatientDataProvider.CreatePatient(_Patient);

                NameTextBox.Text = "";
                AddressTextBox.Text = "";
                TAJNumberTextBox.Text = "";
                ComplaintTextBox.Text = "";
            }
        }

        private bool ValidatePatient()
        {

            if(NameTextBoxValidation() && TAJNumberTextBoxValidation() && ComplaintsTextBoxValidation())
            {
                return true;
            }

            return false;
        }

        // NAMETEXTBOX VALIDATION

        private bool NameTextBoxValidation()
        {

            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Name should not be empty.");
                return false;
            }

            if (NameTextBox.Text.Any(ch => !Char.IsLetterOrDigit(ch)))
            {
                MessageBox.Show("Name should not contain special characters.");
                return false;
            }
            return true;
        }

        // TAJNUMBERTEXTBOX VALIDATION 

        private bool TAJNumberTextBoxValidation()
        {

            Regex rg = new Regex("([0-9]{3} [0-9]{3} [0-9]{3}$)");

                if (!rg.IsMatch(TAJNumberTextBox.Text))
                {
                    MessageBox.Show("TAJ number should be like: 123 456 789");
                    return false;
                }
            
            return true;
        }

        // COMPLAINTSTEXTBOX VALIDATION

        private bool ComplaintsTextBoxValidation()
        {

            if (string.IsNullOrEmpty(ComplaintTextBox.Text))
            {
                MessageBox.Show("Complaints should not be empty.");
                return false;
            }

            return true;
        }

    }
}
