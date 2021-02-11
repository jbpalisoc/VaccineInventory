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
    public class InventoryAddDialogViewModel : BindableBase, IDialogAware
    {
        private DelegateCommand<string> _closeDialogCommand;
        public DelegateCommand<string> CloseDialogCommand =>
            _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand<string>(CloseDialog));

        private string _title = "Add Inventory";
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

        private Vaccine _selectedVaccine;
        public Vaccine SelectedVaccine
        {
            get { return _selectedVaccine; }
            set { SetProperty(ref _selectedVaccine, value); }
        }
        private decimal _startingStock;
        public decimal StartingStock
        {
            get { return _startingStock; }
            set { SetProperty(ref _startingStock, value); }
        }

        private DateTime _storageDate;
        public DateTime StorageDate
        {
            get { return _storageDate; }
            set { SetProperty(ref _storageDate, value); }
        }

        private DateTime _expirationDate;
        public DateTime ExpirationDate
        {
            get { return _expirationDate; }
            set { SetProperty(ref _expirationDate, value); }
        }
        private IEnumerable<Vaccine> _vaccineList;
        public IEnumerable<Vaccine> VaccineList
        {
            get { return _vaccineList; }
            set { SetProperty(ref _vaccineList, value); }
        }

        private IRequestHandler _requestHandler;
        public DelegateCommand SaveButtonClick { get; private set; }

        public InventoryAddDialogViewModel(IRequestHandler requestHandler)
        {
            _requestHandler = requestHandler;
            SaveButtonClick = new DelegateCommand(Insert);
            GetVaccine();
        }
        private async void GetVaccine()
        {
            _requestHandler.Execute("http://localhost:16866/");
            HttpResponseMessage response = await Task.Run(() => _requestHandler.GetAsync("api/v2/Vaccines"));

            if (response.IsSuccessStatusCode)
            {
                VaccineList = response.Content.ReadAsAsync<IEnumerable<Vaccine>>().Result;
            }
        }
        private async void Insert()
        {
            Inventory newInventory = new Inventory()
            {
                VaccineId = SelectedVaccine.Id,
                StartingStock = StartingStock,
                StorageDate = StorageDate,
                ExpirationDate = ExpirationDate
            };

            _requestHandler.Execute("http://localhost:16866/");
            HttpResponseMessage response = await Task.Run(() => _requestHandler.InsertAsync("api/v2/VaccineInventories", newInventory));

            if (response.IsSuccessStatusCode)
            {
                SelectedVaccine = null;
                StartingStock = 0;
                StorageDate = DateTime.Now;
                ExpirationDate = DateTime.Now;

                Message = "Inventory Added!!!";
            }
        }
        public event Action<IDialogResult> RequestClose;

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

        public virtual bool CanCloseDialog()
        {
            return true;
        }
        public virtual void OnDialogClosed()
        {

        }
        public void OnDialogOpened(IDialogParameters parameters)
        {
            //throw new NotImplementedException();
        }
    }
}
