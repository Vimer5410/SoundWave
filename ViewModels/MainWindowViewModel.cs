using System;
using System.Windows.Input;
using Windows.Media.Core;
using Windows.Media.Playback;
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
        private bool _isPlayed;



        public MainWindowViewModel()
        {
            Btn_PlayPause_OnClick = ReactiveCommand.Create(Btn_PlayPause);
            Btn_SkipNext_OnClick = ReactiveCommand.Create(Btn_SkipNext);
            Btn_SkipBack_OnClick = ReactiveCommand.Create(Btn_SkipBack);

            Create();
        }

        private void Btn_PlayPause()
        {
            try
            {
                _mediaPlayer.Source = _mediaPlaybackList;

                if (_isPlayed == false)
                {
                    MediaPlay();
                    _isPlayed = true;
                }
                else
                {
                    MediaPause();
                    _isPlayed = false;
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

        private TimeSpan MediaPause()
        {
            _mediaPlayer.Pause();
            var pos = _mediaPlayer.Position;
            return pos;
        }

        private void MediaPlay()
        {
            _mediaPlayer.Position = MediaPause();
            _mediaPlayer.Play();
        }

        private void Create()
        {
            _mediaPlaybackList.Items.Add(new MediaPlaybackItem(
                MediaSource.CreateFromUri(
                    new Uri(@".wav"))));
            
            _mediaPlaybackList.Items.Add(new MediaPlaybackItem(
                MediaSource.CreateFromUri(
                    new Uri(@".wav"))));

        }
    }
}
