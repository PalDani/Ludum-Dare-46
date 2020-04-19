using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class RoomEntryPoint : MonoBehaviour
{
    [SerializeField] private TreatmentRoom room;
    public TreatmentRoom Room { get { return room; } }

    void Start()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NPC" && other.GetComponent<NPCLink>() != null)
        {
            Patient npcData = other.GetComponent<NPCLink>().NPCObject.GetComponent<Patient>();

            if(npcData.Injury.InjuryType == Room.TreatmentType1 || npcData.Injury.InjuryType == Room.TreatmentType2)
            {
                Room.StartTreatment(npcData.Injury.TreatmentTime);
            } else
            {
                PlayerData.Instance.Dead++;
            }
            npcData.Remove();
        }
    }
}
