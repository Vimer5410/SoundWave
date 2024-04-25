using System;
using System.IO;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace SoundWave.Views;

public partial class AddMusicWindow : UserControl
{
    public Window Owner { get; }
    private Image _photoImage ;
    private string path;
    private string songname;

    public AddMusicWindow(Window owner)
    {
        InitializeComponent();
        Owner = owner;
        _photoImage = AddMusicImage;
    }
    

    private async void Button_AddMusicImage_OnClick(object? sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Title = "Выберите фото";
        openFileDialog.Filters.Add(new FileDialogFilter { Name = "Файлы изображений", Extensions = { "jpg", "png", "bmp" } });

        string[]? selectedPhotos = await openFileDialog.ShowAsync(Owner);
        
        try
        {
            if (selectedPhotos != null && selectedPhotos.Length > 0)
            {
                Bitmap bitmap = new Bitmap(selectedPhotos[0]);
                if (_photoImage != null) _photoImage.Source = bitmap;
            }  
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
        
    }

    private async void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Title = "Выберите трек";
        openFileDialog.Filters.Add(new FileDialogFilter { Name = "Треки композиций", Extensions = { "mp3", "wav" } });
        string[]? selectedMusicPath = await openFileDialog.ShowAsync(Owner);
        MusicPath.Text = selectedMusicPath[0];
        
        try
        {
            songname = SongName.Text+".mp3";
            path = MusicPath.Text.Replace("\\", "\\\\");
            Console.WriteLine(songname);
            File.Move($"{path}",$"C:\\Users\\---\\source\\C#\\SoundWave\\Music\\{songname}", false);

        }
        catch (Exception exception)
        {
            Console.WriteLine(exception);
            throw;
        }
    }
}