using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SampleMobileApp.Models;

namespace SampleMobileApp.ViewModels;

public partial class MainViewModel : ObservableObject
{
    public ObservableCollection<TodoItem> Items { get; } =
    [
        new TodoItem { Title = "Install .NET MAUI workload" },
        new TodoItem { Title = "Run the app on an Android emulator" },
    ];

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AddCommand))]
    private string newTitle = string.Empty;

    private bool CanAdd() => !string.IsNullOrWhiteSpace(NewTitle);

    [RelayCommand(CanExecute = nameof(CanAdd))]
    private void Add()
    {
        Items.Add(new TodoItem { Title = NewTitle.Trim() });
        NewTitle = string.Empty;
    }

    [RelayCommand]
    private void Delete(TodoItem item) => Items.Remove(item);
}
