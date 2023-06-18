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

	/// <summary>
	/// 마우스 포지션 용
	/// </summary>
	public int x;
	public int y;

	//단위 : ms
	public int waitdelay;

	//설명
	public string descriptionForThisItem="";

	/// <summary>
	/// 기본 : 왼쪽클릭
	/// </summary>
	public MouseFunctionEnum_Remote mouseFunctionSort = MouseFunctionEnum_Remote.왼쪽클릭;

	/// <summary>
	/// 아마 write쓸 때 쓰는것 같은데
	/// </summary>
    public string str;

	/// <summary>
	/// CustomMacro용
	/// </summary>
	public string CustomMacroCode;
	public string CustomMacroCode2;

	/// <summary>
	/// 뭐지
	/// </summary>
	public List<Keys> shortKey = new List<Keys>();

	/// <summary>
	/// WindowFunctionEnum.ClipboardSetting 에만 사용!
	/// </summary>
	private string clipboardSettingStr;

	/// <summary>
	/// WindowFunctionEnum.GetClipboardText에서 가져온 거를 저장한 string
	/// 이 역할을 MacroPlus.ClipBoardGetTextStr이 함
	/// </summary>
	private string str_FromClipboardGetText;

	public void SetStr_FromClipboardGetText(string str)
    {
		str_FromClipboardGetText = str;

	}

	public void SetClipboardSettingStr(string str)
    {
		clipboardSettingStr = str;

	}
	public WindowFunctionEnum windowFunctionEnum;

	/// <summary>
	/// TestModeKeyPress에만 쓰임
	/// </summary>
	public string TestModeKeyPressCode;
	public Keys TestModeKeyPressCode_Sub;


	public string ClipboardSettingStr { get => clipboardSettingStr;}
    //public string Str_FromClipboardGetText { get => str_FromClipboardGetText;}

    public enum WindowFunctionEnum
    {
		ClipboardSetting,
		Copy,
		Paste,
		GetClipboardText
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
	TestModeKeyPress,
	None
}
