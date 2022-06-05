using System.Diagnostics;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Avalonia.Interactions.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            ShowConfirmDialog = ReactiveCommand.CreateFromTask(ConfirmAsync);
        }

        [Reactive]
        public ViewModelBase? Content { get; set; }
        public ICommand ShowConfirmDialog { get; }

        public async Task ConfirmAsync()
        {
            var result = await Interactions.Confirm.Handle(Unit.Default);

            if (result)
            {
                Debug.WriteLine("Confirmation received");
            }
            else
            {
                Debug.WriteLine("Confirmation aborted");
            }

            Content ??= new SubViewModel();
        }
    }
}