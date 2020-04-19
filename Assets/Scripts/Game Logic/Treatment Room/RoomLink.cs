using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLink : MonoBehaviour
{
    [SerializeField] private TreatmentRoom room;
    public TreatmentRoom Room { get { return room; } }
}
