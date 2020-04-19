using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Task : MonoBehaviour
{
    public virtual void Execute()
    {
        Debug.Log("Task executed.");
    }
}
