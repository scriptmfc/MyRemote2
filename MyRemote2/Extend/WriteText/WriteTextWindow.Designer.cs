
namespace MyRemote2.Extend.WriteText
{
    partial class WriteTextWindow
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
            this.SelectCategory = new System.Windows.Forms.ComboBox();
            this.MacroItemListBox = new System.Windows.Forms.ListBox();
            this.SaveLoadLabel = new System.Windows.Forms.Label();
            this.SAVELOADNAME_INPUT = new System.Windows.Forms.TextBox();
            this.LOADBtn = new System.Windows.Forms.Button();
            this.SAVEBtn = new System.Windows.Forms.Button();
            this.WriteTextContentInput = new System.Windows.Forms.TextBox();
            this.MacroItemDeleteBtn = new System.Windows.Forms.Button();
            this.MacroItemEdit = new System.Windows.Forms.Button();
            this.MacroItemCreate = new System.Windows.Forms.Button();
            this.KeySettingBtn = new System.Windows.Forms.Button();
            this.ExeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SelectCategory
            // 
            this.SelectCategory.FormattingEnabled = true;
            this.SelectCategory.Location = new System.Drawing.Point(30, 30);
            this.SelectCategory.Name = "SelectCategory";
            this.SelectCategory.Size = new System.Drawing.Size(121, 20);
            this.SelectCategory.TabIndex = 0;
            // 
            // MacroItemListBox
            // 
            this.MacroItemListBox.FormattingEnabled = true;
            this.MacroItemListBox.ItemHeight = 12;
            this.MacroItemListBox.Location = new System.Drawing.Point(30, 90);
            this.MacroItemListBox.Name = "MacroItemListBox";
            this.MacroItemListBox.Size = new System.Drawing.Size(432, 232);
            this.MacroItemListBox.TabIndex = 1;
            this.MacroItemListBox.SelectedIndexChanged += new System.EventHandler(this.MacroItemListBox_SelectedIndexChanged);
            // 
            // SaveLoadLabel
            // 
            this.SaveLoadLabel.AutoSize = true;
            this.SaveLoadLabel.Location = new System.Drawing.Point(501, 260);
            this.SaveLoadLabel.Name = "SaveLoadLabel";
            this.SaveLoadLabel.Size = new System.Drawing.Size(121, 12);
            this.SaveLoadLabel.TabIndex = 27;
            this.SaveLoadLabel.Text = "▽SaveLoad파일이름";
            // 
            // SAVELOADNAME_INPUT
            // 
            this.SAVELOADNAME_INPUT.Location = new System.Drawing.Point(503, 278);
            this.SAVELOADNAME_INPUT.Name = "SAVELOADNAME_INPUT";
            this.SAVELOADNAME_INPUT.Size = new System.Drawing.Size(116, 21);
            this.SAVELOADNAME_INPUT.TabIndex = 26;
            // 
            // LOADBtn
            // 
            this.LOADBtn.Location = new System.Drawing.Point(502, 336);
            this.LOADBtn.Name = "LOADBtn";
            this.LOADBtn.Size = new System.Drawing.Size(82, 23);
            this.LOADBtn.TabIndex = 25;
            this.LOADBtn.Text = "LOAD";
            this.LOADBtn.UseVisualStyleBackColor = true;
            this.LOADBtn.Click += new System.EventHandler(this.LOADBtn_Click);
            // 
            // SAVEBtn
            // 
            this.SAVEBtn.Location = new System.Drawing.Point(502, 307);
            this.SAVEBtn.Name = "SAVEBtn";
            this.SAVEBtn.Size = new System.Drawing.Size(82, 23);
            this.SAVEBtn.TabIndex = 24;
            this.SAVEBtn.Text = "SAVE";
            this.SAVEBtn.UseVisualStyleBackColor = true;
            this.SAVEBtn.Click += new System.EventHandler(this.SAVEBtn_Click);
            // 
            // WriteTextContentInput
            // 
            this.WriteTextContentInput.Location = new System.Drawing.Point(639, 90);
            this.WriteTextContentInput.Multiline = true;
            this.WriteTextContentInput.Name = "WriteTextContentInput";
            this.WriteTextContentInput.Size = new System.Drawing.Size(337, 81);
            this.WriteTextContentInput.TabIndex = 31;
            // 
            // MacroItemDeleteBtn
            // 
            this.MacroItemDeleteBtn.Location = new System.Drawing.Point(503, 148);
            this.MacroItemDeleteBtn.Name = "MacroItemDeleteBtn";
            this.MacroItemDeleteBtn.Size = new System.Drawing.Size(75, 23);
            this.MacroItemDeleteBtn.TabIndex = 30;
            this.MacroItemDeleteBtn.Text = "삭제";
            this.MacroItemDeleteBtn.UseVisualStyleBackColor = true;
            this.MacroItemDeleteBtn.Click += new System.EventHandler(this.MacroItemDeleteBtn_Click);
            // 
            // MacroItemEdit
            // 
            this.MacroItemEdit.Location = new System.Drawing.Point(503, 119);
            this.MacroItemEdit.Name = "MacroItemEdit";
            this.MacroItemEdit.Size = new System.Drawing.Size(75, 23);
            this.MacroItemEdit.TabIndex = 29;
            this.MacroItemEdit.Text = "수정";
            this.MacroItemEdit.UseVisualStyleBackColor = true;
            this.MacroItemEdit.Click += new System.EventHandler(this.MacroItemEdit_Click);
            // 
            // MacroItemCreate
            // 
            this.MacroItemCreate.Location = new System.Drawing.Point(503, 90);
            this.MacroItemCreate.Name = "MacroItemCreate";
            this.MacroItemCreate.Size = new System.Drawing.Size(75, 23);
            this.MacroItemCreate.TabIndex = 28;
            this.MacroItemCreate.Text = "추가";
            this.MacroItemCreate.UseVisualStyleBackColor = true;
            this.MacroItemCreate.Click += new System.EventHandler(this.MacroItemCreate_Click);
            // 
            // KeySettingBtn
            // 
            this.KeySettingBtn.Location = new System.Drawing.Point(503, 177);
            this.KeySettingBtn.Name = "KeySettingBtn";
            this.KeySettingBtn.Size = new System.Drawing.Size(75, 23);
            this.KeySettingBtn.TabIndex = 32;
            this.KeySettingBtn.Text = "키 지정";
            this.KeySettingBtn.UseVisualStyleBackColor = true;
            // 
            // ExeBtn
            // 
            this.ExeBtn.Location = new System.Drawing.Point(502, 206);
            this.ExeBtn.Name = "ExeBtn";
            this.ExeBtn.Size = new System.Drawing.Size(75, 23);
            this.ExeBtn.TabIndex = 33;
            this.ExeBtn.Text = "실행";
            this.ExeBtn.UseVisualStyleBackColor = true;
            this.ExeBtn.Click += new System.EventHandler(this.ExeBtn_Click);
            // 
            // WriteTextWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 450);
            this.Controls.Add(this.ExeBtn);
            this.Controls.Add(this.KeySettingBtn);
            this.Controls.Add(this.WriteTextContentInput);
            this.Controls.Add(this.MacroItemDeleteBtn);
            this.Controls.Add(this.MacroItemEdit);
            this.Controls.Add(this.MacroItemCreate);
            this.Controls.Add(this.SaveLoadLabel);
            this.Controls.Add(this.SAVELOADNAME_INPUT);
            this.Controls.Add(this.LOADBtn);
            this.Controls.Add(this.SAVEBtn);
            this.Controls.Add(this.MacroItemListBox);
            this.Controls.Add(this.SelectCategory);
            this.Name = "WriteTextWindow";
            this.Text = "텍스트 입력";
            this.Load += new System.EventHandler(this.WriteTextWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox SelectCategory;
        private System.Windows.Forms.ListBox MacroItemListBox;
        private System.Windows.Forms.Label SaveLoadLabel;
        private System.Windows.Forms.TextBox SAVELOADNAME_INPUT;
        private System.Windows.Forms.Button LOADBtn;
        private System.Windows.Forms.Button SAVEBtn;
        private System.Windows.Forms.TextBox WriteTextContentInput;
        private System.Windows.Forms.Button MacroItemDeleteBtn;
        private System.Windows.Forms.Button MacroItemEdit;
        private System.Windows.Forms.Button MacroItemCreate;
        private System.Windows.Forms.Button KeySettingBtn;
        private System.Windows.Forms.Button ExeBtn;
    }
}