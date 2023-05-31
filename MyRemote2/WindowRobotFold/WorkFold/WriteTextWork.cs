using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyRemote2.WindowRobotFold.WorkFold
{
    public static class WriteTextWork
    {
        public static void WriteText(string str)
        {
            if (str == null)
            {
                Console.WriteLine("WriteText str이 null임");
                return;
            }



            for (int i = 0; i < str.Length; i++)
            {

                char c = (char)str[i];
                PressKeyForWriteText(c);
            }
        }

        private static void PressKeyForWriteText(char key)
        {
            Console.WriteLine(key + "글자판별");
            Keys keys;
            bool shiftOn = false;

            if (!Char.IsLower(key) && char.IsLetter(key))
            {
                shiftOn = true;
                Console.WriteLine(key + "는 대문자입니다.");
            }

            switch (key)
            {
                case ' ':
                    keys = Keys.Space;
                    break;
                case '\'':
                    Console.WriteLine(key + "__글자판별 \' ");
                    keys = Keys.OemQuotes;
                    break;
                case '\"':
                    Console.WriteLine(key + "__글자판별 \" ");
                    keys = Keys.OemQuotes;
                    shiftOn = true;
                    break;
                case '-':
                    keys = Keys.OemMinus;
                    break;
                case '.':
                    keys = Keys.OemPeriod;
                    break;
                case '\\':
                    keys = Keys.OemBackslash;
                    break;
                case '|':
                    keys = Keys.OemBackslash;
                    shiftOn = true;
                    break;
                case ';':
                    keys = Keys.OemSemicolon;
                    break;
                case ':':
                    keys = Keys.OemSemicolon;
                    shiftOn = true;
                    break;
                case '?':
                    keys = Keys.OemQuestion;
                    shiftOn = true;
                    break;
                case '/':
                    keys = Keys.OemQuestion;
                    break;
                case '_':
                    keys = Keys.OemMinus;
                    shiftOn = true;
                    break;
                case '=':
                    keys = Keys.Oemplus;
                    break;
                case '+':
                    keys = Keys.Oemplus;
                    shiftOn = true;
                    break;
                case '`':
                    keys = Keys.Oemtilde;
                    break;
                case '~':
                    keys = Keys.Oemtilde;
                    shiftOn = true;
                    break;
                case '!':
                    keys = Keys.D1;
                    shiftOn = true;
                    break;
                case '@':
                    keys = Keys.D2;
                    shiftOn = true;
                    break;
                case '#':
                    keys = Keys.D3;
                    shiftOn = true;
                    break;
                case '$':
                    keys = Keys.D4;
                    shiftOn = true;
                    break;
                case '%':
                    keys = Keys.D5;
                    shiftOn = true;
                    break;
                case '^':
                    keys = Keys.D6;
                    shiftOn = true;
                    break;
                case '&':
                    keys = Keys.D7;
                    shiftOn = true;
                    break;
                case '*':
                    keys = Keys.D8;
                    shiftOn = true;
                    break;
                case '(':
                    keys = Keys.D9;
                    shiftOn = true;
                    break;
                case ')':
                    keys = Keys.D0;
                    shiftOn = true;
                    break;
                case '[':
                    keys = Keys.OemOpenBrackets;
                    shiftOn = true;
                    break;
                case ']':
                    keys = Keys.OemCloseBrackets;
                    shiftOn = true;
                    break;
                case '{':
                    keys = Keys.OemOpenBrackets;
                    shiftOn = true;
                    break;
                case '}':
                    keys = Keys.OemCloseBrackets;
                    shiftOn = true;
                    break;
                case '<':
                    keys = Keys.Oemcomma;
                    shiftOn = true;
                    break;
                case ',':
                    keys = Keys.Oemcomma;
                    break;
                case '>':
                    keys = Keys.OemPeriod;
                    shiftOn = true;
                    break;
                default:
                    keys = (Keys)Enum.Parse(typeof(Keys), key.ToString(), true);
                    int num;
                    if (int.TryParse(key.ToString(), out num))
                    {
                        switch (num)
                        {
                            case 0:
                                keys = Keys.D0;
                                break;
                            case 1:
                                keys = Keys.D1;
                                break;
                            case 2:
                                keys = Keys.D2;
                                break;
                            case 3:
                                keys = Keys.D3;
                                break;
                            case 4:
                                keys = Keys.D4;
                                break;
                            case 5:
                                keys = Keys.D5;
                                break;
                            case 6:
                                keys = Keys.D6;
                                break;
                            case 7:
                                keys = Keys.D7;
                                break;
                            case 8:
                                keys = Keys.D8;
                                break;
                            case 9:
                                keys = Keys.D9;
                                break;
                            default:
                                throw new ArgumentOutOfRangeException("num", "입력된 숫자가 0부터 9까지의 범위를 벗어납니다.");
                        }

                    }

                    Console.WriteLine("default:" + keys);
                    break;
            }

        }
    }
}
