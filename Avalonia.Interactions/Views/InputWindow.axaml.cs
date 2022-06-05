using System;
using Avalonia.Interactions.ViewModels;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace Avalonia.Interactions.Views;

public partial class InputWindow : ReactiveWindow<InputWindowViewModel>
{
    public InputWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
        this.WhenActivated(d => d(ViewModel!.Input.Subscribe(n => Close(n))));
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}