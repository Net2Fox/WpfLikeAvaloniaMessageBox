using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using WpfLikeAvaloniaMessageBox.Views;

namespace WpfLikeAvaloniaMessageBox;

/// <summary>
/// Displays a message box. API mirrors System.Windows.MessageBox from WPF.
/// All Show overloads are async since Avalonia uses async dialogs.
/// </summary>
public static class MessageBox
{
    /// <summary>Show a simple message.</summary>
    public static Task<MessageBoxResult> Show(string messageBoxText)
        => Show(null, messageBoxText, "", MessageBoxButton.OK, MessageBoxImage.None);
 
    /// <summary>Show a message with caption.</summary>
    public static Task<MessageBoxResult> Show(string messageBoxText, string caption)
        => Show(null, messageBoxText, caption, MessageBoxButton.OK, MessageBoxImage.None);
 
    /// <summary>Show a message with caption and buttons.</summary>
    public static Task<MessageBoxResult> Show(string messageBoxText, string caption, MessageBoxButton button)
        => Show(null, messageBoxText, caption, button, MessageBoxImage.None);
 
    /// <summary>Show a message with caption, buttons and icon.</summary>
    public static Task<MessageBoxResult> Show(string messageBoxText, string caption,
        MessageBoxButton button, MessageBoxImage icon)
        => Show(null, messageBoxText, caption, button, icon);
 
    /// <summary>Show a message relative to an owner window.</summary>
    public static Task<MessageBoxResult> Show(Window? owner, string messageBoxText)
        => Show(owner, messageBoxText, "", MessageBoxButton.OK, MessageBoxImage.None);
 
    /// <summary>Show a message relative to an owner window with caption.</summary>
    public static Task<MessageBoxResult> Show(Window? owner, string messageBoxText, string caption)
        => Show(owner, messageBoxText, caption, MessageBoxButton.OK, MessageBoxImage.None);
 
    /// <summary>Show a message relative to an owner window with caption and buttons.</summary>
    public static Task<MessageBoxResult> Show(Window? owner, string messageBoxText, string caption,
        MessageBoxButton button)
        => Show(owner, messageBoxText, caption, button, MessageBoxImage.None);
 
    /// <summary>Full overload with all parameters.</summary>
    public static async Task<MessageBoxResult> Show(Window? owner, string messageBoxText, string caption,
        MessageBoxButton button, MessageBoxImage icon)
    {
        var window = new MessageBoxWindow(messageBoxText, caption, button, icon);
 
        if (owner is not null)
        {
            await window.ShowDialog(owner);
        }
        else
        {
            // Try to find the active window as fallback owner
            var topLevel = GetActiveWindow();
            if (topLevel is not null)
                await window.ShowDialog(topLevel);
            else
                await window.ShowDialog(new Window { IsVisible = false }); // headless fallback
        }
 
        return window.Result;
    }
 
    private static Window? GetActiveWindow()
    {
        if (Application.Current?.ApplicationLifetime
            is Avalonia.Controls.ApplicationLifetimes.IClassicDesktopStyleApplicationLifetime desktop)
        {
            return desktop.MainWindow;
        }
        return null;
    }
}