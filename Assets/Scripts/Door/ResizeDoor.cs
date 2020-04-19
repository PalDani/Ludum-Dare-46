using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeDoor : Door
{
    [Header("Resize Door")]
    [SerializeField] private Vector3 openedScale;

    private Vector3 closedStateScale;

    void Start()
    {
        closedStateScale = transform.localScale;
    }

    void Update()
    {
        if (isOpen && transform.localScale != openedScale)
            transform.localScale = Vector3.MoveTowards(transform.localScale, openedScale, Time.deltaTime * doorSpeed);

        if (!isOpen && transform.localScale != closedStateScale)
            transform.localScale = Vector3.MoveTowards(transform.localScale, closedStateScale, Time.deltaTime * doorSpeed);
    }

    /*public void Open()
    {
        isOpen = true;
    }

    public void Close()
    {
        isOpen = false;
    }*/
}
