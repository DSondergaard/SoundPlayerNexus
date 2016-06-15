using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace SoundPlayer
{
    public partial class Form1 : Form
    {
        int currentPlayerNumber = 1;
        List<SoundBox> players = new List<SoundBox>();

        public Form1()
        {
            InitializeComponent();
            currentPlayerNumber = 1;
            
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            AddPlayer();
        }

        private void AddPlayer(string url = null, int volume = -1)
        {
            int y = ((currentPlayerNumber - 1) * 45);

            SoundBox box = new SoundBox(url, volume);
            box.SetBounds(0, y, 850, 45);
            box.Visible = true;
            box.DeleteEvent += new DeleteDelegate(box_DeleteEvent);
            panSoundSet.Controls.Add(box);
            currentPlayerNumber++;
            players.Add(box);

        }

        void box_DeleteEvent(object sender, EventArgs e)
        {
            players.RemoveAll(p => p.UniqueId == ((SoundBox)sender).UniqueId);
            panSoundSet.Controls.Remove(((SoundBox)sender));
            currentPlayerNumber--;
            RedistributeBoxes();
        }

        private void RedistributeBoxes()
        {
            for (int i = 0; i < players.Count; i++)
            {
                int y = i * 45;
                players[i].SetBounds(0, y, 850, 45);
            }
        }

        private void btnSaveCollection_Click(object sender, EventArgs e)
        {
            if (btnSaveCollection.Text == "Save Collection")
            {
                btnSaveCollection.Visible = false;
                tbCollectionName.Visible = true;
                tbCollectionName.Focus();
            }
            else if (btnSaveCollection.Text == "Update Collection")
            {
                string name = labSoundCollectionName.Text;
                var path = Directory.GetCurrentDirectory() + @"\SoundCollections";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                var filePath = Path.Combine(path, name + ".scl");
                File.Create(filePath).Close();

                foreach (var player in players)
                {
                    string s = String.Format("{0}, {1}::", player.fileUrl, player.volume.Value);
                    File.AppendAllText(filePath, s);
                }
            }


        }

        private void tbCollectionName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string name = tbCollectionName.Text;
                var path = Directory.GetCurrentDirectory() + @"\SoundCollections";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                var filePath = Path.Combine(path, name+ ".scl");
                File.Create(filePath).Close();

                foreach (var player in players)
                {
                    string s = String.Format("{0}, {1}::",player.fileUrl, player.volume.Value);
                    File.AppendAllText(filePath, s);
                }                
                
                btnSaveCollection.Visible = true;
                tbCollectionName.Visible = false;
                return;

            }
        }

        private void btnLoadCollection_Click(object sender, EventArgs e)
        {
            currentPlayerNumber = 1;
            panSoundSet.Controls.Clear();
            string line = "";
            var path = Directory.GetCurrentDirectory() + @"\SoundCollections";
            using(var ofd = new OpenFileDialog() { InitialDirectory = path })
            {
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    line = File.ReadAllText(ofd.FileName);
                    labSoundCollectionName.Text = Path.GetFileNameWithoutExtension(ofd.FileName);
                    btnSaveCollection.Text = "Update Collection";
                }
            }
            string[] separator = new string[] { "::" };
            string[] data = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            foreach (string dat in data)
            {
                string[] d = dat.Split(new char[] { ',' });
                string url = d[0].Trim();
                int volume = Convert.ToInt32(d[1].Trim());
                AddPlayer(url, volume);
            }

            
        }

        private void btnNewCollection_Click(object sender, EventArgs e)
        {
            panSoundSet.Controls.Clear();
            players.Clear();
            btnSaveCollection.Text = "Save Collection";
            currentPlayerNumber = 1;
            labSoundCollectionName.Text = "New Sound Collection";

        }
    }
}
