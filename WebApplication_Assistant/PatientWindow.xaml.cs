using System;
using System.Collections.Generic;
using System.Text;
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

                PatientDataProvider.CreatePatient(_Patient);

                NameTextBox.Text = "";
                AddressTextBox.Text = "";
                TAJNumberTextBox.Text = "";
                ComplaintTextBox.Text = "";
            }
        }

        private bool ValidatePatient()
        {
            if (string.IsNullOrEmpty(NameTextBox.Text))
            {
                MessageBox.Show("Name should not be empty.");
                return false;
            }

            if (string.IsNullOrEmpty(AddressTextBox.Text))
            {
                MessageBox.Show("Address should not be empty.");
                return false;
            }

            if (string.IsNullOrEmpty(TAJNumberTextBox.Text))
            {
                MessageBox.Show("TAJ nunmber should not be empty.");
                return false;
            }

            if (string.IsNullOrEmpty(ComplaintTextBox.Text))
            {
                MessageBox.Show("Complaint should not be empty.");
                return false;
            }

            return true;
        }
    }
}
