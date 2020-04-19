using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    [SerializeField] private MessageBox messageBox;

    public static WindowManager Instance;

    void Start()
    {
        if (Instance == null)
            Instance = this;
        else Debug.LogError("WindowManager Instance already running!", Instance);
    }

    void Update()
    {
        
    }

    public void ShowNPCData(Patient p)
    {
        messageBox.SetMessage("Name: " + p.PatientName
            + "\nAge: " + p.PatientAge
            + "\nInjury: " + p.Injury.AccidentMessage);
        messageBox.SetMessage("Name: " + p.PatientName
            + "\nAge: " + p.PatientAge
            + "\nInjury: " + p.Injury.AccidentMessage);
        if (!messageBox.IsWindowActive)
            messageBox.ShowWindow();
;    }
}
