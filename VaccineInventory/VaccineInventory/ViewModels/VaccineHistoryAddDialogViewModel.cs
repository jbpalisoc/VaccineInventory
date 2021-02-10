using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VaccineInventory.ViewModels
{
    public class VaccineHistoryAddDialogViewModel : BindableBase, IDialogAware
    {
        private string _title = "Add Vaccine History";

        public event Action<IDialogResult> RequestClose;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public VaccineHistoryAddDialogViewModel()
        {

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
