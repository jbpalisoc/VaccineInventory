using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public class InventoryViewModel : BindableBase
    {
        private IRequestHandler _requestHandler;
        private IDialogService _dialogService;


        private string _title = "Inventory";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        private string _id;
        public string Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }
        private string _vaccineId;
        public string VaccineId
        {
            get { return _vaccineId; }
            set { SetProperty(ref _vaccineId, value); }
        }
        private string _startingStock;
        public string StartingStock
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
        private IEnumerable<Inventory> _inventoryList;
        public IEnumerable<Inventory> InventoryList
        {
            get { return _inventoryList; }
            set { SetProperty(ref _inventoryList, value); }
        }
        public DelegateCommand SaveButtonClick { get; private set; }
        public DelegateCommand RefreshClick { get; private set; }

        public InventoryViewModel(IRequestHandler requestHandler, IDialogService dialogService)
        {
            _requestHandler = requestHandler;
            _dialogService = dialogService;
            SaveButtonClick = new DelegateCommand(Insert);
            RefreshClick = new DelegateCommand(Refresh);
            GetInventory();
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
        private void Refresh()
        {
            GetInventory();
        }
        private void Insert()
        {
            _dialogService.ShowDialog("InventoryAddDialog", new DialogParameters(), r =>
            {
                if (r.Result == ButtonResult.None)
                {
                    GetInventory();
                }
                else if (r.Result == ButtonResult.OK)
                {
                    GetInventory();
                }
                else if (r.Result == ButtonResult.Cancel)
                {
                    GetInventory();
                }
                else
                    Title = "I Don't know what you did!?";
            });
        }
    }
}
