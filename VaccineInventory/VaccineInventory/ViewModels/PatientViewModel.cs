using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Data;
using VaccineInventory.Models;

namespace VaccineInventory.ViewModels
{
    public class PatientViewModel : BindableBase
    {
        private string _title = "Patient";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _message = String.Empty;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }
        private string _middleName;
        public string MiddleName
        {
            get { return _middleName; }
            set { SetProperty(ref _middleName, value); }
        }
        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }
        private DateTime _birthday;
        public DateTime Birthday
        {
            get { return _birthday; }
            set { SetProperty(ref _birthday, value); }
        }
        private string _contactNo;
        public string ContactNo
        {
            get { return _contactNo; }
            set { SetProperty(ref _contactNo, value); }
        }
        private char _sex;
        public char Sex
        {
            get { return _sex; }
            set { SetProperty(ref _sex, value); }
        }

        private IEnumerable<Patient> _patientList;
        public IEnumerable<Patient> PatientList
        {
            get { return _patientList; }
            set { SetProperty(ref _patientList, value); }
        }

        private Patient _selectedPatient;
        public Patient SelectedPatient
        {
            get { return _selectedPatient; }
            set { SetProperty(ref _selectedPatient, value); }
        }

        public DelegateCommand SaveButtonClick { get; private set; }
        public DelegateCommand GetSelected { get; private set; }
        public DelegateCommand DeleteButtonClick { get; private set; }
        public DelegateCommand UpdateButtonClick { get; private set; }

        public PatientViewModel()
        {
            GetSelected = new DelegateCommand(Selected);
            SaveButtonClick = new DelegateCommand(Insert);
            DeleteButtonClick = new DelegateCommand(Delete);
            UpdateButtonClick = new DelegateCommand(Update);
            GetPatient();
        }

        private void GetPatient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:16866/");
            //client.DefaultRequestHeaders.Add("appkey", "myapp_key");
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/Patients").Result;
            if (response.IsSuccessStatusCode)
            {
                //var employees = response.Content.ReadAsAsync<IEnumerable<List>>().Result;
                PatientList = response.Content.ReadAsAsync<IEnumerable<Patient>>().Result;

            }
        }

        private void Insert()
        {
            Patient newPatient = new Patient()
            {
                FirstName = FirstName,
                MiddleName = MiddleName,
                LastName = LastName,
                Birthday = Birthday,
                ContactNo = ContactNo,
                Sex = Sex
            };

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:16866/");
            //client.DefaultRequestHeaders.Add("appkey", "myapp_key");
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            var json = JsonConvert.SerializeObject(newPatient);
            HttpResponseMessage response = client.PostAsync("api/Patients", new StringContent(json, Encoding.UTF8, "application/json")).Result;
            if (response.IsSuccessStatusCode)
            {
                GetPatient();
                Message = "Item Added!!!";
                FirstName = string.Empty;
                MiddleName = string.Empty;
                LastName = string.Empty;
                Birthday = DateTime.Now;
                ContactNo = string.Empty;
                Sex = '\0' ;
            }
        }

        private void Selected()
        {
            FirstName = SelectedPatient.FirstName;
            MiddleName = SelectedPatient.MiddleName;
            LastName = SelectedPatient.LastName;
            Birthday = SelectedPatient.Birthday;
            ContactNo = SelectedPatient.ContactNo;
            Sex = SelectedPatient.Sex;
        }

        private void Delete()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:16866/");
            //client.DefaultRequestHeaders.Add("appkey", "myapp_key");
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.DeleteAsync("api/Patients/"+SelectedPatient.Id).Result;
            if (response.IsSuccessStatusCode)
            {
                GetPatient();
                Message = "Item Deleted!!!";
            }
        }

        private void Update()
        {
            Patient newPatient = new Patient()
            {
                Id = SelectedPatient.Id,
                FirstName = FirstName,
                MiddleName = MiddleName,
                LastName = LastName,
                Birthday = Birthday,
                ContactNo = ContactNo,
                Sex = Sex
            };

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:16866/");
            //client.DefaultRequestHeaders.Add("appkey", "myapp_key");
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            var json = JsonConvert.SerializeObject(newPatient);
            HttpResponseMessage response = client.PutAsync("api/Patients/" + SelectedPatient.Id, new StringContent(json, Encoding.UTF8, "application/json")).Result;
            if (response.IsSuccessStatusCode)
            {
                GetPatient();
                Message = "Item Updated!!!";
                FirstName = string.Empty;
                MiddleName = string.Empty;
                LastName = string.Empty;
                Birthday = DateTime.Now;
                ContactNo = string.Empty;
                Sex = '\0';
            }
        }
    }
}
