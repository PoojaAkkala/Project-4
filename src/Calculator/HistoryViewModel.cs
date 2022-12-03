using Calculator.Data;
using Calculator.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Amazon.SimpleWorkflow.Model;

namespace Calculator
{
    public partial class HistoryViewModel 
    {
        
        CalcHistory history = new CalcHistory();
        private HistoryDataBase data; 
        ObservableCollection<CalcHistory> items;
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<CalcHistory> Items { get => items; }
        public void OnPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        
        public HistoryViewModel()
        {
            initiateData();
            items = new ObservableCollection<CalcHistory>();
             

        }
       
        public async void Add(string item)
        {
            
            
            history.Calc = item;
            data = new HistoryDataBase();
            await data.SaveItemAsync(history); 
            OnPropertyChanged("Items");
            OnPropertyChanged("Items");
            OnPropertyChanged();
            OnPropertyChanged();
           

        }
        public async Task initiateData()
        {
            data = new HistoryDataBase();
            var res = await data.GetItemsAsync();
            items = new ObservableCollection<CalcHistory>();
            res.ForEach(items.Add);
           
  
        }

        
    }
}
