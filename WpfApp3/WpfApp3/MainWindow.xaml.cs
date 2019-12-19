using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Speech.Synthesis;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using WpfAnimatedGif;
using System.Windows.Shapes;
using System.IO;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SpeechSynthesizer speak = new SpeechSynthesizer();
        List<TextBox> words = new List<TextBox>();
        Random rng = new Random();
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public MainWindow()
        {
            
            InitializeComponent();
            getBoxes();
            speak.SpeakCompleted += Speak_SpeakCompleted;
        }

        private void BtnSpeak_Click(object sender, RoutedEventArgs e)
        {
            string line = "";

            line += "Thou " + words[0].Text + " " + words[1].Text + " " + words[2].Text;

            speak.SpeakAsync(line);
            bool animate = false;
            ImageAnimationController controller = new ImageAnimationController;
           
            

        }

        private void Speak_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            
        }

        private void getBoxes()
        {
            words.Add(tbx1st);
            words.Add(tbx2nd);
            words.Add(tbx3rd);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string insult1 = "";
            StreamReader getInsults1 = new StreamReader(desktopPath + "/the insult folder/first.txt");
            int lineCount = File.ReadLines(desktopPath + "/the insult folder/first.txt").Count();
            int randomLine = rng.Next(0, lineCount);
            for (int i = 0; i < randomLine+1; i++)
            {
                insult1 = getInsults1.ReadLine();
            }
            tbx1st.Text = insult1;

            string insult2 = "";
            StreamReader getInsults2 = new StreamReader(desktopPath + "/the insult folder/second.txt");
            lineCount = File.ReadLines(desktopPath + "/the insult folder/second.txt").Count();
            randomLine = rng.Next(0, lineCount);
            for (int i = 0; i < randomLine+1; i++)
            {
                insult2 = getInsults2.ReadLine();
            }
            tbx2nd.Text = insult2;

            string insult3 = "";
            StreamReader getInsults3 = new StreamReader(desktopPath + "/the insult folder/third.txt");
            lineCount = File.ReadLines(desktopPath + "/the insult folder/third.txt").Count();
            randomLine = rng.Next(0, lineCount);
            for (int i = 0; i < randomLine+1; i++)
            {
                insult3 = getInsults3.ReadLine();
            }
            tbx3rd.Text = insult3;

        }
    }
}
