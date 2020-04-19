using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGroup : MonoBehaviour
{

    public float doorSpeed = 1.2f;

    public GameObject DoorLeft;
    public GameObject DoorRight;

    private void Start()
    {
        DoorLeft.GetComponent<Door>().doorSpeed = doorSpeed;
        DoorRight.GetComponent<Door>().doorSpeed = doorSpeed;
    }

    public void Open()
    {
        DoorLeft.GetComponent<Door>().Open();
        DoorRight.GetComponent<Door>().Open();
    }

    public void Close()
    {
        DoorLeft.GetComponent<Door>().Close();
        DoorRight.GetComponent<Door>().Close();
    }
}
