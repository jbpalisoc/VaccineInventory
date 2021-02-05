using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using VaccineInventory.Models;
using VaccineInventory.Handlers;
using System.Threading.Tasks;
using System.Net.Http;
using Prism.Services.Dialogs;
using System.Windows;

namespace VaccineInventory.ViewModels
{
    public class VaccineViewModel : BindableBase
    {
        private IRequestHandler _requestHandler;
        private IDialogService _dialogService;

        private string _title = "Vaccine";

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

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        private string _description;
        public string Description
        {
            get { return _description; }
        }
        private IEnumerable<Vaccine> _vaccineList;
        public IEnumerable<Vaccine> VaccineList
        {
            get { return _vaccineList; }
            set { SetProperty(ref _vaccineList, value); }
        }
        private Vaccine _selectedVaccine;
        public Vaccine SelectedVaccine
        {
            get { return _selectedVaccine; }
            set { SetProperty(ref _selectedVaccine, value); }
        }

        public DelegateCommand GetSelected { get; private set; }
        public DelegateCommand SaveButtonClick { get; private set; }
        public DelegateCommand DeleteButtonClick { get; private set; }


        public VaccineViewModel(IRequestHandler requestHandler, IDialogService dialogService)
        {
            _requestHandler = requestHandler;
            _dialogService = dialogService;
            GetSelected = new DelegateCommand(Selected);
            SaveButtonClick = new DelegateCommand(Insert);
            DeleteButtonClick = new DelegateCommand(Delete);
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

        private void Insert()
        {
            _dialogService.ShowDialog("VaccineAddDialog", new DialogParameters(), r =>
            {
                if (r.Result == ButtonResult.None)
                {
                    GetVaccine();
                }
                else if (r.Result == ButtonResult.OK)
                {
                    GetVaccine();
                }
                else if (r.Result == ButtonResult.Cancel)
                {
                    GetVaccine();
                }
                else
                    Title = "I Don't know what you did!?";
            });
        }
        private void Selected()
        {
            //EnableGrid = false;
            _dialogService.ShowDialog("VaccineEditDialog", new DialogParameters {
                                    { "Id", SelectedVaccine.Id },
                                    { "Name", SelectedVaccine.Name },
                                    { "Description", SelectedVaccine.Description }},
                                      r =>
                                      {
                                          if (r.Result == ButtonResult.None)
                                              GetVaccine();
                                          else if (r.Result == ButtonResult.OK)
                                          {
                                              GetVaccine();
                                              Message = "Item Updated!!!";
                                              MessageColor = "#008000";

                                          }
                                          else if (r.Result == ButtonResult.Cancel)
                                              GetVaccine();
                                          else
                                              GetVaccine();
                                      });
        }

        private async void Delete()
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                _requestHandler.Execute("http://localhost:16866/");
                HttpResponseMessage response = await Task.Run(() => _requestHandler.DeleteAsync("api/v2/Vaccines/" + SelectedVaccine.Id));
                if (response.IsSuccessStatusCode)
                {
                    GetVaccine();
                    Message = "Item Deleted!!!";
                    MessageColor = "#ff0000";
                }
            }
        }
    }
}
