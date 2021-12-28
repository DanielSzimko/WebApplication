using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using WebApplication_Server.Models;

namespace WebApplication_Assistant.DataProviders
{
    class PatientDataProvider
    {
        private const string _url = "http://localhost:5000/api/patient";

        public static void CreatePatient(Patient patient)
        {
            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(patient);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");

                var response = client.PostAsync(_url, content).Result;
                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }
    }
}
