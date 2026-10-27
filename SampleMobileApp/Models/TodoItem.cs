using CommunityToolkit.Mvvm.ComponentModel;

namespace SampleMobileApp.Models;

public partial class TodoItem : ObservableObject
{
    [ObservableProperty]
    private string title = string.Empty;

    [ObservableProperty]
    private bool isDone;
}
