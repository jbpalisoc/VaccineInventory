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
    public class VaccineHistoryViewModel : BindableBase
    {
        private IRequestHandler _requestHandler;
        private IDialogService _dialogService;

        private string _title = "Vaccine History";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private IEnumerable<History> _historyList;
        public IEnumerable<History> HistoryList
        {
            get { return _historyList; }
            set { SetProperty(ref _historyList, value); }
        }
        public DelegateCommand SaveButtonClick { get; private set; }
        public DelegateCommand RefreshClick { get; private set; }
        public VaccineHistoryViewModel(IRequestHandler requestHandler, IDialogService dialogService)
        {
            _requestHandler = requestHandler;
            _dialogService = dialogService;
            SaveButtonClick = new DelegateCommand(Insert);
            RefreshClick = new DelegateCommand(Refresh);
            GetHistory();
        }

        private async void GetHistory()
        {
            _requestHandler.Execute("http://localhost:16866/");
            HttpResponseMessage response = await Task.Run(() => _requestHandler.GetAsync("/api/v2/VaccineHistories/GetAllHistoryJoinPatientJoinInventory"));

            if (response.IsSuccessStatusCode)
            {
                HistoryList = response.Content.ReadAsAsync<IEnumerable<History>>().Result;
            }
        }
        private void Refresh()
        {
            GetHistory();
        }
        private void Insert()
        {
            _dialogService.ShowDialog("VaccineHistoryAddDialog", new DialogParameters(), r =>
            {
                if (r.Result == ButtonResult.None)
                {
                    GetHistory();
                }
                else if (r.Result == ButtonResult.OK)
                {
                    GetHistory();
                }
                else if (r.Result == ButtonResult.Cancel)
                {
                    GetHistory();
                }
                else
                    Title = "I Don't know what you did!?";
            });
        }
    }
}
