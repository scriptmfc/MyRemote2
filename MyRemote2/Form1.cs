using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyRemote2
{
    public partial class Form1 : Form
    {
        public static Form1 Instance;

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
            
            //this.KeyDown += (sender, e) =>  Console.WriteLine("134");
            Console.WriteLine(Instance + ":...");
            
        }

        public void ItemToListNameWhenLoad()
        {
            listBox1.Items.Clear();
            for (int i = 0; i < Form1_Func.MacroItemList.Count; i++)
            {
                listBox1.Items.Add(new MacroItem());

                switch(Form1_Func.MacroItemList[i].macroEnum)
                {
                    case MacroEnum.KeyPress:
                        break;
                    case MacroEnum.None:
                        listBox1.Items[i] = "None";
                        break;
                    case MacroEnum.MouseClick:
                        listBox1.Items[i] = "마우스 왼쪽 클릭";
                        break;
                    case MacroEnum.MouseMove:
                        listBox1.Items[i] =
                            "마우스 이동  " + "(" + Form1_Func.MacroItemList[i].x + "," + Form1_Func.MacroItemList[i].y + ")"; ;
                        break;
                }

            }
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e+":??");
            // F7 키가 눌렸는지 확인
            if (e.KeyData == Keys.A)
            {
                // 특정 메서드 호출
                Console.WriteLine("ddd");
            }

            if (e.KeyCode == Form1_Func.StartKey)
            {
                // 특정 메서드 호출
                Form1_Func.StartMacro();
            }
            if (e.KeyCode == Form1_Func.StopKey)
            {
                // 특정 메서드 호출
                Form1_Func.StopMacro();
            }

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

        private void label1_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {

        }

        /// <summary> 
        /// 대기 버튼 textBox3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            string itemName = "대기  " + "(" + CustomWaitInput.Text + ")";

            Form1_Func.SelectItem.macroEnum = MacroEnum.Wait;


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
    }
}
