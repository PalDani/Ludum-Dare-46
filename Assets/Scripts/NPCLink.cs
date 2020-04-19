using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCLink : MonoBehaviour
{
    public GameObject NPCObject;

    private void Start()
    {
        if (NPCObject == null)
            NPCObject = transform.root.gameObject;
    }
}
