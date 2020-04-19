using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TreatmentRoom : MonoBehaviour
{
    [Header("Logic")]
    public PatientInjuries TreatmentType1;
    public PatientInjuries TreatmentType2;
    public Transform roomEntry;

    private bool isInUse;
    public bool IsInUse { get { return isInUse; } }

    private float timeLeft;

    [Header("GUI")]
    public TMP_Text statusText;
    public TMP_Text timeText;

    private void Start()
    {
        ResetStatusDisplay();
    }

    private void Update()
    {
        if(IsInUse)
        {
            if (timeLeft <= 0)
            {
                EndTreatment();
            }
            else
            {
                timeLeft -= Time.deltaTime;
                RefreshStatusDisplay();
            }
        }
    }

    public void StartTreatment(float treamentTime)
    {
        isInUse = true;
        timeLeft = treamentTime;
        statusText.text = "Treatment in progress";
        statusText.color = Color.red;
    }

    public void EndTreatment()
    {
        timeLeft = 0;
        isInUse = false;
        ResetStatusDisplay();
        PlayerData.Instance.Score++;
    }

    private void RefreshStatusDisplay()
    {
        timeText.text = Mathf.CeilToInt(timeLeft) + "s";
    }

    private void ResetStatusDisplay()
    {
        timeText.text = "";
        statusText.text = "Empty";
        statusText.color = Color.green;
    }

    public void HighlightDisplay()
    {
        statusText.transform.parent.GetComponent<Animator>().SetTrigger("Highlight");
        StartCoroutine(ResetHighlight());
    }

    private IEnumerator ResetHighlight()
    {
        yield return new WaitForSeconds(1.2f);
        statusText.transform.parent.GetComponent<Animator>().ResetTrigger("Highlight");
    }
}
