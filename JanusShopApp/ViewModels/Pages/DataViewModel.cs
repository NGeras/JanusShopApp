// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Net.Http;
using System.Xml.Serialization;
using JanusShopApp.Models;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace JanusShopApp.ViewModels.Pages;

public partial class DataViewModel : ObservableObject, INavigationAware
{
    private readonly ISnackbarService _snackbarService;
    private bool _isInitialized;

    [ObservableProperty] private bool _isReady;

    [ObservableProperty] private IEnumerable<Product> _productList;

    [ObservableProperty] private IEnumerable<string> _searchNames;

    private IEnumerable<Product> products;

    public DataViewModel(ISnackbarService snackbarService)
    {
        _snackbarService = snackbarService;
    }

    public void OnNavigatedTo()
    {
        if (!_isInitialized) InitializeViewModel();
    }

    public void OnNavigatedFrom()
    {
    }

    [RelayCommand]
    private void Search(string text)
    {
        ProductList = products.Where(p => p.ToString().ToLower().Contains(text.ToLower()));
    }

    private async Task InitializeViewModel()
    {
        try
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://feeds.yeint.ee/xml/?key=G89F0R834F0E212");
                response.EnsureSuccessStatusCode();
                await using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    var ser = new XmlSerializer(typeof(Product.Root));
                    var retVal = (Product.Root)ser.Deserialize(stream);
                    if (retVal == null) return;
                    products = retVal.Product.Where(p => !string.IsNullOrWhiteSpace(p.Name_est));
                    var enumerable = products as Product[] ?? products.ToArray();
                    ProductList = enumerable;
                    SearchNames = enumerable.Select(p => p.ToString()).ToList();
                }
            }

            IsReady = true;
        }
        catch (Exception e)
        {
            _snackbarService.Show("Viga", e.Message, ControlAppearance.Danger,
                new SymbolIcon(SymbolRegular.ErrorCircle24), TimeSpan.FromSeconds(10));
            IsReady = false;
        }
        finally
        {
            _isInitialized = true;
        }
    }
}