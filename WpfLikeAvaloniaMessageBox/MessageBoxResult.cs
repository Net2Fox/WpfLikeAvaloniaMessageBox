namespace WpfLikeAvaloniaMessageBox;

/// <summary>
/// Specifies which message box button a user clicked. Matches WPF API.
/// </summary>
public enum MessageBoxResult
{
    None = 0,
    OK = 1,
    Cancel = 2,
    Yes = 6,
    No = 7
}