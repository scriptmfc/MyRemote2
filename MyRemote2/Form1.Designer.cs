
using System.Windows.Forms;

namespace MyRemote2
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MacroItemCreate = new System.Windows.Forms.Button();
            this.MacroItemEdit = new System.Windows.Forms.Button();
            this.MacroItemDeleteBtn = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MacroListBoxDownButton = new System.Windows.Forms.Button();
            this.MacroListBoxUpButton = new System.Windows.Forms.Button();
            this.StartKeyChangeBtn = new System.Windows.Forms.Button();
            this.StartBtn = new System.Windows.Forms.Button();
            this.Macro_MouseMoveBtn = new System.Windows.Forms.Button();
            this.MouseXPos = new System.Windows.Forms.TextBox();
            this.MouseYPos = new System.Windows.Forms.TextBox();
            this.Macro_KeyPressBtn = new System.Windows.Forms.Button();
            this.Macro_KeyPressLabel = new System.Windows.Forms.Label();
            this.Macro_MouseClickBtn = new System.Windows.Forms.Button();
            this.Macro_WaitBtn = new System.Windows.Forms.Button();
            this.CustomWaitInput = new System.Windows.Forms.TextBox();
            this.BaseDelayInput = new System.Windows.Forms.TextBox();
            this.StopBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SAVEBtn = new System.Windows.Forms.Button();
            this.LOADBtn = new System.Windows.Forms.Button();
            this.SAVELOADNAME_INPUT = new System.Windows.Forms.TextBox();
            this.WriteTextBtn = new System.Windows.Forms.Button();
            this.WriteTextContentInput = new System.Windows.Forms.TextBox();
            this.SaveLoadLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.WriteTextWindowOpenBtn = new System.Windows.Forms.Button();
            this.KeyPressCheckBoxCtrl = new System.Windows.Forms.CheckBox();
            this.KeyPressCheckBoxShift = new System.Windows.Forms.CheckBox();
            this.SaveFoldOpenButton = new System.Windows.Forms.Button();
            this.MacroItemSetting_CustomMacroButton = new System.Windows.Forms.Button();
            this.DebugMacroMainOptionComboBox = new System.Windows.Forms.ComboBox();
            this.Label_DebugMacroMainOption = new System.Windows.Forms.Label();
            this.Label_TestModeOnOFF = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MacroItemCreate
            // 
            this.MacroItemCreate.Location = new System.Drawing.Point(208, 93);
            this.MacroItemCreate.Name = "MacroItemCreate";
            this.MacroItemCreate.Size = new System.Drawing.Size(75, 23);
            this.MacroItemCreate.TabIndex = 0;
            this.MacroItemCreate.Text = "추가";
            this.MacroItemCreate.UseVisualStyleBackColor = true;
            this.MacroItemCreate.Click += new System.EventHandler(this.button1_Click);
            // 
            // MacroItemEdit
            // 
            this.MacroItemEdit.Location = new System.Drawing.Point(208, 122);
            this.MacroItemEdit.Name = "MacroItemEdit";
            this.MacroItemEdit.Size = new System.Drawing.Size(75, 23);
            this.MacroItemEdit.TabIndex = 2;
            this.MacroItemEdit.Text = "수정";
            this.MacroItemEdit.UseVisualStyleBackColor = true;
            this.MacroItemEdit.Click += new System.EventHandler(this.button2_Click);
            // 
            // MacroItemDeleteBtn
            // 
            this.MacroItemDeleteBtn.Location = new System.Drawing.Point(208, 151);
            this.MacroItemDeleteBtn.Name = "MacroItemDeleteBtn";
            this.MacroItemDeleteBtn.Size = new System.Drawing.Size(75, 23);
            this.MacroItemDeleteBtn.TabIndex = 3;
            this.MacroItemDeleteBtn.Text = "삭제";
            this.MacroItemDeleteBtn.UseVisualStyleBackColor = true;
            this.MacroItemDeleteBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(7, 39);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(352, 244);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.MacroListBoxDownButton);
            this.panel1.Controls.Add(this.MacroListBoxUpButton);
            this.panel1.Controls.Add(this.StartKeyChangeBtn);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.StartBtn);
            this.panel1.Location = new System.Drawing.Point(381, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(391, 319);
            this.panel1.TabIndex = 1;
            // 
            // MacroListBoxDownButton
            // 
            this.MacroListBoxDownButton.Location = new System.Drawing.Point(45, 10);
            this.MacroListBoxDownButton.Name = "MacroListBoxDownButton";
            this.MacroListBoxDownButton.Size = new System.Drawing.Size(32, 23);
            this.MacroListBoxDownButton.TabIndex = 16;
            this.MacroListBoxDownButton.Text = "▽";
            this.MacroListBoxDownButton.UseVisualStyleBackColor = true;
            this.MacroListBoxDownButton.Click += new System.EventHandler(this.MacroListBoxDownButton_Click);
            // 
            // MacroListBoxUpButton
            // 
            this.MacroListBoxUpButton.Location = new System.Drawing.Point(7, 10);
            this.MacroListBoxUpButton.Name = "MacroListBoxUpButton";
            this.MacroListBoxUpButton.Size = new System.Drawing.Size(32, 23);
            this.MacroListBoxUpButton.TabIndex = 15;
            this.MacroListBoxUpButton.Text = "△";
            this.MacroListBoxUpButton.UseVisualStyleBackColor = true;
            this.MacroListBoxUpButton.Click += new System.EventHandler(this.MacroListBoxUpButton_Click);
            // 
            // StartKeyChangeBtn
            // 
            this.StartKeyChangeBtn.Location = new System.Drawing.Point(144, 289);
            this.StartKeyChangeBtn.Name = "StartKeyChangeBtn";
            this.StartKeyChangeBtn.Size = new System.Drawing.Size(60, 23);
            this.StartKeyChangeBtn.TabIndex = 14;
            this.StartKeyChangeBtn.Text = "키 변경";
            this.StartKeyChangeBtn.UseVisualStyleBackColor = true;
            this.StartKeyChangeBtn.Click += new System.EventHandler(this.StartKeyChangeBtn_Click);
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(7, 289);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(131, 23);
            this.StartBtn.TabIndex = 13;
            this.StartBtn.Text = "시작 : Scroll-Lock";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.button8_Click);
            // 
            // Macro_MouseMoveBtn
            // 
            this.Macro_MouseMoveBtn.Location = new System.Drawing.Point(59, 211);
            this.Macro_MouseMoveBtn.Name = "Macro_MouseMoveBtn";
            this.Macro_MouseMoveBtn.Size = new System.Drawing.Size(82, 28);
            this.Macro_MouseMoveBtn.TabIndex = 4;
            this.Macro_MouseMoveBtn.Text = "마우스 이동";
            this.Macro_MouseMoveBtn.UseVisualStyleBackColor = true;
            this.Macro_MouseMoveBtn.Click += new System.EventHandler(this.button4_Click);
            // 
            // MouseXPos
            // 
            this.MouseXPos.Location = new System.Drawing.Point(148, 214);
            this.MouseXPos.Name = "MouseXPos";
            this.MouseXPos.Size = new System.Drawing.Size(36, 21);
            this.MouseXPos.TabIndex = 5;
            this.MouseXPos.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // MouseYPos
            // 
            this.MouseYPos.Location = new System.Drawing.Point(190, 214);
            this.MouseYPos.Name = "MouseYPos";
            this.MouseYPos.Size = new System.Drawing.Size(36, 21);
            this.MouseYPos.TabIndex = 6;
            // 
            // Macro_KeyPressBtn
            // 
            this.Macro_KeyPressBtn.Location = new System.Drawing.Point(59, 245);
            this.Macro_KeyPressBtn.Name = "Macro_KeyPressBtn";
            this.Macro_KeyPressBtn.Size = new System.Drawing.Size(82, 23);
            this.Macro_KeyPressBtn.TabIndex = 7;
            this.Macro_KeyPressBtn.Text = "키 입력";
            this.Macro_KeyPressBtn.UseVisualStyleBackColor = true;
            this.Macro_KeyPressBtn.Click += new System.EventHandler(this.Macro_KeyPressBtn_Click);
            // 
            // Macro_KeyPressLabel
            // 
            this.Macro_KeyPressLabel.AutoSize = true;
            this.Macro_KeyPressLabel.Location = new System.Drawing.Point(146, 250);
            this.Macro_KeyPressLabel.Name = "Macro_KeyPressLabel";
            this.Macro_KeyPressLabel.Size = new System.Drawing.Size(38, 12);
            this.Macro_KeyPressLabel.TabIndex = 8;
            this.Macro_KeyPressLabel.Text = "label1";
            // 
            // Macro_MouseClickBtn
            // 
            this.Macro_MouseClickBtn.Location = new System.Drawing.Point(59, 177);
            this.Macro_MouseClickBtn.Name = "Macro_MouseClickBtn";
            this.Macro_MouseClickBtn.Size = new System.Drawing.Size(82, 28);
            this.Macro_MouseClickBtn.TabIndex = 9;
            this.Macro_MouseClickBtn.Text = "마우스 클릭";
            this.Macro_MouseClickBtn.UseVisualStyleBackColor = true;
            this.Macro_MouseClickBtn.Click += new System.EventHandler(this.button6_Click);
            // 
            // Macro_WaitBtn
            // 
            this.Macro_WaitBtn.Location = new System.Drawing.Point(59, 347);
            this.Macro_WaitBtn.Name = "Macro_WaitBtn";
            this.Macro_WaitBtn.Size = new System.Drawing.Size(82, 23);
            this.Macro_WaitBtn.TabIndex = 10;
            this.Macro_WaitBtn.Text = "대기";
            this.Macro_WaitBtn.UseVisualStyleBackColor = true;
            this.Macro_WaitBtn.Click += new System.EventHandler(this.button7_Click);
            // 
            // CustomWaitInput
            // 
            this.CustomWaitInput.Location = new System.Drawing.Point(148, 347);
            this.CustomWaitInput.Name = "CustomWaitInput";
            this.CustomWaitInput.Size = new System.Drawing.Size(36, 21);
            this.CustomWaitInput.TabIndex = 11;
            // 
            // BaseDelayInput
            // 
            this.BaseDelayInput.Location = new System.Drawing.Point(457, 66);
            this.BaseDelayInput.Name = "BaseDelayInput";
            this.BaseDelayInput.Size = new System.Drawing.Size(36, 21);
            this.BaseDelayInput.TabIndex = 12;
            this.BaseDelayInput.Text = "100";
            this.BaseDelayInput.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // StopBtn
            // 
            this.StopBtn.Location = new System.Drawing.Point(59, 434);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(131, 23);
            this.StopBtn.TabIndex = 14;
            this.StopBtn.Text = "정지 : Pause";
            this.StopBtn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(386, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "기본 Delay";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(499, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "ms";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(232, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "현재 위치로 : F6";
            // 
            // SAVEBtn
            // 
            this.SAVEBtn.Location = new System.Drawing.Point(233, 405);
            this.SAVEBtn.Name = "SAVEBtn";
            this.SAVEBtn.Size = new System.Drawing.Size(82, 23);
            this.SAVEBtn.TabIndex = 18;
            this.SAVEBtn.Text = "SAVE";
            this.SAVEBtn.UseVisualStyleBackColor = true;
            this.SAVEBtn.Click += new System.EventHandler(this.button10_Click);
            // 
            // LOADBtn
            // 
            this.LOADBtn.Location = new System.Drawing.Point(233, 434);
            this.LOADBtn.Name = "LOADBtn";
            this.LOADBtn.Size = new System.Drawing.Size(82, 23);
            this.LOADBtn.TabIndex = 19;
            this.LOADBtn.Text = "LOAD";
            this.LOADBtn.UseVisualStyleBackColor = true;
            this.LOADBtn.Click += new System.EventHandler(this.button11_Click);
            // 
            // SAVELOADNAME_INPUT
            // 
            this.SAVELOADNAME_INPUT.Location = new System.Drawing.Point(234, 376);
            this.SAVELOADNAME_INPUT.Name = "SAVELOADNAME_INPUT";
            this.SAVELOADNAME_INPUT.Size = new System.Drawing.Size(116, 21);
            this.SAVELOADNAME_INPUT.TabIndex = 20;
            // 
            // WriteTextBtn
            // 
            this.WriteTextBtn.Location = new System.Drawing.Point(59, 148);
            this.WriteTextBtn.Name = "WriteTextBtn";
            this.WriteTextBtn.Size = new System.Drawing.Size(82, 23);
            this.WriteTextBtn.TabIndex = 21;
            this.WriteTextBtn.Text = "문자 타이핑";
            this.WriteTextBtn.UseVisualStyleBackColor = true;
            // 
            // WriteTextContentInput
            // 
            this.WriteTextContentInput.Location = new System.Drawing.Point(18, 66);
            this.WriteTextContentInput.Multiline = true;
            this.WriteTextContentInput.Name = "WriteTextContentInput";
            this.WriteTextContentInput.Size = new System.Drawing.Size(172, 79);
            this.WriteTextContentInput.TabIndex = 22;
            this.WriteTextContentInput.TextChanged += new System.EventHandler(this.WriteTextContentInput_TextChanged);
            // 
            // SaveLoadLabel
            // 
            this.SaveLoadLabel.AutoSize = true;
            this.SaveLoadLabel.Location = new System.Drawing.Point(232, 358);
            this.SaveLoadLabel.Name = "SaveLoadLabel";
            this.SaveLoadLabel.Size = new System.Drawing.Size(121, 12);
            this.SaveLoadLabel.TabIndex = 23;
            this.SaveLoadLabel.Text = "▽SaveLoad파일이름";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(190, 352);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 24;
            this.label1.Text = "ms";
            // 
            // WriteTextWindowOpenBtn
            // 
            this.WriteTextWindowOpenBtn.Location = new System.Drawing.Point(658, 35);
            this.WriteTextWindowOpenBtn.Name = "WriteTextWindowOpenBtn";
            this.WriteTextWindowOpenBtn.Size = new System.Drawing.Size(82, 23);
            this.WriteTextWindowOpenBtn.TabIndex = 25;
            this.WriteTextWindowOpenBtn.Text = "타이핑 창";
            this.WriteTextWindowOpenBtn.UseVisualStyleBackColor = true;
            this.WriteTextWindowOpenBtn.Click += new System.EventHandler(this.WriteTextWindowOpenBtn_Click);
            // 
            // KeyPressCheckBoxCtrl
            // 
            this.KeyPressCheckBoxCtrl.AutoSize = true;
            this.KeyPressCheckBoxCtrl.Location = new System.Drawing.Point(59, 274);
            this.KeyPressCheckBoxCtrl.Name = "KeyPressCheckBoxCtrl";
            this.KeyPressCheckBoxCtrl.Size = new System.Drawing.Size(64, 16);
            this.KeyPressCheckBoxCtrl.TabIndex = 26;
            this.KeyPressCheckBoxCtrl.Text = "Control";
            this.KeyPressCheckBoxCtrl.UseVisualStyleBackColor = true;
            this.KeyPressCheckBoxCtrl.CheckedChanged += new System.EventHandler(this.KeyPressCheckBoxCtrl_CheckedChanged);
            // 
            // KeyPressCheckBoxShift
            // 
            this.KeyPressCheckBoxShift.AutoSize = true;
            this.KeyPressCheckBoxShift.Location = new System.Drawing.Point(129, 274);
            this.KeyPressCheckBoxShift.Name = "KeyPressCheckBoxShift";
            this.KeyPressCheckBoxShift.Size = new System.Drawing.Size(48, 16);
            this.KeyPressCheckBoxShift.TabIndex = 27;
            this.KeyPressCheckBoxShift.Text = "Shift";
            this.KeyPressCheckBoxShift.UseVisualStyleBackColor = true;
            // 
            // SaveFoldOpenButton
            // 
            this.SaveFoldOpenButton.Location = new System.Drawing.Point(234, 463);
            this.SaveFoldOpenButton.Name = "SaveFoldOpenButton";
            this.SaveFoldOpenButton.Size = new System.Drawing.Size(82, 23);
            this.SaveFoldOpenButton.TabIndex = 28;
            this.SaveFoldOpenButton.Text = "Folder Open";
            this.SaveFoldOpenButton.UseVisualStyleBackColor = true;
            this.SaveFoldOpenButton.Click += new System.EventHandler(this.SaveFoldOpenButton_Click);
            // 
            // MacroItemSetting_CustomMacroButton
            // 
            this.MacroItemSetting_CustomMacroButton.Location = new System.Drawing.Point(388, 443);
            this.MacroItemSetting_CustomMacroButton.Name = "MacroItemSetting_CustomMacroButton";
            this.MacroItemSetting_CustomMacroButton.Size = new System.Drawing.Size(105, 23);
            this.MacroItemSetting_CustomMacroButton.TabIndex = 29;
            this.MacroItemSetting_CustomMacroButton.Text = "CustomMacro";
            this.MacroItemSetting_CustomMacroButton.UseVisualStyleBackColor = true;
            this.MacroItemSetting_CustomMacroButton.Click += new System.EventHandler(this.MacroItemSetting_CustomMacroButton_Click);
            // 
            // DebugMacroMainOptionComboBox
            // 
            this.DebugMacroMainOptionComboBox.FormattingEnabled = true;
            this.DebugMacroMainOptionComboBox.Items.AddRange(new object[] {
            "Form",
            "Unity"});
            this.DebugMacroMainOptionComboBox.Location = new System.Drawing.Point(785, 66);
            this.DebugMacroMainOptionComboBox.Name = "DebugMacroMainOptionComboBox";
            this.DebugMacroMainOptionComboBox.Size = new System.Drawing.Size(121, 20);
            this.DebugMacroMainOptionComboBox.TabIndex = 30;
            this.DebugMacroMainOptionComboBox.Text = "Form";
            // 
            // Label_DebugMacroMainOption
            // 
            this.Label_DebugMacroMainOption.AutoSize = true;
            this.Label_DebugMacroMainOption.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Label_DebugMacroMainOption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label_DebugMacroMainOption.Location = new System.Drawing.Point(785, 40);
            this.Label_DebugMacroMainOption.Name = "Label_DebugMacroMainOption";
            this.Label_DebugMacroMainOption.Size = new System.Drawing.Size(79, 14);
            this.Label_DebugMacroMainOption.TabIndex = 31;
            this.Label_DebugMacroMainOption.Text = "DebugMacro";
            // 
            // Label_TestModeOnOFF
            // 
            this.Label_TestModeOnOFF.AutoSize = true;
            this.Label_TestModeOnOFF.Location = new System.Drawing.Point(16, 474);
            this.Label_TestModeOnOFF.Name = "Label_TestModeOnOFF";
            this.Label_TestModeOnOFF.Size = new System.Drawing.Size(23, 12);
            this.Label_TestModeOnOFF.TabIndex = 32;
            this.Label_TestModeOnOFF.Text = "ON";
            this.Label_TestModeOnOFF.Click += new System.EventHandler(this.Label_TestModeOnOFF_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 501);
            this.Controls.Add(this.Label_TestModeOnOFF);
            this.Controls.Add(this.Label_DebugMacroMainOption);
            this.Controls.Add(this.DebugMacroMainOptionComboBox);
            this.Controls.Add(this.MacroItemSetting_CustomMacroButton);
            this.Controls.Add(this.SaveFoldOpenButton);
            this.Controls.Add(this.KeyPressCheckBoxShift);
            this.Controls.Add(this.KeyPressCheckBoxCtrl);
            this.Controls.Add(this.WriteTextWindowOpenBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SaveLoadLabel);
            this.Controls.Add(this.WriteTextContentInput);
            this.Controls.Add(this.WriteTextBtn);
            this.Controls.Add(this.SAVELOADNAME_INPUT);
            this.Controls.Add(this.LOADBtn);
            this.Controls.Add(this.SAVEBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.BaseDelayInput);
            this.Controls.Add(this.CustomWaitInput);
            this.Controls.Add(this.Macro_WaitBtn);
            this.Controls.Add(this.Macro_MouseClickBtn);
            this.Controls.Add(this.Macro_KeyPressLabel);
            this.Controls.Add(this.Macro_KeyPressBtn);
            this.Controls.Add(this.MouseYPos);
            this.Controls.Add(this.MouseXPos);
            this.Controls.Add(this.Macro_MouseMoveBtn);
            this.Controls.Add(this.MacroItemDeleteBtn);
            this.Controls.Add(this.MacroItemEdit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MacroItemCreate);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Disposed += new System.EventHandler(this.Form1_Disposed);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MacroItemCreate;
        private System.Windows.Forms.Button MacroItemEdit;
        private System.Windows.Forms.Button MacroItemDeleteBtn;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Macro_MouseMoveBtn;
        private System.Windows.Forms.TextBox MouseXPos;
        private System.Windows.Forms.TextBox MouseYPos;
        private System.Windows.Forms.Button Macro_KeyPressBtn;
        private System.Windows.Forms.Label Macro_KeyPressLabel;
        private System.Windows.Forms.Button Macro_MouseClickBtn;
        private System.Windows.Forms.Button Macro_WaitBtn;
        private System.Windows.Forms.TextBox CustomWaitInput;
        private System.Windows.Forms.TextBox BaseDelayInput;
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Button SAVEBtn;
        private Button LOADBtn;
        private TextBox SAVELOADNAME_INPUT;
        private Button WriteTextBtn;
        private TextBox WriteTextContentInput;
        private Label SaveLoadLabel;
        private Label label1;
        private Button WriteTextWindowOpenBtn;
        private Button StartKeyChangeBtn;
        private CheckBox KeyPressCheckBoxCtrl;
        private CheckBox KeyPressCheckBoxShift;
        private Button MacroListBoxDownButton;
        private Button MacroListBoxUpButton;
        private Button SaveFoldOpenButton;
        private Button MacroItemSetting_CustomMacroButton;
        private ComboBox DebugMacroMainOptionComboBox;
        private Label Label_DebugMacroMainOption;
        private Label Label_TestModeOnOFF;

        public Label Label4 { get => label4; set => label4 = value; }
        public TextBox MouseXPos1 { get => MouseXPos; set => MouseXPos = value; }
        public TextBox MouseYPos1 { get => MouseYPos; set => MouseYPos = value; }

        
    }
}

