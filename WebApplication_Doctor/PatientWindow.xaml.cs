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
using WebApplication_Doctor.DataProviders;
using WebApplication_Server.Models;

namespace WebApplication_Doctor
{
    /// <summary>
    /// Interaction logic for PatientWindow.xaml
    /// </summary>
    public partial class PatientWindow : Window
    {
        private readonly Patient _Patient;
        public PatientWindow(Patient patient)
        {
            InitializeComponent();

            if (patient != null)
            {
                _Patient = patient;

                NameTextBox.Text = _Patient.Name;
                AddressTextBox.Text = _Patient.Address;
                TAJNumberTextBox.Text = _Patient.TAJNumber;
                ComplaintTextBox.Text = _Patient.Complaint;
                DiagnosisTextBox.Text = _Patient.Diagnosis;

                UpdateButton.Visibility = Visibility.Visible;
                DeleteButton.Visibility = Visibility.Visible;
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidatePatient())
            {
                _Patient.Name = NameTextBox.Text;
                _Patient.Address = AddressTextBox.Text;
                _Patient.TAJNumber = TAJNumberTextBox.Text;
                _Patient.Complaint = ComplaintTextBox.Text;
                _Patient.Diagnosis = DiagnosisTextBox.Text;
                
                PatientDataProvider.UpdatePatient(_Patient);

                DialogResult = true;
                Close();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete?", "Question", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                PatientDataProvider.DeletePatient(_Patient.Id);

                DialogResult = true;
                Close();
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

            if (string.IsNullOrEmpty(DiagnosisTextBox.Text))
            {
                MessageBox.Show("Diagnosis should not be empty.");
                return false;
            }

            return true;
        }
    }
}
