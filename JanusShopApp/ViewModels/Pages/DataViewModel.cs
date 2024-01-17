// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Net.Http;
using JanusShopApp.Models;
using System.Windows.Media;
using System.Xml.Serialization;
using Wpf.Ui.Controls;

namespace JanusShopApp.ViewModels.Pages
{
    public partial class DataViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;
        private IEnumerable<Product> products;

        [ObservableProperty]
        private IEnumerable<Product> _colors;

        [ObservableProperty]
        private IEnumerable<string> _searchNames;

        [ObservableProperty]
        private bool _isReady;

        public async void OnNavigatedTo()
        {
            if (!_isInitialized){}
                InitializeViewModel();
        }

        public void OnNavigatedFrom() { }

        [RelayCommand]
        private void Search(string text)
        {
            Colors = products.Where(p => p.ToString().ToLower().Contains(text.ToLower()));
        }

        private async Task InitializeViewModel()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://feeds.yeint.ee/xml/?key=G89F0R834F0E212");
                await using(var stream= await response.Content.ReadAsStreamAsync())
                {
                    var ser = new XmlSerializer(typeof(Product.Root));
                    var retVal = (Product.Root)ser.Deserialize(stream);
                    products = retVal.Product;
                    SearchNames = retVal.Product.Select(p => p.ToString()).ToList();
                } 
            }
            _isInitialized = true;
            IsReady = true;
        }
    }
}
