using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VaccineInventory.ViewModels
{
    public class InventoryViewModel : BindableBase
    {
        private string _title = "Inventory";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public InventoryViewModel()
        {

        }
    }
}
