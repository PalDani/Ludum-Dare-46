using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientNameGenerator : MonoBehaviour
{
    public static string GetFemaleName()
    {
        var names = Resources.Load<TextAsset>("names_female").text;
        var list = names.Split(';');
        return list[Random.Range(0, list.Length - 1)];
    }

    public static string GetMaleName()
    {
        var names = Resources.Load<TextAsset>("names_male").text;
        var list = names.Split(';');
        return list[Random.Range(0, list.Length - 1)];
    }
}
