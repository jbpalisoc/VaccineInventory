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
    public class VaccineEditDialogViewModel : BindableBase, IDialogAware
    {
        private DelegateCommand<string> _closeDialogCommand;
        public DelegateCommand<string> CloseDialogCommand =>
            _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand<string>(CloseDialog));

        private IRequestHandler _requestHandler;

        private string _title = "Edit Vaccine";

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

        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
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
            set { SetProperty(ref _description, value); }
        }
        public DelegateCommand UpdateButtonClick { get; private set; }
        public VaccineEditDialogViewModel(IRequestHandler requestHandler)
        {
            _requestHandler = requestHandler;
            UpdateButtonClick = new DelegateCommand(Update);
        }
        private async void Update()
        {
            Vaccine newVaccine = new Vaccine()
            {
                Id = Id,
                Name = Name,
                Description = Description
            };

            _requestHandler.Execute("http://localhost:16866/");
            HttpResponseMessage response = await Task.Run(() => _requestHandler.UpdateAsync("api/v2/Vaccines/" + Id, newVaccine));

            if (response.IsSuccessStatusCode)
            {
                CloseDialog("true");
            }
        }

        public event Action<IDialogResult> RequestClose;
        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
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
        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Message = parameters.GetValue<string>("message");
            Id = parameters.GetValue<int>("Id");
            Name = parameters.GetValue<string>("Name");
            Description = parameters.GetValue<string>("Description");
        }
    }
}
