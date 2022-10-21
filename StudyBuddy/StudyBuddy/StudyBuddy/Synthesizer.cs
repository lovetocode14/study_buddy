using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Threading; 

namespace StudyBuddy
{
    public static class Synthesizer
    {

        public static SpeechSynthesizer voice = new SpeechSynthesizer();

        


        public static void setVoice() 
        {
            voice.SetOutputToDefaultAudioDevice();
            voice.SelectVoice("Microsoft Zira Desktop"); 
        }
       
        public static void speak() 
        {
            voice.SpeakAsync(Form1.input);
        }

        public static void pause() 
        {
            voice.Pause(); 
        }

        public static void resume() 
        {
            voice.Resume(); 
        }

        public static void stop() 
        {
            voice.SpeakAsyncCancelAll();
        }
    }
}
