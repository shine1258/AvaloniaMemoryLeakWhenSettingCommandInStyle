using System;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaMemoryLeakWhenSettingCommandInStyle.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public ItemViewModel[] Items { get; } =
        Enumerable.Range(0, 10).Select(i => new ItemViewModel(i)).ToArray();

    [ObservableProperty]
    public partial ItemViewModel[]? LeakedItems { get; private set; }

    [RelayCommand]
    private void RefreshLeakedItems() => LeakedItems = Items.ToArray();

    [ObservableProperty]
    public partial ItemViewModel[]? NoLeakedItems { get; private set; }

    [RelayCommand]
    private void RefreshNoLeakedItems() => NoLeakedItems = Items.ToArray();
}

public partial class ItemViewModel(int number) : ViewModelBase
{
    public int Number { get; } = number;

    [RelayCommand]
    private void ShowNumber() => Console.WriteLine(Number);
}
