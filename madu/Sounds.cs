using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;


namespace C_Sharp_TARgv24
{
    internal class Sounds
    {
        private AudioFileReader eatFile, gameoverFile, bgFile;
        private WaveOutEvent eatOut, gameoverOut, bgOut;

        public Sounds()
        {
            eatFile = new AudioFileReader("eat.mp3");
            gameoverFile = new AudioFileReader("gameover.mp3");
            bgFile = new AudioFileReader("bg.mp3");
            eatOut = new WaveOutEvent();
            gameoverOut = new WaveOutEvent();
            bgOut = new WaveOutEvent();
        }

        public void PlayEat()
        {
            using (var reader = new AudioFileReader("eat.mp3"))
            using (var output = new NAudio.Wave.WaveOutEvent())
            {
                output.Init(reader);
                output.Play();
                // Дать звуку доиграть (иначе сразу завершится!)
                while (output.PlaybackState == NAudio.Wave.PlaybackState.Playing)
                {
                    System.Threading.Thread.Sleep(10);
                }
            }
        }

        public void PlayGameOver()
        {
            gameoverFile.Position = 0;
            using (var outEvent = new WaveOutEvent())
            {
                outEvent.Init(gameoverFile);
                outEvent.Play();
                // Ждём окончания (иначе звук не доиграет)
                while (outEvent.PlaybackState == PlaybackState.Playing)
                {
                    System.Threading.Thread.Sleep(20);
                }
            }
        }

        public void PlayMusic()
        {
            bgFile.Position = 0;
            bgOut.Init(bgFile);
            bgOut.Play();
        }

        public void StopMusic()
        {
            bgOut.Stop();
        }
    }
}

