using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
    public class OldAudioSystem
    {
        public void PlayMP3(string fileName)
        {
            Console.WriteLine($"Воспроизводится MP3 файл: {fileName}");
        }
    }

    public interface INewAudioSystem
    {
        void PlayWAV(string fileName);
    }

    public class NewAudioSystem : INewAudioSystem
    {
        public void PlayWAV(string fileName)
        {
            Console.WriteLine($"Воспроизводится WAV файл: {fileName}");
        }
    }

    public class AudioAdapter : INewAudioSystem
    {
        private OldAudioSystem _oldAudioSystem;

        public AudioAdapter(OldAudioSystem oldAudioSystem)
        {
            _oldAudioSystem = oldAudioSystem;
        }

        public void PlayWAV(string fileName)
        {
            _oldAudioSystem.PlayMP3(fileName.Replace(".wav", ".mp3"));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Adapter
            OldAudioSystem oldAudioSystem = new OldAudioSystem();
            INewAudioSystem audioAdapter = new AudioAdapter(oldAudioSystem);

            audioAdapter.PlayWAV("audio-name.wav");

            Console.ReadLine();
        }
    }
}
