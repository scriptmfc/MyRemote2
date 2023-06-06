using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using KeyEventArgs = System.Windows.Forms.KeyEventArgs;

namespace MyRemote2
{
    public partial class Form1 : Form
    {
        public static Form1 Instance;

        private bool StartBtnChangeReady;
        private bool MacroKeyInputReady;

        // 윈도우 API 함수를 사용하기 위한 import
        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        private const int MOUSEEVENTF_MOVE = 0x0001;
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        private const int MOUSEEVENTF_RIGHTUP = 0x0010;
        private const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        private const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        private const int MOUSEEVENTF_ABSOLUTE = 0x8000;

        private const int KEYEVENTF_KEYDOWN = 0x0000;
        private const int KEYEVENTF_KEYUP = 0x0002;

        public Form1()
        {
            InitializeComponent();
            Instance = this;
            this.KeyDown += Form1_KeyDown;
            this.KeyPreview = true;
            this.Load += BackGroundKeyListenStart;
            //this.KeyDown += (sender, e) =>  Console.WriteLine("134");
            Console.WriteLine(Instance + ":...");
            
        }

        void BackGroundKeyListenStart(object sender, EventArgs e)
        {
            Extend.WriteText.BackGroundKeyListener.ListenStart(sender, e);
        }

        /// <summary>
        /// listBox1 의 Item 들을 Form1_Func.MacroItemList에 맞게 업데이트한다.
        /// </summary>
        public void ItemToListNameWhenLoad()
        {
            listBox1.Items.Clear();
            for (int i = 0; i < Form1_Func.MacroItemList.Count; i++)
            {
                listBox1.Items.Add(new MacroItem());

                switch(Form1_Func.MacroItemList[i].macroEnum)
                {
                    case MacroEnum.KeyPress:
                        if (Form1_Func.MacroItemList[i].press꾹Key.Count == 0)
                        {
                            listBox1.Items[i] = $"키 Press : {Form1_Func.MacroItemList[i].key}";
                        }
                        else
                        {
                            if(Form1_Func.MacroItemList[i].press꾹Key.Count==1)
                                listBox1.Items[i] = $"키 Press : {Form1_Func.MacroItemList[i].press꾹Key[0]}+{Form1_Func.MacroItemList[i].key}";
                        }
                        break;
                    case MacroEnum.None:
                        listBox1.Items[i] = "None";
                        break;
                    case MacroEnum.Wait:
                        listBox1.Items[i] = $"대기 : {Form1_Func.MacroItemList[i].waitdelay}ms";
                        break;
                    case MacroEnum.MouseClick:
                        listBox1.Items[i] = "마우스 왼쪽 클릭";
                        break;
                    case MacroEnum.CustomMacro:
                        listBox1.Items[i] = $"CustomMacro : + [{Form1_Func.MacroItemList[i].CustomMacroCode}]";
                        break;
                    case MacroEnum.MouseMove:
                        listBox1.Items[i] =
                            "마우스 이동  " + "(" + Form1_Func.MacroItemList[i].x + "," + Form1_Func.MacroItemList[i].y + ")"; ;
                        break;
                }

            }
        }

        public  void BackGroundKeyExe(Key key)
        {

            //Console.WriteLine(e + ":?? WriteTextWindow 키 확인");
            //  키가 눌렸는지 확인
            if (key == Form1_Func.StartKey)
            {
                // 특정 메서드 호출
                Console.WriteLine("ddd777");
                Form1_Func.StartMacro();
            }
            else if (key == Form1_Func.StopKey)
            {
                Form1_Func.StopMacro();
            }
            
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e+":??");
            // F7 키가 눌렸는지 확인

            if (StartBtnChangeReady)
            {
                Console.WriteLine("StartBtnChangeReady가 true");
                Console.WriteLine(e.KeyData+":e.keydata");
                Console.WriteLine(Keys.OemCloseBrackets.ToString() + ":Keys.OemBackslash.ToString()");
                //Oem5키는 \인것 같다.
                if (e.KeyData==Keys.OemCloseBrackets)
                {
                    MyRemote2.Extend.WriteText.BackGroundKeyListener.InputKeyList.Add(Key.OemCloseBrackets);
                    Form1_Func.StartKey = Key.OemCloseBrackets;
                    Console.WriteLine(e.ToString() + ":스타트키가 ] 로 바뀜");
                    StartBtnChangeReady = false;
                    StartBtn.Text = "시작 : ]";
                }

                

                return;
            }

            if (MacroKeyInputReady)
            {
                
                KeyPressSetting(e.KeyData);
                Console.WriteLine(e.KeyData+"키 지정");
                MacroKeyInputReady = false;
                return;
            }


            if (e.KeyData == Keys.A)
            {
                // 특정 메서드 호출
                Console.WriteLine("ddd");
            }
            /*
            if (e.KeyCode == Form1_Func.StartKey)
            {
                // 특정 메서드 호출
                Form1_Func.StartMacro();
            }
            if (e.KeyCode == Form1_Func.StopKey)
            {
                // 특정 메서드 호출
                Form1_Func.StopMacro();
            }*/

