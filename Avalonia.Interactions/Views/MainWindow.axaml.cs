using System.Reactive;
using System.Threading.Tasks;
using Avalonia.Interactions.ViewModels;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using MessageBox.Avalonia;
using MessageBox.Avalonia.DTO;
using MessageBox.Avalonia.Enums;
using ReactiveUI;

namespace Avalonia.Interactions.Views
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.WhenActivated(d =>
            {
                d(Interactions.Confirm.RegisterHandler(ConfirmAsync));
                d(Interactions.InputNumber.RegisterHandler(InputAsync));
            });
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private async Task ConfirmAsync(InteractionContext<Unit, bool> interaction)
        {
            var confirmationWindow = MessageBoxManager.GetMessageBoxStandardWindow(new MessageBoxStandardParams
            {
                ButtonDefinitions = ButtonEnum.OkAbort,
                ContentTitle = "Confirmation",
                ContentMessage = "Do you really want to do this?",
                Icon = MessageBox.Avalonia.Enums.Icon.Question
            });

            var button = await confirmationWindow.ShowDialog(this);
            var result = button is ButtonResult.Ok;
            interaction.SetOutput(result);
        }

        private async Task InputAsync(InteractionContext<decimal, decimal?> interaction)
        {
            var dialog = new InputWindow
            {
                DataContext = new InputWindowViewModel(interaction.Input)
            };

            var result = await dialog.ShowDialog<decimal?>(this);
            interaction.SetOutput(result);
        }
    }
}