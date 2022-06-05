using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Avalonia.Interactions.ViewModels;

public class SubViewModel : ViewModelBase
{
    public SubViewModel()
    {
        Number = 0;
        ShowInputDialog = ReactiveCommand.CreateFromTask(InputAsync);
    }

    [Reactive]
    public decimal Number { get; set; }

    public ICommand ShowInputDialog { get; }

    private async Task InputAsync()
    {
        var result = await Interactions.InputNumber.Handle(Number);

        Number = result ?? Number;
    }
}