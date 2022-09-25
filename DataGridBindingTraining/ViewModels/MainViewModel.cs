using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Data;
using BindingLibrary;

namespace DataGridBindingTraining.ViewModels;

public class MainViewModel : NotifyPropertyBase
{
    public MainViewModel()
    {
        DataModels = GetDataModels();

        // 網路上看到的解法，使用 CollectionViewSource
        var view = CollectionViewSource.GetDefaultView(DataModels);
        view.CollectionChanged += (_, _) => OnPropertyChanged(nameof(Total));
    }

    private ObservableCollection<DataModel> _dataModels = new();

    public ObservableCollection<DataModel> DataModels
    {
        get => _dataModels;
        set => SetProperty(ref _dataModels, value);
    }

    // 利用 DataModels 的資料做 Sum
    public decimal Total => DataModels.Sum(x => x.Amount);

    private static ObservableCollection<DataModel> GetDataModels() =>
        new()
        {
            new DataModel
            {
                Id = "1",
                Amount = 10000
            },
            new DataModel
            {
                Id = "2",
                Amount = 20000
            },
            new DataModel
            {
                Id = "3",
                Amount = 30000
            }
        };
}

public class DataModel
{
    public string Id { get; set; } = string.Empty;

    public decimal Amount { get; set; }
}