using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ADB_Commands
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void handleInstallApps()
        {
            CheckBox[] checkBoxes = new CheckBox[] { spotifyCheckBox, audibleCheckBox, amazonAppStoreCheckBox, pandoraCheckBox, appleMusicCheckBox, tidalCheckBox, amazonMusicCheckBox };
            List<string> appNames = new List<string>();


            for (int i=0; i < checkBoxes.Length;i++)
            {
                if (checkBoxes[i].IsChecked == true)                {
                    string appName = checkBoxes[i].Name.Replace("CheckBox", "");
                    appName.Replace(" ", "");
                    appNames.Add(string.Format("{0}.apk", appName));
                }

            }


            string command=" " ;
            foreach(string app in appNames)
            {
                    string appName = app.Replace(".apk", "");

                if (appNames.Count == 1 || appNames.IndexOf(app) == appNames.Count - 1)
                {
                    appName = char.ToUpper(appName[0]) + appName.Substring(1);
                    command += string.Format("echo Installing {0}... Please wait (usually about 30 seconds for each app) && ", appName);
                    command += "adb install" + " " + "../apk/" + app;

                }
                else
                {
                    
                    appName = char.ToUpper(appName[0]) + appName.Substring(1);
                    command += string.Format("echo Installing {0}... Please wait (usually about 30 seconds for each app) && ", appName);
                    command += "adb install" + " " + "../apk/" + app + "&&";
                }
            }
            try
            {
                
                System.Diagnostics.Process.Start("cmd.exe", ("/K cd scrcpy && " + command));

            }
            catch
            {

            }

        }
        private void installAppsButton_Click(object sender, RoutedEventArgs e)
        {
            handleInstallApps();


        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void scrcpyButton_Click(object sender, RoutedEventArgs e)
        {


            System.Diagnostics.Process.Start("cmd.exe", "/C cd scrcpy && scrcpy -h && scrcpy.exe --max-size 320");

        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            
            emailLabel.Content = emailTextBox.Text.ToString();
            passwordLabel.Content = passwordTextBox.Text.ToString();
        }

        private void emailTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            emailTextBox.Text = "";
        }
        private void emailTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (emailTextBox.Text.Length < 1)
            {
                emailTextBox.Text = "Email Address";
            }
        }

        private void passwordTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordTextBox.Text = "";
        }

      

        private void passwordTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (passwordTextBox.Text.Length < 1)
            {
                passwordTextBox.Text = "Password";
            }
        }

        private void emailLabel_GotFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void passwordLabel_GotFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}
