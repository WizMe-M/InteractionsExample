using System.Reactive;
using ReactiveUI;

namespace Avalonia.Interactions;

/// <summary>
/// Содержит список Intercation
/// </summary>
public static class Interactions
{
    public static readonly Interaction<Unit, bool> Confirm = new();

    public static readonly Interaction<decimal, decimal?> InputNumber = new();
}