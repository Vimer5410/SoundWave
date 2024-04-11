using Avalonia.Controls;
using Avalonia.Interactivity;

namespace SoundWave.Views;

public partial class MainWindow : Window
{
    

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_ShowSettings_OnClick(object? sender, RoutedEventArgs e)
    {
        HomePage.IsVisible = false;
        ContentControl.Content = new SettingsWindow();
        
    }

    private void Button_ShowMain_OnClick(object? sender, RoutedEventArgs e)
    {
        if (HomePage.IsVisible is not true)
        {
            HomePage.IsVisible = true;
            ContentControl.Content = "";
        }
        
    }

    private void Button_ShowAddMusic_OnClick(object? sender, RoutedEventArgs e)
    {
        HomePage.IsVisible = false;
        ContentControl.Content = new AddMusicWindow();
    }
}