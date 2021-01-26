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
    public class AddDialogViewModel : BindableBase, IDialogAware
    {
        private DelegateCommand<string> _closeDialogCommand;
        public DelegateCommand<string> CloseDialogCommand =>
            _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand<string>(CloseDialog));

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
        private DateTime _birthday = DateTime.Now.AddYears(-50);
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

        private string _title = "Add Patient";
        private IRequestHandler _requestHandler;
        public DelegateCommand SaveButtonClick { get; private set; }
        public AddDialogViewModel(IRequestHandler requestHandler)
        {
            _requestHandler = requestHandler;
            SaveButtonClick = new DelegateCommand(Insert);
        }

        private async void Insert()
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

            _requestHandler.Execute("http://localhost:16866/");
            HttpResponseMessage response = await Task.Run(() => _requestHandler.InsertAsync("api/Patients", newPatient));

            if (response.IsSuccessStatusCode)
            {
                Message = "Item Added!!!";
                FirstName = string.Empty;
                MiddleName = string.Empty;
                LastName = string.Empty;
                Birthday = DateTime.Now;
                ContactNo = string.Empty;
                Sex = '\0';
                Message = "Patient Added!!!";
            }
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
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

        public virtual void OnDialogOpened(IDialogParameters parameters)
        {
            
        }
    }
}
