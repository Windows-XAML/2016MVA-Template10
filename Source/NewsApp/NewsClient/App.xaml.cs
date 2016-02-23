using System;
using Windows.UI.Xaml;
using System.Threading.Tasks;
using NewsClient.Services.SettingsServices;
using Windows.ApplicationModel.Activation;
using Template10.Controls;
using Template10.Common;

namespace NewsClient
{
    /// Documentation on APIs used in this page:
    /// https://github.com/Windows-XAML/Template10/wiki

    sealed partial class App : Template10.Common.BootStrapper
    {
        public App()
        {
            InitializeComponent();
            SplashFactory = (e) => new Views.Splash(e);
            Template10.Services.LoggingService.LoggingService.Enabled = true;

            #region App settings

            var _settings = SettingsService.Instance;
            RequestedTheme = _settings.AppTheme;
            CacheMaxDuration = _settings.CacheMaxDuration;
            ShowShellBackButton = _settings.UseShellBackButton;

            #endregion
        }

        // runs even if restored from state
        public override async Task OnInitializeAsync(IActivatedEventArgs args)
        {
            // hide phone statusbar
            if (Windows.Foundation.Metadata.ApiInformation
                .IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {
                await Windows.UI.ViewManagement.StatusBar.GetForCurrentView().HideAsync();
            }

            // content may already be shell when resuming
            if ((Window.Current.Content as ModalDialog) == null)
            {
                // setup hamburger shell
                var nav = NavigationServiceFactory(BackButton.Attach, ExistingContent.Include);
                Window.Current.Content = new ModalDialog
                {
                    DisableBackButtonWhenModal = true,
                    Content = new Views.Shell(nav),
                    ModalContent = new Views.Busy(),
                };
            }
        }

        // runs only when not restored from state
        public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            await Task.Delay(3500);

            var param = string.Empty;
            var protocolArgs = args as ProtocolActivatedEventArgs;
            if (protocolArgs != null)
            {
                var uri = protocolArgs.Uri;
                var decoder = new Windows.Foundation.WwwFormUrlDecoder(uri.Query);
                param = decoder.GetFirstValueByName("filter");
            }
            NavigationService.Navigate(typeof(Views.MainPage), param);
        }
    }
}

