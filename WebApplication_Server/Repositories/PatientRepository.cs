using System.Collections.Generic;
using System.Linq;
using WebApplication_Server.Models;

namespace WebApplication_Server.Repositories
{
    public static class PatientRepository
    {
        public static IList<Patient> GetPatients()
        {
            using (var database = new PatientContext())
            {
                var patients = database.Patients.ToList();

                return patients;
            }
        }

        public static Patient GetPatient(long id)
        {
            using (var database = new PatientContext())
            {
                var patient = database.Patients.Where(p => p.Id == id).FirstOrDefault();

                return patient;
            }
        }

        public static void AddPatient(Patient patient)
        {
            using (var database = new PatientContext())
            {
                database.Patients.Add(patient);

                database.SaveChanges();
            }
        }

        public static void UpdatePatient(Patient patient)
        {
            using (var database = new PatientContext())
            {
                database.Patients.Update(patient);

                database.SaveChanges();
            }
        }

        public static void DeletePatient(Patient patient)
        {
            using (var database = new PatientContext())
            {
                database.Patients.Remove(patient);

                database.SaveChanges();
            }
        }
    }
}
