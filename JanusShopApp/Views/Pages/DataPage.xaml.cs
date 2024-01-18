// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Windows.Input;
using JanusShopApp.ViewModels.Pages;
using Wpf.Ui.Controls;
using TextBlock = System.Windows.Controls.TextBlock;

namespace JanusShopApp.Views.Pages;

public partial class DataPage : INavigableView<DataViewModel>
{
    public DataPage(DataViewModel viewModel)
    {
        ViewModel = viewModel;
        DataContext = this;

        InitializeComponent();
    }

    public DataViewModel ViewModel { get; }

    private void DataGrid_OnPreviewKeyDown(object sender, KeyEventArgs e)
    {
        var dataGrid = sender as DataGrid;
        if (dataGrid == null) return;
        if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.C) //ctrl + c got pressed
        {
            var currentCell = dataGrid.CurrentCell; // cell that currently has focus
            var content = currentCell.Column.GetCellContent(currentCell.Item) as TextBlock;
            if (content == null) return;
            Clipboard.SetText(content.Text);
        }
        e.Handled = true;
    }
}