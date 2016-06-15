namespace SoundPlayer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAddPlayer = new System.Windows.Forms.Button();
            this.panSoundSet = new System.Windows.Forms.Panel();
            this.btnSaveCollection = new System.Windows.Forms.Button();
            this.tbCollectionName = new System.Windows.Forms.TextBox();
            this.btnLoadCollection = new System.Windows.Forms.Button();
            this.labSoundCollectionName = new System.Windows.Forms.Label();
            this.btnNewCollection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddPlayer
            // 
            this.btnAddPlayer.Location = new System.Drawing.Point(12, 446);
            this.btnAddPlayer.Name = "btnAddPlayer";
            this.btnAddPlayer.Size = new System.Drawing.Size(75, 23);
            this.btnAddPlayer.TabIndex = 0;
            this.btnAddPlayer.Text = "Add Player";
            this.btnAddPlayer.UseVisualStyleBackColor = true;
            this.btnAddPlayer.Click += new System.EventHandler(this.btnAddPlayer_Click);
            // 
            // panSoundSet
            // 
            this.panSoundSet.AutoScroll = true;
            this.panSoundSet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panSoundSet.Location = new System.Drawing.Point(0, 35);
            this.panSoundSet.Name = "panSoundSet";
            this.panSoundSet.Size = new System.Drawing.Size(860, 405);
            this.panSoundSet.TabIndex = 1;
            // 
            // btnSaveCollection
            // 
            this.btnSaveCollection.Location = new System.Drawing.Point(93, 446);
            this.btnSaveCollection.Name = "btnSaveCollection";
            this.btnSaveCollection.Size = new System.Drawing.Size(116, 23);
            this.btnSaveCollection.TabIndex = 2;
            this.btnSaveCollection.Text = "Save Collection";
            this.btnSaveCollection.UseVisualStyleBackColor = true;
            this.btnSaveCollection.Click += new System.EventHandler(this.btnSaveCollection_Click);
            // 
            // tbCollectionName
            // 
            this.tbCollectionName.Location = new System.Drawing.Point(93, 448);
            this.tbCollectionName.Name = "tbCollectionName";
            this.tbCollectionName.Size = new System.Drawing.Size(116, 20);
            this.tbCollectionName.TabIndex = 3;
            this.tbCollectionName.Visible = false;
            this.tbCollectionName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCollectionName_KeyDown);
            // 
            // btnLoadCollection
            // 
            this.btnLoadCollection.Location = new System.Drawing.Point(226, 446);
            this.btnLoadCollection.Name = "btnLoadCollection";
            this.btnLoadCollection.Size = new System.Drawing.Size(100, 23);
            this.btnLoadCollection.TabIndex = 4;
            this.btnLoadCollection.Text = "Load Collection";
            this.btnLoadCollection.UseVisualStyleBackColor = true;
            this.btnLoadCollection.Click += new System.EventHandler(this.btnLoadCollection_Click);
            // 
            // labSoundCollectionName
            // 
            this.labSoundCollectionName.Font = new System.Drawing.Font("Gill Sans Nova Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labSoundCollectionName.Location = new System.Drawing.Point(0, 8);
            this.labSoundCollectionName.Name = "labSoundCollectionName";
            this.labSoundCollectionName.Size = new System.Drawing.Size(860, 21);
            this.labSoundCollectionName.TabIndex = 5;
            this.labSoundCollectionName.Text = "New Sound Collection";
            this.labSoundCollectionName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNewCollection
            // 
            this.btnNewCollection.Location = new System.Drawing.Point(332, 445);
            this.btnNewCollection.Name = "btnNewCollection";
            this.btnNewCollection.Size = new System.Drawing.Size(124, 23);
            this.btnNewCollection.TabIndex = 6;
            this.btnNewCollection.Text = "New Collection";
            this.btnNewCollection.UseVisualStyleBackColor = true;
            this.btnNewCollection.Click += new System.EventHandler(this.btnNewCollection_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 477);
            this.Controls.Add(this.btnNewCollection);
            this.Controls.Add(this.labSoundCollectionName);
            this.Controls.Add(this.btnLoadCollection);
            this.Controls.Add(this.tbCollectionName);
            this.Controls.Add(this.btnSaveCollection);
            this.Controls.Add(this.panSoundSet);
            this.Controls.Add(this.btnAddPlayer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddPlayer;
        private System.Windows.Forms.Panel panSoundSet;
        private System.Windows.Forms.Button btnSaveCollection;
        private System.Windows.Forms.TextBox tbCollectionName;
        private System.Windows.Forms.Button btnLoadCollection;
        private System.Windows.Forms.Label labSoundCollectionName;
        private System.Windows.Forms.Button btnNewCollection;
    }
}

