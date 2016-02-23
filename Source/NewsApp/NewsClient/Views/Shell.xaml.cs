using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Template10.Common;
using Template10.Controls;
using Template10.Services.NavigationService;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace NewsClient.Views
{
    public sealed partial class Shell : Page
    {
        public static Shell Instance { get; set; }
        public static HamburgerMenu HamburgerMenu { get { return Instance.MyHamburgerMenu; } }
        Services.DataService.DataService _dataService;

        public Shell()
        {
            Instance = this;
            InitializeComponent();
            Loaded += Shell_Loaded;
        }

        private void Shell_Loaded(object sender, RoutedEventArgs e)
        {
            _dataService = new Services.DataService.DataService();
            Services.DataService.DataService.FavoritesChanged += (s, list) => RenderFavorites(list);
            RenderFavorites(null);
        }

        private async void RenderFavorites(List<NewsService.Article> list)
        {
            //var existing = MyHamburgerMenu.PrimaryButtons.Where(x => Equals("Favorite", (x.Content as StackPanel).Tag));
            //foreach (var item in existing.ToArray())
            //{
            //    MyHamburgerMenu.PrimaryButtons.Remove(item);
            //}
            //var favorites = list ?? await _dataService.GetFavoritesAsync();
            //foreach (var item in favorites)
            //{
            //    MyHamburgerMenu.PrimaryButtons.Add(MakeButton(item));
            //}
        }

        private HamburgerButtonInfo MakeButton(NewsService.Article article)
        {
            var symbol = new SymbolIcon
            {
                Height = 48,
                Width = 48,
                Symbol = Symbol.Favorite
            };
            var block = new TextBlock
            {
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(12, 0, 0, 0),
                Text = article.Headline.Substring(0, Math.Min(20, article.Headline.Length)),
            };
            var stack = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Tag = "Favorite",
            };
            stack.Children.Add(symbol);
            stack.Children.Add(block);
            var button = new HamburgerButtonInfo
            {
                ButtonType = HamburgerButtonInfo.ButtonTypes.Command,
                Content = stack,
            };
            button.Tapped += (s, e) =>
            {
                MyHamburgerMenu.NavigationService.Navigate(typeof(Views.ArticlePage), article.Id);
            };
            return button;
        }

        public Shell(INavigationService navigationService) : this()
        {
            SetNavigationService(navigationService);
        }

        public void SetNavigationService(INavigationService navigationService)
        {
            MyHamburgerMenu.NavigationService = navigationService;
        }
    }
}

