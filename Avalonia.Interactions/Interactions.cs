using System.Reactive;
using ReactiveUI;

namespace Avalonia.Interactions;

/// <summary>
/// Contains constants of type <see cref="Interaction{TInput,TOutput}"/>
/// </summary>
public static class Interactions
{
    public static readonly Interaction<Unit, Unit> Inform = new();

    public static readonly Interaction<Unit, bool> Confirm = new();

    public static readonly Interaction<decimal, decimal?> InputNumber = new();
}