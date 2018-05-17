using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez;

namespace NezTestProject {
    public static class SoundManager {
        public enum MusicTrack {
            Cool_Morning,
            Warning
        }

        public static void PlayMusic(MusicTrack track, bool repeating = true) {
            PlayMusic(track.ToString(), repeating);
        }

        public static void PlayMusic(string songPath, bool repeating = true) {
            var song = Core.content.Load<Song>("Music\\" + songPath);
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
            Globals.Volume = (Globals.Volume + value).Clamp(0, 1);
            MediaPlayer.Volume = Globals.Volume;
            // TODO: Update volume UI display
        }
    }
}
