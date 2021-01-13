
namespace Elfmeter
{
    partial class Elfmeter
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Elfmeter));
            this.topleft = new System.Windows.Forms.PictureBox();
            this.topright = new System.Windows.Forms.PictureBox();
            this.left = new System.Windows.Forms.PictureBox();
            this.right = new System.Windows.Forms.PictureBox();
            this.top = new System.Windows.Forms.PictureBox();
            this.goalkeeper = new System.Windows.Forms.PictureBox();
            this.football = new System.Windows.Forms.PictureBox();
            this.missText = new System.Windows.Forms.Label();
            this.goalText = new System.Windows.Forms.Label();
            this.keeperTimer = new System.Windows.Forms.Timer(this.components);
            this.ballTimer = new System.Windows.Forms.Timer(this.components);
            this.center = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.topleft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.topright)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.top)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goalkeeper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.football)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.center)).BeginInit();
            this.SuspendLayout();
            // 
            // topleft
            // 
            this.topleft.BackColor = System.Drawing.Color.Yellow;
            this.topleft.Image = global::Elfmeter.Properties.Resources.target;
            this.topleft.Location = new System.Drawing.Point(215, 91);
            this.topleft.Name = "topleft";
            this.topleft.Size = new System.Drawing.Size(40, 38);
            this.topleft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.topleft.TabIndex = 0;
            this.topleft.TabStop = false;
            this.topleft.Tag = "topleft";
            this.topleft.Click += new System.EventHandler(this.setTarget);
            // 
            // topright
            // 
            this.topright.BackColor = System.Drawing.Color.Yellow;
            this.topright.Image = global::Elfmeter.Properties.Resources.target;
            this.topright.Location = new System.Drawing.Point(672, 91);
            this.topright.Name = "topright";
            this.topright.Size = new System.Drawing.Size(40, 38);
            this.topright.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.topright.TabIndex = 1;
            this.topright.TabStop = false;
            this.topright.Tag = "topright";
            this.topright.Click += new System.EventHandler(this.setTarget);
            // 
            // left
            // 
            this.left.BackColor = System.Drawing.Color.Yellow;
            this.left.Image = global::Elfmeter.Properties.Resources.target;
            this.left.Location = new System.Drawing.Point(215, 248);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(40, 38);
            this.left.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.left.TabIndex = 2;
            this.left.TabStop = false;
            this.left.Tag = "left";
            this.left.Click += new System.EventHandler(this.setTarget);
            // 
            // right
            // 
            this.right.BackColor = System.Drawing.Color.Yellow;
            this.right.Image = global::Elfmeter.Properties.Resources.target;
            this.right.Location = new System.Drawing.Point(672, 248);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(40, 38);
            this.right.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.right.TabIndex = 3;
            this.right.TabStop = false;
            this.right.Tag = "right";
            this.right.Click += new System.EventHandler(this.setTarget);
            // 
            // top
            // 
            this.top.BackColor = System.Drawing.Color.Yellow;
            this.top.Image = global::Elfmeter.Properties.Resources.target;
            this.top.Location = new System.Drawing.Point(445, 77);
            this.top.Name = "top";
            this.top.Size = new System.Drawing.Size(40, 38);
            this.top.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.top.TabIndex = 4;
            this.top.TabStop = false;
            this.top.Tag = "top";
            this.top.Click += new System.EventHandler(this.setTarget);
            // 
            // goalkeeper
            // 
            this.goalkeeper.BackColor = System.Drawing.Color.Transparent;
            this.goalkeeper.Image = global::Elfmeter.Properties.Resources.stand_small;
            this.goalkeeper.Location = new System.Drawing.Point(426, 174);
            this.goalkeeper.Name = "goalkeeper";
            this.goalkeeper.Size = new System.Drawing.Size(82, 126);
            this.goalkeeper.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.goalkeeper.TabIndex = 5;
            this.goalkeeper.TabStop = false;
            // 
            // football
            // 
            this.football.BackColor = System.Drawing.Color.Transparent;
            this.football.Image = global::Elfmeter.Properties.Resources.football;
            this.football.Location = new System.Drawing.Point(431, 515);
            this.football.Name = "football";
            this.football.Size = new System.Drawing.Size(50, 51);
            this.football.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.football.TabIndex = 6;
            this.football.TabStop = false;
            // 
            // missText
            // 
            this.missText.AutoSize = true;
            this.missText.BackColor = System.Drawing.Color.Transparent;
            this.missText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.missText.ForeColor = System.Drawing.Color.White;
            this.missText.Location = new System.Drawing.Point(12, 16);
            this.missText.Name = "missText";
            this.missText.Size = new System.Drawing.Size(75, 24);
            this.missText.TabIndex = 7;
            this.missText.Text = "Miss: 0";
            // 
            // goalText
            // 
            this.goalText.AutoSize = true;
            this.goalText.BackColor = System.Drawing.Color.Transparent;
            this.goalText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goalText.ForeColor = System.Drawing.Color.White;
            this.goalText.Location = new System.Drawing.Point(800, 16);
            this.goalText.Name = "goalText";
            this.goalText.Size = new System.Drawing.Size(76, 24);
            this.goalText.TabIndex = 8;
            this.goalText.Text = "Goal: 0";
            // 
            // keeperTimer
            // 
            this.keeperTimer.Interval = 20;
            this.keeperTimer.Tick += new System.EventHandler(this.moveKeeper);
            // 
            // ballTimer
            // 
            this.ballTimer.Interval = 20;
            this.ballTimer.Tick += new System.EventHandler(this.shootball);
            // 
            // center
            // 
            this.center.BackColor = System.Drawing.Color.Yellow;
            this.center.Image = global::Elfmeter.Properties.Resources.target;
            this.center.Location = new System.Drawing.Point(445, 262);
            this.center.Name = "center";
            this.center.Size = new System.Drawing.Size(40, 38);
            this.center.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.center.TabIndex = 9;
            this.center.TabStop = false;
            this.center.Tag = "center";
            this.center.Click += new System.EventHandler(this.setTarget);
            // 
            // Elfmeter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Elfmeter.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(899, 678);
            this.Controls.Add(this.center);
            this.Controls.Add(this.goalText);
            this.Controls.Add(this.missText);
            this.Controls.Add(this.football);
            this.Controls.Add(this.goalkeeper);
            this.Controls.Add(this.top);
            this.Controls.Add(this.right);
            this.Controls.Add(this.left);
            this.Controls.Add(this.topright);
            this.Controls.Add(this.topleft);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Elfmeter";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.topleft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.topright)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.top)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goalkeeper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.football)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.center)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox topleft;
        private System.Windows.Forms.PictureBox topright;
        private System.Windows.Forms.PictureBox left;
        private System.Windows.Forms.PictureBox right;
        private System.Windows.Forms.PictureBox top;
        private System.Windows.Forms.PictureBox goalkeeper;
        private System.Windows.Forms.PictureBox football;
        private System.Windows.Forms.Label missText;
        private System.Windows.Forms.Label goalText;
        private System.Windows.Forms.Timer keeperTimer;
        private System.Windows.Forms.Timer ballTimer;
        private System.Windows.Forms.PictureBox center;
    }
}

