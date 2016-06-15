using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoundPlayer
{
    public delegate void DeleteDelegate(object sender, EventArgs e);

    public partial class SoundBox : Control
    {
        private WMPLib.WindowsMediaPlayer player;
        Label label;
        TextBox textbox;
        Button browse;
        CheckBox loop;
        Button play;
        Button pause;
        Button stop;
        public TrackBar volume;
        Button fade;
        Button delete;
        Timer fadeTimer;
        public String fileUrl;
        public Guid UniqueId;

        public event DeleteDelegate DeleteEvent;

        public SoundBox(string url = null, int volume = -1)
        {
            UniqueId = Guid.NewGuid();
            InitializeComponent();
            Setup();
            if (url != null)
            {
                textbox.Text = url;
                fileUrl = url;
            }
            if (volume != -1)
            {
                this.volume.Value = volume;
            }
        }

        private void Setup()
        {
            player = new WMPLib.WindowsMediaPlayer();

            label = new Label();
            label.Name = "Label";
            label.Text = "Player ";
            label.SetBounds(10, 10 + 3, 50, 18);
            label.Visible = true;
            Controls.Add(label);

            textbox = new TextBox();
            textbox.Name = "TextBox";
            textbox.SetBounds(70, 10, 250, 25);
            textbox.Visible = true;
            textbox.ReadOnly = true;
            Controls.Add(textbox);

            browse = new Button();
            browse.Name = "Browse";
            browse.SetBounds(325, 10, 25, 25);
            browse.Text = "...";
            browse.Click += new EventHandler(browse_Click);
            browse.Visible = true;
            Controls.Add(browse);

            loop = new CheckBox();
            loop.Name = "Loop";
            loop.Text = "Loop";
            loop.SetBounds(355, 10 + 3, 50, 25);
            loop.AutoSize = true;
            loop.Visible = true;
            Controls.Add(loop);

            play = new Button();
            play.Name = "Play";
            play.SetBounds(410, 10, 50, 25);
            play.Text = "Play";
            play.Click += new EventHandler(play_Click);
            play.Visible = true;
            Controls.Add(play);

            pause = new Button();
            pause.Name = "Pause";
            pause.SetBounds(460, 10, 55, 25);
            pause.Text = "Pause";
            pause.Click += new EventHandler(pause_Click);
            pause.Visible = true;
            Controls.Add(pause);

            stop = new Button();
            stop.Name = "Stop";
            stop.SetBounds(515, 10, 50, 25);
            stop.Text = "Stop";
            stop.Click += new EventHandler(stop_Click);
            stop.Visible = true;
            Controls.Add(stop);

            volume = new TrackBar();
            volume.Name = "Volume";
            volume.SetBounds(565, 10, 200, 25);
            volume.Minimum = 0;
            volume.Maximum = 100;
            volume.Value = 50;
            volume.ValueChanged += new EventHandler(volume_ValueChanged);
            volume.Visible = true;
            Controls.Add(volume);

            fade = new Button(); 
            fade.Name = "Fade";
            fade.SetBounds(765, 10, 50, 25);
            fade.Text = "Fade";
            fade.Click += new EventHandler(fade_Click);
            fade.Visible = true;
            Controls.Add(fade);

            delete = new Button();
            delete.Name = "Delete";
            delete.SetBounds(820, 10, 25, 25);
            delete.BackColor = Color.DarkRed;
            delete.ForeColor = Color.Wheat;
            delete.Text = "X";
            delete.Click += new EventHandler(delete_Click);
            delete.Visible = true;
            Controls.Add(delete);
        }

        void volume_ValueChanged(object sender, EventArgs e)
        {
            var bar = (TrackBar)sender;
            player.settings.volume = bar.Value;
        }

        void browse_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;

            using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = false })
            {
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    textbox.Text = ofd.FileName;
                    fileUrl = ofd.FileName;
                    textbox.Select(); // to Set Focus
                    textbox.Select(textbox.Text.Length, 0);
                    textbox.DeselectAll();
                }
            }
        }

        void play_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            (player.settings as WMPLib.IWMPSettings).setMode("loop", loop.Checked);
            player.URL = textbox.Text;
            player.controls.play();
            player.settings.volume = volume.Value;
        }

        void stop_Click(object sender, EventArgs e)
        {
            player.controls.stop();
        }

        void delete_Click(object sender, EventArgs e)
        {
            DeleteEvent.Invoke(this, e);
        }

        void pause_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            if (btn.Text == "Pause")
            {
                player.controls.pause();
                btn.Text = "Resume";
            }
            else if (btn.Text == "Resume")
            {
                player.controls.play();
                btn.Text = "Pause";
            }

        }

        void fade_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            if (btn.Text == "Fade")
            {
                fadeTimer = new Timer();
                fadeTimer.Interval = 100;
                fadeTimer.Tick += new EventHandler(fade_Tick);
                fadeTimer.Start();
                btn.Text = "Stop";
            }
            else if (btn.Text == "Stop")
            {
                fadeTimer.Stop();
                fadeTimer = null;
                btn.Text = "Fade";
            }
        }

        void fade_Tick(object sender, EventArgs e)
        {
            var tim = (Timer)sender;
            if (volume.Value >= 1)
                volume.Value -= 1;
            else
            {
                volume.Value = 0;
                tim.Stop();
                player.controls.stop();
            }

        } 

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
    }
}
