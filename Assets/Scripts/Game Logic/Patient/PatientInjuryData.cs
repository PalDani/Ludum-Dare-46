using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PatientInjuryData
{
    public PatientInjuries InjuryType;
    public int TreatmentTime;

    public string AccidentMessage;

    public static string CreateAccidentMessage(string patientName, int patientGender, PatientInjuries type)
    {
        string message = patientName + " ";
        string genderParticle = patientGender == 0 ? "his" : "her";
        string[] verb, cause;
        switch (type)
        {
            case PatientInjuries.BLEEDING:
                verb = Resources.Load<TextAsset>("bleeding_cause").text.Split(';');
                cause = Resources.Load<TextAsset>("bleeding_injury").text.Split(';');
                message += " has accidentally " + verb[Random.Range(0,verb.Length-1)] + " " + genderParticle +  " " + cause[Random.Range(0, cause.Length-1)];
                break;
            case PatientInjuries.TOXIC:
                verb = Resources.Load<TextAsset>("toxic_cause").text.Split(';');
                cause = Resources.Load<TextAsset>("toxic_injury").text.Split(';');
                message += " has accidentally " + verb[Random.Range(0, verb.Length-1)] + " " + cause[Random.Range(0, cause.Length-1)];
                break;
            case PatientInjuries.SWALLOWED:
                verb = Resources.Load<TextAsset>("swallow_cause").text.Split(';');
                cause = Resources.Load<TextAsset>("swallow_injury").text.Split(';');
                message += " has accidentally " + verb[Random.Range(0, verb.Length-1)] + " " + cause[Random.Range(0, cause.Length-1)];
                break;
            case PatientInjuries.BROKEN_BONE:
                verb = Resources.Load<TextAsset>("broke_cause").text.Split(';');
                cause = Resources.Load<TextAsset>("broke_injury").text.Split(';');
                message += " has accidentally " + verb[Random.Range(0, verb.Length-1)] + " " + cause[Random.Range(0, cause.Length-1)];
                break;
            case PatientInjuries.BURN:
                verb = Resources.Load<TextAsset>("burn_cause").text.Split(';');
                cause = Resources.Load<TextAsset>("burn_injury").text.Split(';');
                message += " has accidentally " + verb[Random.Range(0, verb.Length-1)] + " " + cause[Random.Range(0, cause.Length-1)];
                break;
            default:
                break;
        }
        message += ".";

        return message;
    }
}
