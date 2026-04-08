using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;

namespace WpfLikeAvaloniaMessageBox.Views;

internal class MessageBoxWindow : Window
{
    public MessageBoxResult Result { get; private set; } = MessageBoxResult.None;
 
    public MessageBoxWindow(string messageBoxText, string caption,
        MessageBoxButton button, MessageBoxImage icon)
    {
        Title = caption;
        CanResize = false;
        SizeToContent = SizeToContent.WidthAndHeight;
        MinWidth = 300;
        MaxWidth = 500;
        WindowStartupLocation = WindowStartupLocation.CenterOwner;
        ShowInTaskbar = false;
 
        var root = new StackPanel
        {
            Margin = new Thickness(20),
            Spacing = 16
        };
 
        // Icon + Text row
        var contentRow = new StackPanel
        {
            Orientation = Orientation.Horizontal,
            Spacing = 14
        };
 
        if (icon != MessageBoxImage.None)
        {
            contentRow.Children.Add(new TextBlock
            {
                Text = GetIconChar(icon),
                FontSize = 36,
                VerticalAlignment = VerticalAlignment.Top,
                Foreground = GetIconBrush(icon)
            });
        }
 
        contentRow.Children.Add(new TextBlock
        {
            Text = messageBoxText,
            TextWrapping = TextWrapping.Wrap,
            MaxWidth = 380,
            VerticalAlignment = VerticalAlignment.Center,
            FontSize = 14
        });
 
        root.Children.Add(contentRow);
 
        // Buttons
        var buttonPanel = new StackPanel
        {
            Orientation = Orientation.Horizontal,
            HorizontalAlignment = HorizontalAlignment.Right,
            Spacing = 8
        };
 
        foreach (var (text, result) in GetButtons(button))
        {
            var btn = new Button
            {
                Content = text,
                MinWidth = 80,
                HorizontalContentAlignment = HorizontalAlignment.Center
            };
            var r = result;
            btn.Click += (_, _) => { Result = r; Close(); };
            buttonPanel.Children.Add(btn);
        }
 
        root.Children.Add(buttonPanel);
        Content = root;
    }
 
    private static string GetIconChar(MessageBoxImage icon) => icon switch
    {
        MessageBoxImage.Error => "⛔",
        MessageBoxImage.Question => "❓",
        MessageBoxImage.Warning => "⚠️",
        MessageBoxImage.Information => "ℹ️",
        _ => ""
    };
 
    private static IBrush GetIconBrush(MessageBoxImage icon) => icon switch
    {
        MessageBoxImage.Error => Brushes.Red,
        MessageBoxImage.Warning => Brushes.Orange,
        MessageBoxImage.Question => Brushes.DodgerBlue,
        MessageBoxImage.Information => Brushes.DodgerBlue,
        _ => Brushes.Gray
    };
 
    private static (string Text, MessageBoxResult Result)[] GetButtons(MessageBoxButton button) => button switch
    {
        MessageBoxButton.OK => [(L("OK"), MessageBoxResult.OK)],
        MessageBoxButton.OKCancel => [(L("OK"), MessageBoxResult.OK), (L("Cancel"), MessageBoxResult.Cancel)],
        MessageBoxButton.YesNo => [(L("Yes"), MessageBoxResult.Yes), (L("No"), MessageBoxResult.No)],
        MessageBoxButton.YesNoCancel => [(L("Yes"), MessageBoxResult.Yes), (L("No"), MessageBoxResult.No), (L("Cancel"), MessageBoxResult.Cancel)],
        _ => [(L("OK"), MessageBoxResult.OK)]
    };
 
    private static string L(string key) => MessageBoxLocalization.Get(key);
}