using System.Reactive;
using ReactiveUI;

namespace Avalonia.Interactions.ViewModels;

public class InputWindowViewModel : ViewModelBase
{
    public InputWindowViewModel()
    {
        Number = 0;
        Input = ReactiveCommand.Create(() => Number);
    }

    public InputWindowViewModel(decimal number) : this()
    {
        Number = number;
    }

    public decimal Number { get; set; }
    public ReactiveCommand<Unit, decimal> Input { get; }
}