            if (e.KeyCode == Form1_Func.CurrentMousePositionSettingKey)
            {
                Console.WriteLine("현재위치");
                Form1.Instance.MouseXPos1.Text = Form1_Func.GetMouseCurrentPosition().X.ToString();
                Form1.Instance.MouseYPos1.Text = Form1_Func.GetMouseCurrentPosition().Y.ToString();
                Form1.Instance.button4_Click();
                //Form1.Instance.Label4 = "현재 위치로 : "+F6;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 리스트 박스에 마우스 이동, 키보드 입력(키 누르기, 삭제, 수정) 수행

            // 마우스 이동
            //MoveMouse(100, 100);

            // "a" 키 누르기
            //PressKey('A');

            // "a" 키 뗄기
            //ReleaseKey('A');

            // 리스트 박스에 "새로운 항목" 추가
            listBox1.Items.Add("새로운 항목");

            var item = new MacroItem();
            Form1_Func.MacroItemList.Add(item);

            Console.WriteLine(listBox1.Items.Count - 1  +": 확인??");

            // 첫 번째 항목 선택
            listBox1.SelectedIndex = listBox1.Items.Count-1;

            
            
            // "Delete" 키 누르기
            //PressKey(Keys.Delete);

            // "Delete" 키 뗄기
            //ReleaseKey(Keys.Delete);

            // 첫 번째 항목의 내용 수정
            //listBox1.Items[0] = "수정된 항목";
        }

        

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                Console.WriteLine(listBox1.SelectedIndex + ":listBox1.SelectedIndex 에러");
                return;
            }

            Console.WriteLine(listBox1.SelectedIndex+ ":listBox1.SelectedIndex 확인2");
            Console.WriteLine(Form1_Func.MacroItemList.Count + ":MacroItemList.Count 확인3");

