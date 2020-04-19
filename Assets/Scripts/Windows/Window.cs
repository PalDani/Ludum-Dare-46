using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class Window : MonoBehaviour
{
    [Header("Base window settings")]
    public string WindowTitle = "Window";
    [Header("Base window components")]
    public GameObject windowObject;
    public Button closeButton;
    public TMP_Text windowTitle;
    [Header("Base window events")]
    public UnityEvent onWindowShown = new UnityEvent();
    public UnityEvent onWindowHidden = new UnityEvent();
    public UnityEvent onWindowClosed = new UnityEvent();

    public bool IsWindowActive { get { return windowObject.activeSelf; } }

    void Start()
    {
        closeButton.onClick.AddListener(CloseWindow);
    }

    void Update()
    {
        
    }

    public void CloseWindow()
    {
        HideWindow();
    }

    public void HideWindow()
    {
        windowObject.SetActive(false);
    }

    public void ShowWindow()
    {
        windowObject.SetActive(true);
    }
}
