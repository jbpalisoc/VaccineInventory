using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using VaccineInventory.Handlers;
using VaccineInventory.Models;

namespace VaccineInventory.ViewModels
{
    public class PatientViewModel : BindableBase
    {
        private IDialogService _dialogService;
        private IRequestHandler _requestHandler;

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

        private string _messageColor = "#0000";
        public string MessageColor
        {
            get { return _messageColor; }
            set { SetProperty(ref _messageColor, value); }
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

        public PatientViewModel(IRequestHandler requestHandler, IDialogService dialogService)
        {
            _dialogService = dialogService;
            _requestHandler = requestHandler;
            GetSelected = new DelegateCommand(Selected);
            SaveButtonClick = new DelegateCommand(Insert);
            DeleteButtonClick = new DelegateCommand(Delete);
            //UpdateButtonClick = new DelegateCommand(Update);
            GetPatient();
        }
        private async void GetPatient()
        {
             _requestHandler.Execute("http://localhost:16866/");
            HttpResponseMessage response = await Task.Run(() => _requestHandler.GetAsync("api/Patients"));

            if (response.IsSuccessStatusCode)
            {
                PatientList = response.Content.ReadAsAsync<IEnumerable<Patient>>().Result;
            }
        }

        private void Insert()
        {
            _dialogService.ShowDialog("AddDialog", new DialogParameters(), r =>
            {
                if (r.Result == ButtonResult.None)
                {
                    GetPatient();
                }
                else if (r.Result == ButtonResult.OK)
                {
                    GetPatient();
                }
                else if (r.Result == ButtonResult.Cancel)
                {
                    GetPatient();
                }
                else
                    Title = "I Don't know what you did!?";
            }) ;
        }

        private void Selected()
        {
            //EnableGrid = false;
            _dialogService.ShowDialog("EditDialog", new DialogParameters {
                                    { "Id", SelectedPatient.Id },
                                    { "FirstName", SelectedPatient.FirstName },
                                    { "MiddleName", SelectedPatient.MiddleName },
                                    { "LastName", SelectedPatient.LastName },
                                    { "Birthday", SelectedPatient.Birthday },
                                    { "ContactNo", SelectedPatient.ContactNo},
                                    { "Sex", SelectedPatient.Sex}},
                                      r =>
                                     {
                                         if (r.Result == ButtonResult.None)
                                             GetPatient();
                                         else if (r.Result == ButtonResult.OK)
                                         {
                                             GetPatient();
                                             Message = "Item Updated!!!";
                                             MessageColor = "#008000";
                                             
                                         }
                                         else if (r.Result == ButtonResult.Cancel)
                                             GetPatient();
                                         else
                                             GetPatient();
                                     });
        }

        private async void Delete()
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                _requestHandler.Execute("http://localhost:16866/");
                HttpResponseMessage response = await Task.Run(() => _requestHandler.DeleteAsync("api/Patients/" + SelectedPatient.Id));
                if (response.IsSuccessStatusCode)
                {
                    GetPatient();
                    Message = "Item Deleted!!!";
                    MessageColor = "#ff0000";
                }
            }
        }

    }
}
