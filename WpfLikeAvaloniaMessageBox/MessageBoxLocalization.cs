using System.Collections.Generic;

namespace WpfLikeAvaloniaMessageBox;

/// <summary>
/// Provides localized button labels. Can be extended with custom translations.
/// </summary>
public static class MessageBoxLocalization
{
    /// <summary>
    /// Global language used by all MessageBox calls. Default: English.
    /// Set once at startup or change at any time.
    /// </summary>
    public static MessageBoxLanguage Language { get; set; } = MessageBoxLanguage.English;
 
    /// <summary>
    /// Custom translations override built-in ones. Key = (Language, ButtonKey).
    /// ButtonKey: "OK", "Cancel", "Yes", "No".
    /// </summary>
    public static Dictionary<(MessageBoxLanguage Lang, string Key), string> CustomTranslations { get; } = new();
 
    internal static string Get(string key)
    {
        if (CustomTranslations.TryGetValue((Language, key), out var custom))
            return custom;
 
        return (Language, key) switch
        {
            (MessageBoxLanguage.Russian, "OK")     => "ОК",
            (MessageBoxLanguage.Russian, "Cancel")  => "Отмена",
            (MessageBoxLanguage.Russian, "Yes")     => "Да",
            (MessageBoxLanguage.Russian, "No")      => "Нет",
 
            (MessageBoxLanguage.German, "OK")       => "OK",
            (MessageBoxLanguage.German, "Cancel")   => "Abbrechen",
            (MessageBoxLanguage.German, "Yes")      => "Ja",
            (MessageBoxLanguage.German, "No")       => "Nein",
 
            (MessageBoxLanguage.French, "OK")       => "OK",
            (MessageBoxLanguage.French, "Cancel")   => "Annuler",
            (MessageBoxLanguage.French, "Yes")      => "Oui",
            (MessageBoxLanguage.French, "No")       => "Non",
 
            (MessageBoxLanguage.Spanish, "OK")      => "Aceptar",
            (MessageBoxLanguage.Spanish, "Cancel")  => "Cancelar",
            (MessageBoxLanguage.Spanish, "Yes")     => "Sí",
            (MessageBoxLanguage.Spanish, "No")      => "No",
 
            (MessageBoxLanguage.Chinese, "OK")      => "确定",
            (MessageBoxLanguage.Chinese, "Cancel")  => "取消",
            (MessageBoxLanguage.Chinese, "Yes")     => "是",
            (MessageBoxLanguage.Chinese, "No")      => "否",
 
            // English / fallback
            (_, "OK")     => "OK",
            (_, "Cancel") => "Cancel",
            (_, "Yes")    => "Yes",
            (_, "No")     => "No",
            _ => key
        };
    }
}
