using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using WebApplication_Server.Models;

namespace WebApplication_Doctor.DataProviders
{
    class PatientDataProvider
    {
        private const string _url = "http://localhost:5000/api/patient";

        public static IEnumerable<Patient> GetPatients()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var patients = JsonConvert.DeserializeObject<IEnumerable<Patient>>(rawData);
                    return patients;
                }

                throw new InvalidOperationException(response.StatusCode.ToString());
            }
        }

        public static void UpdatePatient(Patient patient)
        {
            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(patient);
                var content = new StringContent(rawData,Encoding.UTF8, "application/json");

                var response = client.PutAsync($"{_url}/{patient.Id}", content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static void DeletePatient(long id)
        {
            using (var client = new HttpClient())
            {
                var response = client.DeleteAsync($"{_url}/{id}").Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }
    }
}
