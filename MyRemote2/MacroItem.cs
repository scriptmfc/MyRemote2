using System;
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
	None
}
