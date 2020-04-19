using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : MonoBehaviour
{

    public string PatientName;
    public int PatientAge;
    public int PatientGender; //0 - male | 1 = female
    public bool IsYoung { get { return PatientAge < 18; } }
    public PatientInjuryData Injury;

    public float deathTime;
    public bool isInHospital = false;
    private bool dead = false;

    public NPC npcComponent;

    public void ConstructPatient()
    {
        PatientAge = Random.Range(18, 60);
        Injury = new PatientInjuryData();
        Injury.InjuryType = (PatientInjuries) System.Enum.GetValues(typeof(PatientInjuries)).GetValue(Random.Range(0, System.Enum.GetValues(typeof(PatientInjuries)).Length-1));
        Injury.TreatmentTime = Random.Range(5, 20);
        var d = (Injury.TreatmentTime > 11 ? Injury.TreatmentTime - 2 : Injury.TreatmentTime);
        deathTime = d < 11 ? 11 : d;
        PatientGender = Random.Range(0, 1);
        PatientName = (PatientGender == 0 ? PatientNameGenerator.GetMaleName() : PatientNameGenerator.GetFemaleName());
        npcComponent.name = "[NPC] " + PatientName;
        Injury.AccidentMessage = PatientInjuryData.CreateAccidentMessage(PatientName, PatientGender, Injury.InjuryType);
        StartCoroutine(StartDeathTimer());
    }

    void Start()
    {

    }

    void Update()
    {
        if(isInHospital)
            deathTime -= Time.deltaTime;

        if (deathTime <= 0 && !dead)
        {
            dead = true;
            PlayerData.Instance.Dead++;
            RemoveInstant();
        }
    }

    public void Remove()
    {
        Destroy(gameObject, 2);
    }
    public void RemoveInstant()
    {
        Destroy(gameObject);
    }

    private IEnumerator StartDeathTimer()
    {
        yield return new WaitForSeconds(3);
        isInHospital = true;
    }
}