            Form1_Func.SelectItem = Form1_Func.MacroItemList[listBox1.SelectedIndex];
        }

        /// <summary>
        /// 마우스x위치
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void button4_Click(object sender, EventArgs e)
        {
            MouseMoveSetting();
        }

        public void button4_Click()
        {
            MouseMoveSetting();
        }

        void MouseMoveSetting()
        {
            string itemName = "마우스 이동  " + "(" + MouseXPos.Text + "," + MouseYPos.Text + ")";

            Form1_Func.SelectItem.macroEnum = MacroEnum.MouseMove;

            int.TryParse(MouseXPos.Text, out Form1_Func.SelectItem.x);
            int.TryParse(MouseYPos.Text, out Form1_Func.SelectItem.y);

            listBox1.Items[listBox1.SelectedIndex] = itemName;
        }

        /// <summary>
        /// keys 는 System.Window.Forms.Keys
        /// </summary>
        /// <param name="key"></param>
        void KeyPressSetting(Keys keys)
        {
            Form1_Func.SelectItem.press꾹Key.Clear();

            if (Form1_Func.KeyPress꾹Control)
            {
                Form1_Func.SelectItem.press꾹Key.Add(Keys.Control);
            }
            if (Form1_Func.KeyPress꾹Shift)
            {
                Form1_Func.SelectItem.press꾹Key.Add(Keys.Shift);
            }
            if (Form1_Func.KeyPress꾹Alt)
            {
                Form1_Func.SelectItem.press꾹Key.Add(Keys.Alt);
            }

            string itemName;// = "마우스 이동  " + "(" + MouseXPos.Text + "," + MouseYPos.Text + ")";

            Form1_Func.SelectItem.macroEnum = MacroEnum.KeyPress;
            Form1_Func.SelectItem.key = keys;


            if (Form1_Func.SelectItem.press꾹Key.Count == 0)
            {
                itemName = $"키 Press : {Form1_Func.SelectItem.key}";
            }
            else if (Form1_Func.SelectItem.press꾹Key.Count == 1)
            {
                itemName = $"키 Press : {Form1_Func.SelectItem.press꾹Key[0]}+{Form1_Func.SelectItem.key}";
            }
            else
            {
                itemName = "ItemName Err";
            }


            listBox1.Items[listBox1.SelectedIndex] = itemName;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 마우스 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            string itemName = "왼쪽 클릭";

            Form1_Func.SelectItem.macroEnum = MacroEnum.MouseClick;

            

            listBox1.Items[listBox1.SelectedIndex] = itemName;
        }


        /// <summary> 
        /// 대기 버튼 textBox3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CustomWaitInput.Text))
                return;
            string itemName = "대기  " + "(" + CustomWaitInput.Text + ") ms";

            Form1_Func.SelectItem.macroEnum = MacroEnum.Wait;
            Form1_Func.SelectItem.waitdelay = int.Parse(CustomWaitInput.Text);

            listBox1.Items[listBox1.SelectedIndex] = itemName;
        }

        /// <summary>
        /// BASE_Wait_Delay
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(BaseDelayInput.Text, out Form1_Func.BASE_Wait_Delay);
            Console.WriteLine("기본 대기 시간이 바뀌었습니다.");
            
        }

        /// <summary>
        /// 시작 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            Form1_Func.StartMacro();
        }

        /// <summary>
        /// 정지 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label2_Click(object sender, EventArgs e)
        {
            Form1_Func.StopMacro();
        }



        /// <summary>
        /// 매크로 아이템 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (Form1_Func.MacroItemList.Count > 0)
            {
                if(Form1_Func.MacroItemList.Contains(Form1_Func.SelectItem))
                    Form1_Func.MacroItemList.Remove(Form1_Func.SelectItem);
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }


        private void button10_Click(object sender, EventArgs e)
        {
            SaveLoad.SaveData(SAVELOADNAME_INPUT.Text);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SaveLoad.LoadData(SAVELOADNAME_INPUT.Text);
        }

        private void WriteTextContentInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void WriteTextWindowOpenBtn_Click(object sender, EventArgs e)
        {
            Extend.WriteText.WriteTextWindow window = new Extend.WriteText.WriteTextWindow();
            window.Show();
        }

        private void StartKeyChangeBtn_Click(object sender, EventArgs e)
        {
            StartBtnChangeReady = true;
            
        }

        private void Macro_KeyPressBtn_Click(object sender, EventArgs e)
        {
            MacroKeyInputReady = true;
        }

        private void KeyPressCheckBoxCtrl_CheckedChanged(object sender, EventArgs e)
        {
            if (KeyPressCheckBoxCtrl.Checked)
            {
                Form1_Func.KeyPress꾹Control = true;
            }
            else
            {
                Form1_Func.KeyPress꾹Control = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
            Form1_Func.Init();
        }

        void Init()
        {
            this.MouseMove += MainWindowMouseMove;
        }
        private void MainWindowMouseMove(object sender, EventArgs e)
        {
            string ReverseStr;

            if (Extend.WriteText.BackGroundKeyListener.ReverseMode)
                ReverseStr = "Right";
            else
            {
                ReverseStr = "Left";
            }

            if (Extend.WriteText.BackGroundKeyListener.TestMode20230531)
                Label_TestModeOnOFF.Text = "ON"+" "+ ReverseStr;
            else
            {
                Label_TestModeOnOFF.Text = "OFF" + " " + ReverseStr;
            }
        }

        private void Form1_Disposed(object sender, EventArgs e)
        {
            Extend.WriteText.BackGroundKeyListener.isRunning = false;
        }

        private void MacroListBoxUpButton_Click(object sender, EventArgs e)
        {
            if (Form1_Func.MacroItemList.Count >= 2&& listBox1.SelectedIndex< Form1_Func.MacroItemList.Count
                && listBox1.SelectedIndex>0)
            {

                var tmp = Form1_Func.MacroItemList[listBox1.SelectedIndex-1];
                Form1_Func.MacroItemList[listBox1.SelectedIndex - 1] = Form1_Func.MacroItemList[listBox1.SelectedIndex];
                Form1_Func.MacroItemList[listBox1.SelectedIndex] = tmp;
                ItemToListNameWhenLoad();
            }
            
        }

        private void MacroListBoxDownButton_Click(object sender, EventArgs e)
        {
            if (Form1_Func.MacroItemList.Count >= 2 && listBox1.SelectedIndex < Form1_Func.MacroItemList.Count
                && listBox1.SelectedIndex + 1 < Form1_Func.MacroItemList.Count)
            {
                //Console.WriteLine(listBox1.SelectedIndex + 1 + ":+1");
                //Console.WriteLine(listBox1.SelectedIndex + 1 + ":+0");
                var tmp = Form1_Func.MacroItemList[listBox1.SelectedIndex + 1];
                Form1_Func.MacroItemList[listBox1.SelectedIndex + 1] = Form1_Func.MacroItemList[listBox1.SelectedIndex];
                Form1_Func.MacroItemList[listBox1.SelectedIndex] = tmp;
                ItemToListNameWhenLoad();
            }
        }

        private void SaveFoldOpenButton_Click(object sender, EventArgs e)
        {
            string folderPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/SAVE";

            try
            {
                Process.Start(folderPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("폴더 열기에 실패했습니다: " + ex.Message);
            }
        }

        private void MacroItemSetting_CustomMacroButton_Click(object sender, EventArgs e)
        {
            string itemName = "CustomItem : ";

            Form1_Func.SelectItem.macroEnum = MacroEnum.CustomMacro;



            listBox1.Items[listBox1.SelectedIndex] = itemName;
        }

        private void Label_TestModeOnOFF_Click(object sender, EventArgs e)
        {
            UTIL.ConfirmUtil_NoFunction.NoFunction(Label_TestModeOnOFF);
        }
    }
}
