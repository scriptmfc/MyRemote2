using System;
using System.Collections.Generic;
using System.Windows.Forms;
//using System.Windows.Forms

public class MacroItem
{
	public MacroEnum macroEnum;

	public Keys key;

	/// <summary>
	/// 꾹 누른채로 유지하는 키
	/// </summary>
	public List<Keys> press꾹Key =new List<Keys>();

	public int x;
	public int y;

	//단위 : ms
	public int waitdelay;

    public string str;

	public string CustomMacroCode;

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
	CustomMacro,

	None
}
