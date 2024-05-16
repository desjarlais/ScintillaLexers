using System.Drawing;

namespace TestLexer
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            scintilla = new ScintillaNET.Scintilla();
            msMain = new System.Windows.Forms.MenuStrip();
            mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            mnuTestMarkLoad = new System.Windows.Forms.ToolStripMenuItem();
            odFile = new System.Windows.Forms.OpenFileDialog();
            msMain.SuspendLayout();
            SuspendLayout();
            // 
            // scintilla
            // 
            scintilla.AutoCMaxHeight = 9;
            scintilla.BiDirectionality = ScintillaNET.BiDirectionalDisplayType.Disabled;
            scintilla.CaretLineBackColor = System.Drawing.Color.Black;
            scintilla.CaretLineBackColor = Color.Yellow;
            scintilla.Dock = System.Windows.Forms.DockStyle.Fill;
            scintilla.EdgeColor = System.Drawing.Color.Black;
            scintilla.LexerName = null;
            scintilla.Location = new System.Drawing.Point(0, 24);
            scintilla.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            scintilla.Name = "scintilla";
            scintilla.ScrollWidth = 1;
            scintilla.Size = new System.Drawing.Size(933, 495);
            scintilla.TabIndents = true;
            scintilla.TabIndex = 0;
            scintilla.UseRightToLeftReadingLayout = false;
            scintilla.WrapMode = ScintillaNET.WrapMode.None;
            scintilla.LocationChanged += Scintilla_LocationChanged;
            scintilla.Click += Scintilla_LocationChanged;
            // 
            // msMain
            // 
            msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { mnuFile });
            msMain.Location = new System.Drawing.Point(0, 0);
            msMain.Name = "msMain";
            msMain.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            msMain.Size = new System.Drawing.Size(933, 24);
            msMain.TabIndex = 1;
            msMain.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { mnuOpen, mnuTestMarkLoad });
            mnuFile.Name = "mnuFile";
            mnuFile.Size = new System.Drawing.Size(37, 20);
            mnuFile.Text = "File";
            // 
            // mnuOpen
            // 
            mnuOpen.Name = "mnuOpen";
            mnuOpen.Size = new System.Drawing.Size(150, 22);
            mnuOpen.Text = "Open";
            mnuOpen.Click += mnuOpen_Click;
            // 
            // mnuTestMarkLoad
            // 
            mnuTestMarkLoad.Name = "mnuTestMarkLoad";
            mnuTestMarkLoad.Size = new System.Drawing.Size(150, 22);
            mnuTestMarkLoad.Text = "Test mark load";
            mnuTestMarkLoad.Click += MnuTestMarkLoad_Click;
            // 
            // odFile
            // 
            odFile.Filter = "All files|*.*";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(933, 519);
            Controls.Add(scintilla);
            Controls.Add(msMain);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = msMain;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "FormMain";
            Text = "Scintilla.NET.TestApp";
            msMain.ResumeLayout(false);
            msMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ScintillaNET.Scintilla scintilla;
        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.OpenFileDialog odFile;
        private System.Windows.Forms.ToolStripMenuItem mnuTestMarkLoad;
    }
}

