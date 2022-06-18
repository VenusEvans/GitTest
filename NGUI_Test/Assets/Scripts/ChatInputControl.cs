using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatInputControl : MonoBehaviour
{
    UIInput input;

    public UITextList textList;

    //随机生成用户名
    string[] names = new string[] { "Venus", "System", "Mike" };

    void Awake()
    {
        input = GetComponent<UIInput>();
    }

    public void OnChatSubmit()
    {
        string chatMessage = input.value;
        string name = names[Random.Range(0, 3)]; //随机生成索引0-2，不包括右值
        textList.Add(name + ":" + chatMessage);
        input.value = "";
    }
}
