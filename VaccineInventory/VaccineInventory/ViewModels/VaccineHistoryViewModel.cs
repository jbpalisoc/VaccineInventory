using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VaccineInventory.ViewModels
{
    public class VaccineHistoryViewModel : BindableBase
    {
        private string _title = "Vaccine History";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public VaccineHistoryViewModel()
        {

        }
    }
}
