using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimerPositioner : MonoBehaviour
{
    public float rotationSpeed = 1f;
    public Transform camPos;
    public Transform canvas;

    public TMP_Text timerText;
    public Image timerClock;

    [SerializeField] private Patient npcData;
    private float originalDeathTime;

    // Start is called before the first frame update
    void Start()
    {
        camPos = Camera.main.transform;
        timerClock.fillAmount = 1;
        originalDeathTime = npcData.deathTime;
    }

    // Update is called once per frame
    void Update()
    {
        var dir = (camPos.position - canvas.position).normalized;

        var rot = Quaternion.LookRotation(dir);

        transform.rotation = Quaternion.Slerp(canvas.rotation, rot , Time.deltaTime * rotationSpeed);

        SetTimer(npcData.deathTime);
    }

    public void SetTimer(float s)
    {
        timerText.text = Mathf.FloorToInt(s) + " s";
        timerClock.fillAmount = (s / (originalDeathTime / 100)) / 100;
        if(timerClock.fillAmount <= 0.75f && timerClock.fillAmount > 0.25f)
        {
            timerClock.color = new Color32(248, 152, 27, 150);
        }
        if (timerClock.fillAmount <= 0.25f)
        {
            timerClock.color = new Color32(248, 53, 27, 150);
        }
    }
}
