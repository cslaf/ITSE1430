namespace CadeSchlaefli.MovieLib.Windows
{
    partial class MovieDetailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._chkboxOwned = new System.Windows.Forms.CheckBox();
            this._txtTitle = new System.Windows.Forms.TextBox();
            this._txtDescription = new System.Windows.Forms.TextBox();
            this._txtLength = new System.Windows.Forms.TextBox();
            this._lblSave = new System.Windows.Forms.Button();
            this._lblCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this._errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Length";
            // 
            // _chkboxOwned
            // 
            this._chkboxOwned.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._chkboxOwned.AutoSize = true;
            this._chkboxOwned.Location = new System.Drawing.Point(90, 139);
            this._chkboxOwned.Name = "_chkboxOwned";
            this._chkboxOwned.Size = new System.Drawing.Size(60, 17);
            this._chkboxOwned.TabIndex = 4;
            this._chkboxOwned.Text = "Owned";
            this._chkboxOwned.UseVisualStyleBackColor = true;
            // 
            // _txtTitle
            // 
            this._txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtTitle.Location = new System.Drawing.Point(90, 25);
            this._txtTitle.Name = "_txtTitle";
            this._txtTitle.Size = new System.Drawing.Size(161, 20);
            this._txtTitle.TabIndex = 1;
            this._txtTitle.Validating += new System.ComponentModel.CancelEventHandler(this._txtTitle_Validating);
            // 
            // _txtDescription
            // 
            this._txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtDescription.Location = new System.Drawing.Point(90, 51);
            this._txtDescription.Multiline = true;
            this._txtDescription.Name = "_txtDescription";
            this._txtDescription.Size = new System.Drawing.Size(242, 59);
            this._txtDescription.TabIndex = 2;
            // 
            // _txtLength
            // 
            this._txtLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._txtLength.Location = new System.Drawing.Point(90, 113);
            this._txtLength.Name = "_txtLength";
            this._txtLength.Size = new System.Drawing.Size(100, 20);
            this._txtLength.TabIndex = 3;
            this._txtLength.Validating += new System.ComponentModel.CancelEventHandler(this._txtLength_Validating);
            // 
            // _lblSave
            // 
            this._lblSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._lblSave.Location = new System.Drawing.Point(176, 216);
            this._lblSave.Name = "_lblSave";
            this._lblSave.Size = new System.Drawing.Size(75, 23);
            this._lblSave.TabIndex = 5;
            this._lblSave.Text = "&Save";
            this._lblSave.UseVisualStyleBackColor = true;
            this._lblSave.Click += new System.EventHandler(this.OnSave);
            // 
            // _lblCancel
            // 
            this._lblCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._lblCancel.Location = new System.Drawing.Point(257, 216);
            this._lblCancel.Name = "_lblCancel";
            this._lblCancel.Size = new System.Drawing.Size(75, 23);
            this._lblCancel.TabIndex = 6;
            this._lblCancel.Text = "&Cancel";
            this._lblCancel.UseVisualStyleBackColor = true;
            this._lblCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "minutes";
            // 
            // _errorProvider
            // 
            this._errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errorProvider.ContainerControl = this;
            // 
            // MovieDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(344, 251);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._lblCancel);
            this.Controls.Add(this._lblSave);
            this.Controls.Add(this._txtLength);
            this.Controls.Add(this._txtDescription);
            this.Controls.Add(this._txtTitle);
            this.Controls.Add(this._chkboxOwned);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(360, 290);
            this.Name = "MovieDetailForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Movie Detail";
            ((System.ComponentModel.ISupportInitialize)(this._errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox _chkboxOwned;
        private System.Windows.Forms.TextBox _txtTitle;
        private System.Windows.Forms.TextBox _txtDescription;
        private System.Windows.Forms.TextBox _txtLength;
        private System.Windows.Forms.Button _lblSave;
        private System.Windows.Forms.Button _lblCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider _errorProvider;
    }
}