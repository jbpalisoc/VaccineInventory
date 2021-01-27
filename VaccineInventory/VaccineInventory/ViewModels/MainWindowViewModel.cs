using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using VaccineInventory.Views;

namespace VaccineInventory.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Main";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private readonly IRegionManager _regionManager;
        public DelegateCommand<string> NavigateCommand { get; private set; }
        public MainWindowViewModel(IRegionManager regionManager)
        {
            NavigateCommand = new DelegateCommand<string>(Navigate);
            _regionManager = regionManager;
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(Patient));
        }   

        private void Navigate(string viewName)
        {
            _regionManager.RequestNavigate("ContentRegion", viewName);
        }

    }
}
