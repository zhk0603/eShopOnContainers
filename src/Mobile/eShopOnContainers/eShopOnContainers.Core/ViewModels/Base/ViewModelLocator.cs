using Autofac;
using eShopOnContainers.Core.Services.Basket;
using eShopOnContainers.Core.Services.Catalog;
using eShopOnContainers.Core.Services.Identity;
using eShopOnContainers.Core.Services.OpenUrl;
using eShopOnContainers.Core.Services.Order;
using eShopOnContainers.Core.Services.RequestProvider;
using eShopOnContainers.Core.Services.User;
using eShopOnContainers.Services;
using Microsoft.eShopOnContainers.BuildingBlocks.Resilience.HttpResilience;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;

namespace eShopOnContainers.Core.ViewModels.Base
{
    public static class ViewModelLocator
    {
        private static IContainer _container;

        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(ViewModelLocator.AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(ViewModelLocator.AutoWireViewModelProperty, value);
        }

        public static bool UseMockService { get; set; }

        public static void RegisterDependencies(bool useMockServices)
        {
            var builder = new ContainerBuilder();

            // View models
            builder.RegisterType<BasketViewModel>();
            builder.RegisterType<CatalogViewModel>();
            builder.RegisterType<CheckoutViewModel>();
            builder.RegisterType<LoginViewModel>();
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<OrderDetailViewModel>();
            builder.RegisterType<ProfileViewModel>();
            builder.RegisterType<SettingsViewModel>();

            // Services
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<DialogService>().As<IDialogService>();
            builder.RegisterType<OpenUrlService>().As<IOpenUrlService>();
            builder.RegisterType<IdentityService>().As<IIdentityService>();
            builder.RegisterType<RequestProvider>().As<IRequestProvider>();

            if (GlobalSetting.UseResilientHttp)
            {
                builder.RegisterType<Logger<ResilientHttpClient>>().As<ILogger<ResilientHttpClient>>();
                builder.RegisterType<LoggerFactory>().As<ILoggerFactory>();

                builder.RegisterInstance(new List<ResiliencePolicy>
                {
                    ResiliencePolicyFactory.CreateRetryPolicy(3, 2, true),
                    ResiliencePolicyFactory.CreateCiscuitBreakerPolicy(3, 1)
                });

                builder.RegisterType<ResilientHttpClient>().As<IHttpClient>();
            }
            else
            {
                builder.RegisterType<Logger<StandardHttpClient>>().As<ILogger<StandardHttpClient>>();
                builder.RegisterType<LoggerFactory>().As<ILoggerFactory>();

                builder.RegisterType<StandardHttpClient>().As<IHttpClient>();
            }

            if (useMockServices)
            {
                builder.RegisterInstance(new CatalogMockService()).As<ICatalogService>();
                builder.RegisterInstance(new BasketMockService()).As<IBasketService>();
                builder.RegisterInstance(new OrderMockService()).As<IOrderService>();
                builder.RegisterInstance(new UserMockService()).As<IUserService>();

                UseMockService = true;
            }
            else
            {
                builder.RegisterType<CatalogService>().As<ICatalogService>().SingleInstance();
                builder.RegisterType<BasketService>().As<IBasketService>().SingleInstance();
                builder.RegisterType<OrderService>().As<IOrderService>().SingleInstance();
                builder.RegisterType<UserService>().As<IUserService>().SingleInstance();

                UseMockService = false;
            }

            if (_container != null)
            {
                _container.Dispose();
            }
            _container = builder.Build();
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;
            if (view == null)
            {
                return;
            }

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
            {
                return;
            }
            var viewModel = _container.Resolve(viewModelType);
            view.BindingContext = viewModel;
        }
    }
}