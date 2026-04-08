# WpfLikeAvaloniaMessageBox
Simple WPF-like MessageBox for Avalonia. 
You can use it from windows, pages, and etc.

It is also available in several languages:
* English
* Russian
* German
* French
* Spanish
* Chinese

## Usage

### Getting the result
```csharp
using Avalonia.Controls;

namespace AvaloniaNavigation;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private async void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        var result = await MessageBox.Show("Save?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
        if (result == MessageBoxResult.Yes)
        {
            MessageBox.Show("Successfully");
        } 
    }
}
```

### Different localizations
```csharp
using Avalonia.Controls;

namespace AvaloniaNavigation;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        // A single line to set the locale
        MessageBoxLocalization.Language = MessageBoxLanguage.Russian;
    }
}
```

### Custom localization
You can also override any language and create your own localization.
```csharp
using Avalonia.Controls;

namespace AvaloniaNavigation;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        // Overriding localization
        MessageBoxLocalization.CustomTranslations[(MessageBoxLanguage.Russian, "No")] = "Не";
        MessageBoxLocalization.Language = MessageBoxLanguage.Russian;
    }

}
```