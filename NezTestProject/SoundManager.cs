using Microsoft.Xna.Framework.Media;
using Nez;

namespace NezTestProject {
    public static class SoundManager {
        public enum MusicTrack {
            Cool_Morning,
            Warning
        }

        private static string _currentSong;

        public static void PlayMusic(MusicTrack track, bool repeating = true) {
            PlayMusic(track.ToString(), repeating);
        }

        public static void PlayMusic(string songName, bool repeating = true) {
            // If the song is already playing, then bail out
            if (_currentSong == songName)
                return;
            _currentSong = songName;

            // Load and play the song
            var song = Core.content.Load<Song>("Music\\" + songName);
            MediaPlayer.Play(song);
            MediaPlayer.Volume = Globals.Volume;
            MediaPlayer.IsRepeating = repeating;
        }

        public static void SetVolume(float value) {
            Globals.Volume = value.Clamp(0f, 1f);
            MediaPlayer.Volume = Globals.Volume;
            // TODO: Update volume UI display
        }

        public static void RaiseVolume(float value = 0.1f) {
            Globals.Volume = (Globals.Volume + value).Clamp(0, 1);
            MediaPlayer.Volume = Globals.Volume;
            // TODO: Update volume UI display
        }

        public static void LowerVolume(float value = 0.1f) {
            Globals.Volume = (Globals.Volume - value).Clamp(0, 1);
            MediaPlayer.Volume = Globals.Volume;
            // TODO: Update volume UI display
        }
    }
}
