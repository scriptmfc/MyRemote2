using System;
using System.Collections.Generic;
using System.Windows.Forms;
//using System.Windows.Forms

/// <summary>
/// ***Keys하고 Key 주의***
/// </summary>
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

	/// <summary>
	/// 아마 write쓸 때 쓰는것 같은데
	/// </summary>
    public string str;

	public string CustomMacroCode;

	public List<Keys> shortKey = new List<Keys>();

	/// <summary>
	/// WindowFunctionEnum.ClipboardSetting 에만 사용!
	/// </summary>
	public string clipboardSettingStr;

	public WindowFunctionEnum windowFunctionEnum;

	public enum WindowFunctionEnum
    {
		ClipboardSetting,
		Copy,
		Paste
    }

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
	WindowFunction,
	CustomMacro,

	None
}
