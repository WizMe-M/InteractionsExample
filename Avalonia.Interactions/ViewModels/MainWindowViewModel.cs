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
            Content = null;
            ShowConfirmDialog = ReactiveCommand.CreateFromTask(ConfirmAsync);
            ShowInformDialog = ReactiveCommand.CreateFromTask(InformAsync);
        }

        [Reactive]
        public ViewModelBase? Content { get; set; }

        public ICommand ShowConfirmDialog { get; }

        public ICommand ShowInformDialog { get; }

        public async Task ConfirmAsync()
        {
            var result = await Interactions.Confirm.Handle(Unit.Default);

            Debug.WriteLine(result ? "Confirmation received" : "Confirmation aborted");

            Content ??= new SubViewModel();
        }

        private async Task InformAsync()
        {
            await Interactions.Inform.Handle(Unit.Default);
        }
    }
}