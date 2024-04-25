using System;
using System.IO;
using System.Windows.Input;
using Windows.Media.Core;
using Windows.Media.Playback;
using NAudio.Wave;
using ReactiveUI;


namespace SoundWave.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        public ICommand Btn_PlayPause_OnClick { get; }
        public ICommand Btn_SkipNext_OnClick { get; }
        public ICommand Btn_SkipBack_OnClick { get; }


        private MediaPlayer _mediaPlayer = new MediaPlayer();
        private MediaPlaybackList _mediaPlaybackList = new MediaPlaybackList();
        private bool _isPlaying;
        private TimeSpan _pausePosition;


        public MainWindowViewModel()
        {
            Btn_PlayPause_OnClick = ReactiveCommand.Create(Btn_PlayPause);
            Btn_SkipNext_OnClick = ReactiveCommand.Create(Btn_SkipNext);
            Btn_SkipBack_OnClick = ReactiveCommand.Create(Btn_SkipBack);
            Create();
            _mediaPlayer.Source = _mediaPlaybackList;
        }

        private void Btn_PlayPause()
        {
            try
            {

                if (_isPlaying)
                {
                    _pausePosition = _mediaPlayer.Position;
                    _mediaPlayer.Pause();
                    _isPlaying = false;
                }
                else
                {
                    _mediaPlayer.Position = _pausePosition;
                    _mediaPlayer.Play();
                    _isPlaying = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        
        
        private void Btn_SkipNext()
        {
            _mediaPlaybackList.MoveNext();
        }

        private void Btn_SkipBack()
        {
            _mediaPlaybackList.MovePrevious();
        }

        

        private void Create()
        {
            string[] filePaths = Directory.GetFiles("C:\\Users\\---\\source\\C#\\SoundWave\\Music");
            foreach (var file in filePaths)
            {
                _mediaPlaybackList.Items.Add(new MediaPlaybackItem(MediaSource.CreateFromUri(new Uri($"{file}"))));
            }
            

        }
    }
}

/*
            string mp3FilePath = "C:\\Users\\---\\source\\C#\\SoundWave\\Music\\Test.mp3";
            string wavFilePath = "C:\\Users\\---\\source\\C#\\SoundWave\\Music\\Test.wav";

            using (Mp3FileReader mp3 = new Mp3FileReader(mp3FilePath))
            {
                using (WaveStream pcm = WaveFormatConversionStream.CreatePcmStream(mp3))
                {
                    WaveFileWriter.CreateWaveFile(wavFilePath, pcm);
                }
            }
*/