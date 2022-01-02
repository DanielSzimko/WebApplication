using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication_Assistant;
using WebApplication_Server.Models;

namespace PatientUnitTests
{
    [TestClass]
    public class PatientUnitTests
    {
        [TestMethod]
        public void NameTextBoxValidation_WithValidArgument_ExpectedTrue()
        {
            var patient = new Patient();
            var patientValidator = new PatientValidator();
            patient.Name = "Daniel";

            var expectedTrue = patientValidator.NameTextBoxValidation(patient.Name);

            Assert.AreEqual(true, expectedTrue);
        }

        [TestMethod]
        public void NameTextBoxValidation_WithValidArgument_ExpectedFalse()
        {
            var patient = new Patient();
            var patientValidator = new PatientValidator();
            patient.Name = "Daniel ";

            var expectedFalse = patientValidator.NameTextBoxValidation(patient.Name);

            Assert.AreEqual(false, expectedFalse);
        }

        [TestMethod]
        public void TAJNumberTextBoxValidation_WithValidArgument_ExpectedTrue()
        {
            var patient = new Patient();
            var patientValidator = new PatientValidator();
            patient.TAJNumber = "000 000 000";

            var expectedTrue = patientValidator.TAJNumberTextBoxValidation(patient.TAJNumber);

            Assert.AreEqual(true, expectedTrue);
        }

        [TestMethod]
        public void TAJNumberTextBoxValidation_WithValidArgument_ExpectedFalse()
        {
            var patient = new Patient();
            var patientValidator = new PatientValidator();
            patient.TAJNumber = "000 000 000 ";

            var expectedFalse = patientValidator.TAJNumberTextBoxValidation(patient.TAJNumber);

            Assert.AreEqual(false, expectedFalse);
        }

        [TestMethod]
        public void ComplaintsTextBoxValidation_WithValidArgument_ExpectedTrue()
        {
            var patient = new Patient();
            var patientValidator = new PatientValidator();
            patient.Complaint = "Faj a fejem";

            var expectedTrue = patientValidator.ComplaintsTextBoxValidation(patient.Complaint);

            Assert.AreEqual(true, expectedTrue);
        }

        [TestMethod]
        public void ComplaintsTextBoxValidation_WithValidArgument_ExpectedFalse()
        {
            var patient = new Patient();
            var patientValidator = new PatientValidator();
            patient.Complaint = "";

            var expectedFalse = patientValidator.ComplaintsTextBoxValidation(patient.Complaint);

            Assert.AreEqual(false, expectedFalse);
        }
    }
}
