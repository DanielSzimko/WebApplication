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

            PatientValidator patientValidator = new PatientValidator();

            if(!patientValidator.NameTextBoxValidation(NameTextBox.Text))
            {
                MessageBox.Show("Name should not be empty or use special characters.");
                return false;
            }

            if (!patientValidator.TAJNumberTextBoxValidation(TAJNumberTextBox.Text))
            {
                MessageBox.Show("TAJ number's format should be like 000 000 000");
                return false;
            }

            if (!patientValidator.ComplaintsTextBoxValidation(ComplaintTextBox.Text))
            {
                MessageBox.Show("Complaints should not be empty.");
                return false;
            }

            return true;
        }

    }
}
