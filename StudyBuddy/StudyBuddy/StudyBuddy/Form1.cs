using System;
using System.Drawing;
using System.Windows.Forms; 
using System.Speech.Synthesis;


namespace StudyBuddy
{

    // TODO: Create highlight word while reading
    // TODO: Create Menu (Export to MP3, change theme, license) 
    // TODO: Add libgen API 
    // TODO: Add epub/pdf, etc support
    // TODO: Create translator
    // TODO: Private getters and setters
    public partial class Form1 : Form
    {
        public static string input = "Once upon a midnight dreary, while I pondered, weak and weary...";
        bool playHasBeenClicked = false;
        bool playing = false;
        bool stopped = false;
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Synthesizer.setVoice();
            Synthesizer.voice.SpeakProgress += new EventHandler<SpeakProgressEventArgs>(voice_Progress);
            Synthesizer.voice.SpeakCompleted += new EventHandler<SpeakCompletedEventArgs>(voice_Ended); 
        }

        private void voice_Ended(object sender, SpeakCompletedEventArgs e)
        {
            playing = false;
            stopped = true;
            play_pause.IconChar = FontAwesome.Sharp.IconChar.PlayCircle; 
        }

        private void voice_Progress(object sender, SpeakProgressEventArgs e)
        {
            
            rtbUserInput.HideSelection= false;
            //rtbUserInput.Show();  
            //rtbUserInput.SelectionBackColor = Color.Gold;

            int textPosition = e.CharacterPosition;
            //Color original = rtbUserInput.ForeColor;

            //String currentWord;
            //currentWord = rtbUserInput.SelectedText;
            //here will set text color, but it does not set it back after like HideSelection does
            //rtbUserInput.SelectionColor = Color.Yellow;

            //Tried this, didn't work (I used aysnc in the method declaration don't worry about that) 
            //await Task.Delay(500); 
            //rtbUserInput.SelectionColor = original; 

            rtbUserInput.Find(e.Text, textPosition, RichTextBoxFinds.WholeWord);
            
           
        }

        
        private void Language_Click(object sender, EventArgs e)
        {

        }

        private void Speed_Click(object sender, EventArgs e)
        {

        }

       

        private void studyBuddy_Click(object sender, EventArgs e)
        {

        }

        private void play_pause_Click(object sender, EventArgs e)
        {


            if (!playHasBeenClicked)
            {
                Synthesizer.speak();
                playHasBeenClicked = true;
                playing = true;
                play_pause.IconChar = FontAwesome.Sharp.IconChar.PauseCircle;
            }

            else
            {
                if (stopped)
                {
                    Synthesizer.speak();
                    stopped = false;
                    playing = true;
                    play_pause.IconChar = FontAwesome.Sharp.IconChar.PauseCircle;  
                }


                else if (playing)
                {
                    Synthesizer.pause();
                    play_pause.IconChar = FontAwesome.Sharp.IconChar.PlayCircle;
                    playing = false;

                }

                else
                {
                    Synthesizer.resume();
                    playing = true;

                    play_pause.IconChar = FontAwesome.Sharp.IconChar.PauseCircle;
                }

            }
                
                //playHasBeenClicked = true;
                //isPlaying = true;
                //play_pause.IconChar = FontAwesome.Sharp.IconChar.PauseCircle;
                //here add thread to be able to switch between Play/Pause
               //also may be a good idea to use thread terminate to stop, or for stop when resetting
            

           

        }

       

        
        

        private void Restart_Click(object sender, EventArgs e)
        {
            
            Synthesizer.resume(); 
            Synthesizer.stop();
            stopped = true;
            
            playing = false;
            play_pause.IconChar = FontAwesome.Sharp.IconChar.PlayCircle; 
        }

        private void Copyright_Click(object sender, EventArgs e)
        {

        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
             
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }


        //menu panel mouse_down moving of form
        private bool mouseDown;
        private Point lastLocation;

        private void MenuPanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void MenuPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void MenuPanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void minimizeButton_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void DialectBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rtbUserInput_TextChanged(object sender, EventArgs e)
        {
            input = rtbUserInput.Text; 
        }

        bool hasBeenClicked = false;
       

        private void resetText_Click(object sender, EventArgs e)
        {
            rtbUserInput.Text = String.Empty;  
        }

        private void rtbUserInput_Click(object sender, EventArgs e)
        {
            if (!hasBeenClicked) 
            {
                rtbUserInput.ResetText();
                hasBeenClicked = true; 
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }
    }
}
