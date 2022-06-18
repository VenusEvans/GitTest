using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//游戏难度
public enum GameGrade
{
    EASY,
    NORMAL,
    HARD
}

//控制方法
public enum ControlType
{
    Keyboard,
    Touch,
    Mouse
}

public class GameSetting : MonoBehaviour
{
    public float volume = 1;
    public GameGrade grade = GameGrade.NORMAL;
    public ControlType controlType = ControlType.Keyboard;
    public bool isFullScreen = false;

    public TweenPosition startPanelTween;
    public TweenPosition optionPanelTween;

    public void OnVolumeChanged()
    {
        //print("OnVolumeChanged");
        //取得NGUI滑动条的值
        volume = UIProgressBar.current.value;
    }

    public void OnGameGradeChanged()
    {
        //print("OnGameGradeChanged" + UIPopupList.current.value);
        //.Trim()方法用来去除字符串中的空格
        switch (UIPopupList.current.value.Trim())
        {
            case "简单":
                grade = GameGrade.EASY;
                break;
            case "一般":
                grade = GameGrade.NORMAL;
                break;
            case "困难":
                grade= GameGrade.HARD;
                break;
        }
    }

    public void OnControlTypeChanged()
    {
        //print("OnControlTypeChanged" + UIPopupList.current.value);
        switch (UIPopupList.current.value)
        {
            case "键盘":
                controlType = ControlType.Keyboard;
                break;
            case "触摸":
                controlType = ControlType.Touch;
                break;
            case "鼠标":
                controlType = ControlType.Mouse;
                break;
        }
    }

    public void OnIsFullScreenChanged()
    {
        //print("OnIsFullScreenChanged" + UIToggle.current.value);
        isFullScreen = UIToggle.current.value;
    }

    public void OnOptionButtonClick()
    {
        //startPanelTween.Play(); //play方法已经被弃用
        startPanelTween.PlayForward(); //使用此方法
        optionPanelTween.PlayForward();

    }

    public void OnCompleteSettingButtonClick()
    {
        //PlayReverse方法让动画往回播放
        startPanelTween.PlayReverse();
        optionPanelTween.PlayReverse();
    }
}
