using Calculator.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace Calculator;

public partial class HistoryPage : ContentPage
{

    Data.HistoryDataBase dataBase = new Data.HistoryDataBase();
    public HistoryPage()
    {
        InitializeComponent();
        
        
        
        BindingContext = new {history = App.vm.Items};

        
        
    }
   
    private async void Clear_Clicked(object sender, EventArgs e)
    {
        await dataBase.DeleteAllAsync();
        App.vm.Items.Clear();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var res = await dataBase.GetItemsAsync();
        App.vm.Items.Clear();
        res.ForEach(App.vm.Items.Add);
        

    }
}