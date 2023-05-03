using System;
using System.Collections.Generic;
using System.Windows.Forms;
//using System.Windows.Forms

public class MacroItem
{
	public MacroEnum macroEnum;

	public Keys key;

	public int x;
	public int y;

	//단위 : ms
	public int waitdelay;

    public string str;

	public List<Keys> shortKey = new List<Keys>();

    public MacroItem()
	{
		macroEnum = MacroEnum.None;
	}


}

public enum MacroEnum
{
	KeyPress,
	MouseMove,
	MouseClick,
	Wait,
	WriteText,


	None
}
