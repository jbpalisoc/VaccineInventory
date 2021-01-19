using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VaccineInventory.ViewModels
{
    public class VaccineViewModel : BindableBase
    {
        private string _title = "Vaccine";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public VaccineViewModel()
        {

        }
    }
}
