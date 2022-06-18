﻿using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Xaml.Interactivity;

namespace Avalonia.Xaml.Interactions.Events;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class PointerLeaveEventBehavior<T> : Behavior<T> where T : Control
{
    /// <summary>
    /// 
    /// </summary>
    public static readonly StyledProperty<RoutingStrategies> RoutingStrategiesProperty = 
        AvaloniaProperty.Register<PointerLeaveEventBehavior<T>, RoutingStrategies>(
            nameof(RoutingStrategies),
            RoutingStrategies.Direct);

    /// <summary>
    /// 
    /// </summary>
    public RoutingStrategies RoutingStrategies
    {
        get => GetValue(RoutingStrategiesProperty);
        set => SetValue(RoutingStrategiesProperty, value);
    }

    /// <inheritdoc />
    protected override void OnAttachedToVisualTree()
    {
        AssociatedObject?.AddHandler(InputElement.PointerLeaveEvent, PointerLeave, RoutingStrategies);
    }

    /// <inheritdoc />
    protected override void OnDetachedFromVisualTree()
    {
        AssociatedObject?.RemoveHandler(InputElement.PointerLeaveEvent, PointerLeave);
    }

    private void PointerLeave(object? sender, PointerEventArgs e)
    {
        OnPointerLeave(sender, e);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void OnPointerLeave(object? sender, PointerEventArgs e)
    {
    }
}
