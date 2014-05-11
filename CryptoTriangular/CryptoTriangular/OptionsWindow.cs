using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;
using Logic;

namespace CryptoTriangular
{
    public partial class OptionsWindow : Form
    {
        public OptionsWindow()
        {
            InitializeComponent();
            SetOptions();
        }

        private void SetOptions()
        {
            timerInterval.Value = Options.Instance.TimerInterval / 1000;
            if (Options.Instance.HideBalloonAfter5thDisplay == true)
            {
                cb_hide_balloon.Checked = true;
            }
            else
            {
                cb_hide_balloon.Checked = false;
            }

            if (Options.Instance.DisplayBalloonWhenPercentChanges == true)
                cb_DisplayBaloonWhenPercentChanges.Checked = true;
            else
                cb_DisplayBaloonWhenPercentChanges.Checked = false;

            if (Options.Instance.SoundNotification == true)
                cb_sound.Checked = true;
            else
                cb_sound.Checked = false;

            if (Options.Instance.OnlyFavouriteTracks == true)
                cb_favouritePaths.Checked = true;
            else
                cb_favouritePaths.Checked = false;

            if (Options.Instance.definedTracks.Count > 0)
            {
                string test = String.Join(Environment.NewLine, Options.Instance.definedTracks.ToArray());
                richTextBox_tracks.Clear();
                richTextBox_tracks.AppendText(test);
            }

            if (Options.Instance.displayAllPaths == false)
                cb_displayAllpaths.Checked = false;
            else
                cb_displayAllpaths.Checked = true;

            if (Options.Instance.complexArbitrageAnalysis == false)
                cb_complexAnalysis.Checked = false;
            else
                cb_complexAnalysis.Checked = true;
        }

        private void GetOptions()
        {
            Options.Instance.TimerInterval = timerInterval.Value * 1000;
            Options.Instance.HideBalloonAfter5thDisplay = cb_hide_balloon.Checked;
            Options.Instance.DisplayBalloonWhenPercentChanges = cb_DisplayBaloonWhenPercentChanges.Checked;
            Options.Instance.SoundNotification = cb_sound.Checked;
            Options.Instance.minPercentBenefit = Convert.ToDouble(minPercentBenefit.Value);
            Options.Instance.OnlyFavouriteTracks = cb_favouritePaths.Checked;
            string test = String.Join(Environment.NewLine, Options.Instance.definedTracks.ToArray());
            richTextBox_tracks.Clear();
            richTextBox_tracks.AppendText(test);
            Options.Instance.displayAllPaths = cb_displayAllpaths.Checked;
            Options.Instance.complexArbitrageAnalysis = cb_complexAnalysis.Checked;
        }

        private void OptionsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            GetOptions();
        }

        private void cb_hide_balloon_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_hide_balloon.Checked == true)
                Options.Instance.HideBalloonAfter5thDisplay = true;
            else
                Options.Instance.HideBalloonAfter5thDisplay = false;
        }

        private void cb_DisplayBaloonWhenPercentChanges_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_DisplayBaloonWhenPercentChanges.Checked == true)
                Options.Instance.DisplayBalloonWhenPercentChanges = true;
            else
                Options.Instance.DisplayBalloonWhenPercentChanges = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = (CheckBox)sender;
            panel_favorite.Enabled = cb_favouritePaths.Checked; 
        }

        private void addPath_Click(object sender, EventArgs e)
        {
            Track track = new Track();
            string textTrack = textBox_track.Text.ToString();
            if(track.checkTrack(textTrack)&& !Options.Instance.definedTracks.Exists(element => element==textTrack)){
                Options.Instance.definedTracks.Add(textTrack);
            }
            string test = String.Join(Environment.NewLine, Options.Instance.definedTracks.ToArray());
            richTextBox_tracks.Clear();
            richTextBox_tracks.AppendText(test);
        }

        private void cb_displayAllpaths_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_displayAllpaths.Checked == true)
            {
                panelArbitrage.Enabled = false;
            }
            else
                panelArbitrage.Enabled = true;
        }

        private void btc_remove_Click(object sender, EventArgs e)
        {
            Track track = new Track();
            string textTrack = textBox_track.Text.ToString();
            if (track.checkTrack(textTrack) && Options.Instance.definedTracks.Exists(element => element == textTrack))
            {
                Options.Instance.definedTracks.Remove(textTrack);
            }
            string test = String.Join(Environment.NewLine, Options.Instance.definedTracks.ToArray());
            richTextBox_tracks.Clear();
            richTextBox_tracks.AppendText(test);
        }

    }
}
