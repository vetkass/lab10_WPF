﻿using Caliburn.Micro;
using lab10_WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace lab10_WPF
{
    public class Bootstrapper : BootstrapperBase
    {
        private readonly SimpleContainer _container = new SimpleContainer();
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _container.Instance(_container);
            _container
              .Singleton<IWindowManager, WindowManager>()
              .Singleton<IEventAggregator, EventAggregator>();

            foreach (var assembly in SelectAssemblies())
            {
                assembly.GetTypes()
               .Where(type => type.IsClass)
               .Where(type => type.Name.EndsWith("ViewModel"))
               .ToList()
               .ForEach(viewModelType => _container.RegisterPerRequest(
                   viewModelType, viewModelType.ToString(), viewModelType));
            }
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        protected override async void OnStartup(object sender, StartupEventArgs e)
        {
            var c = IoC.Get<SimpleContainer>();
            await DisplayRootViewForAsync(typeof(MainViewModel));
        }
    }
}
