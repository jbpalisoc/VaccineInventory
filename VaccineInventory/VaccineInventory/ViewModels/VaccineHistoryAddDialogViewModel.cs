using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VaccineInventory.Handlers;
using VaccineInventory.Models;

namespace VaccineInventory.ViewModels
{
    public class VaccineHistoryAddDialogViewModel : BindableBase, IDialogAware
    {
        private IRequestHandler _requestHandler;

        private string _title = "Add Vaccine History";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
        private Patient _selectedPatient;
        public Patient SelectedPatient
        {
            get { return _selectedPatient; }
            set { SetProperty(ref _selectedPatient, value); }
        }
        private Inventory _selectedInventory;
        public Inventory SelectedInventory
        {
            get { return _selectedInventory; }
            set { SetProperty(ref _selectedInventory, value); }
        }
        private decimal _dosage;
        public decimal Dosage
        {
            get { return _dosage; }
            set { SetProperty(ref _dosage, value); }
        }
        private DateTime _dateVaccinated;
        public DateTime DateVaccinated
        {
            get { return _dateVaccinated; }
            set { SetProperty(ref _dateVaccinated, value); }
        }
        private IEnumerable<Patient> _patientList;
        public IEnumerable<Patient> PatientList
        {
            get { return _patientList; }
            set { SetProperty(ref _patientList, value); }
        }
        private IEnumerable<Inventory> _inventoryList;
        public IEnumerable<Inventory> InventoryList
        {
            get { return _inventoryList; }
            set { SetProperty(ref _inventoryList, value); }
        }

        public DelegateCommand SaveButtonClick { get; private set; }
        public event Action<IDialogResult> RequestClose;
        private DelegateCommand<string> _closeDialogCommand;
        public DelegateCommand<string> CloseDialogCommand =>
            _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand<string>(CloseDialog));
        public VaccineHistoryAddDialogViewModel(IRequestHandler requestHandler)
        {
            _requestHandler = requestHandler;
            SaveButtonClick = new DelegateCommand(Insert);

            GetPatient();
            GetInventory();
        }
        private async void GetPatient()
        {
            _requestHandler.Execute("http://localhost:16866/");
            HttpResponseMessage response = await Task.Run(() => _requestHandler.GetAsync("api/v2/Patients"));

            if (response.IsSuccessStatusCode)
            {
                PatientList = response.Content.ReadAsAsync<IEnumerable<Patient>>().Result;
            }
        }
        private async void GetInventory()
        {
            _requestHandler.Execute("http://localhost:16866/");
            HttpResponseMessage response = await Task.Run(() => _requestHandler.GetAsync("api/v2/VaccineInventories/GetAllInventoryJoinVaccine"));

            if (response.IsSuccessStatusCode)
            {
                InventoryList = response.Content.ReadAsAsync<IEnumerable<Inventory>>().Result;
            }
        }
        private async void Insert()
        {
            History newHistory = new History()
            {
                PatientId = SelectedPatient.Id,
                InventoryId = SelectedInventory.Id,
                Dosage = Dosage,
                DateVaccinated = DateVaccinated
            };

            _requestHandler.Execute("http://localhost:16866/");
            HttpResponseMessage response = await Task.Run(() => _requestHandler.InsertAsync("api/v2/VaccineHistories", newHistory));

            if (response.IsSuccessStatusCode)
            {
                SelectedPatient = null;
                SelectedInventory = null;
                Dosage = 0;
                DateVaccinated = DateTime.Now;

                Message = "History Added!!!";
            }
        }
        protected virtual void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;

            if (parameter?.ToLower() == "true")
                result = ButtonResult.OK;
            else if (parameter?.ToLower() == "false")
                result = ButtonResult.Cancel;

            RaiseRequestClose(new DialogResult(result));
        }
        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }
        public bool CanCloseDialog()
        {
            return true;
            //throw new NotImplementedException();
        }

        public void OnDialogClosed()
        {
            //throw new NotImplementedException();
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            //throw new NotImplementedException();
        }
    }
}
