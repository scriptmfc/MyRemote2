using System;
//using System.Windows.Forms

public class MacroItem
{
	public MacroEnum macroEnum;


	public Keys key;

	public MacroItem()
	{
		macroEnum = MacroEnum.None;
	}


}

public enum MacroEnum
{
	Key,
	Mouse,
	Wait,
	None
}
