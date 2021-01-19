﻿using Prism.Ioc;
using System.Windows;
using System.Windows.Controls;
using VaccineInventory.Views;

namespace VaccineInventory
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Patient>();
            containerRegistry.RegisterForNavigation<Vaccine>();
            containerRegistry.RegisterForNavigation<Inventory>();
            containerRegistry.RegisterForNavigation<VaccineHistory>();

        }
    }
}