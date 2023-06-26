using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace MyRemote2.Extend.WriteText
{
    public partial class WriteTextWindow : Form
    {
        public static WriteTextWindow Instance;
        public WriteTextWindow()
        {
            InitializeComponent();
            Instance = this;


            Console.WriteLine(Instance + ":...");
        }

        public void KeyExe(Key key)
        {
            Console.WriteLine(" WriteTextWindow 키 확인Whjatthe");
            //  키가 눌렸는지 확인
            if (key == Key.Scroll)
            {
                // 특정 메서드 호출
                Console.WriteLine("Scroll눌러서 writeTextExe함$#&$");
                WriteTextExe();
            }
        }

        public void ItemToListNameWhenLoad()
        {
            MacroItemListBox.Items.Clear();
            for (int i = 0; i < ThisFunction.MacroItemList.Count; i++)
            {
                MacroItemListBox.Items.Add(new MacroItem());

                switch (ThisFunction.MacroItemList[i].macroEnum)
                {
                    case MacroEnum.KeyPress:
                        break;
                    case MacroEnum.None:
                        MacroItemListBox.Items[i] = "None";
                        break;
                    case MacroEnum.MouseClick:
                        MacroItemListBox.Items[i] = "마우스 왼쪽 클릭";
                        break;
                    case MacroEnum.WriteText:
                        MacroItemListBox.Items[i] =
                            "WriteText : [" + ThisFunction.MacroItemList[i].str + "]";
                        break;
                    case MacroEnum.MouseMove:
                        MacroItemListBox.Items[i] =
                            "마우스 이동  " + "(" + ThisFunction.MacroItemList[i].x + "," + ThisFunction.MacroItemList[i].y + ")"; ;
                        break;
                }

            }
        }


        private void MacroItemCreate_Click(object sender, EventArgs e)
        {

            // 리스트 박스에 "새로운 항목" 추가
            MacroItemListBox.Items.Add("새로운 항목");

            var item = new MacroItem();
            ThisFunction.MacroItemList.Add(item);

            Console.WriteLine(MacroItemListBox.Items.Count - 1 + ": 확인 MacroItem_WriteText 생성");

            //  번째 항목 선택
            MacroItemListBox.SelectedIndex = MacroItemListBox.Items.Count - 1;



        }

        private void MacroItemDeleteBtn_Click(object sender, EventArgs e)
        {
            if (ThisFunction.MacroItemList.Count > 0)
            {
                if (ThisFunction.MacroItemList.Contains(ThisFunction.SelectItem))
                    ThisFunction.MacroItemList.Remove(ThisFunction.SelectItem);
                MacroItemListBox.Items.Remove(MacroItemListBox.SelectedItem);
            }
        }

        private void MacroItemEdit_Click(object sender, EventArgs e)
        {
            if (ThisFunction.MacroItemList.Count > 0)
            {
                if (ThisFunction.MacroItemList.Contains(ThisFunction.SelectItem))
                {
                    ThisFunction.SelectItem.macroEnum = MacroEnum.WriteText;
                    ThisFunction.SelectItem.str = WriteTextContentInput.Text;
                    Console.WriteLine(MacroItemListBox.Items.Count + "C");
                    Console.WriteLine(MacroItemListBox.SelectedIndex + "SelectedIndex");
                    Console.WriteLine(ThisFunction.SelectItem.str + "수정될 내용");
                    MacroItemListBox.Items[MacroItemListBox.SelectedIndex] = ThisFunction.SelectItem.str;
                    Console.WriteLine(ThisFunction.SelectItem.str + "수정된 내용");
                }
            }
        }

        private void MacroItemListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MacroItemListBox.Items.Count == 0)
                return;

            if (MacroItemListBox.SelectedIndex < 0)
            {
                Console.WriteLine(MacroItemListBox.SelectedIndex + ":MacroItemListBox.SelectedIndex 에러");
                return;
            }
            if (MacroItemListBox.Items.Count <= MacroItemListBox.SelectedIndex)
            {
                Console.WriteLine(MacroItemListBox.Items.Count + "Why??C");
                Console.WriteLine(MacroItemListBox.SelectedIndex + "__why?SelectedIndex");
                Console.WriteLine("왜 이런 에러가 발생하는지 모르겠음");
                return;
            }

            //Console.WriteLine(MacroItemListBox.Items.Count + "Why??C55555");
            //Console.WriteLine(MacroItemListBox.SelectedIndex + "__why?SelectedIndex5555");
            //Console.WriteLine("왜 이런 에러가 발생하는지 모르겠음555");
            ThisFunction.SelectItem = ThisFunction.MacroItemList[MacroItemListBox.SelectedIndex];
            Console.WriteLine(ThisFunction.SelectItem.str + "선택된 내용");
        }

        private void WriteTextExe()
        {
            Form1_Func.WriteText(ThisFunction.SelectItem.str);
            Console.WriteLine(ThisFunction.SelectItem.str + ":선택된 내용 실행");
        }

        private void SAVEBtn_Click(object sender, EventArgs e)
        {
            SaveLoad.SaveData(SAVELOADNAME_INPUT.Text);
        }

        private void LOADBtn_Click(object sender, EventArgs e)
        {
            SaveLoad.LoadData(SAVELOADNAME_INPUT.Text);
        }

        private void WriteTextWindow_Load(object sender, EventArgs e)
        {
            BackGroundKeyListener.ListenStart(sender,e);
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            BackGroundKeyListener.Window_FormClosed(sender,e);
        }

        private void ExeBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
