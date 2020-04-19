using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class MessageBox : Window
{
    [Header("MessageBox components")]
    public TMP_Text MessageContent;


    void Start()
    {
        MessageContent.text = "";
        if (IsWindowActive)
            HideWindow();
    }

    public void SetMessage(string msg)
    {
        MessageContent.text = msg;
    }
}
