using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float doorSpeed = 1.5f;

    [Header("Simple door")]
    [SerializeField] private Transform openedStatePosition;

    private Vector3 closedStatePosition;
    protected bool isOpen = false;

    void Start()
    {
        closedStatePosition = transform.position;
    }

    void Update()
    {
        if (isOpen && transform.position != openedStatePosition.position)
            transform.position = Vector3.MoveTowards(transform.position, openedStatePosition.position, Time.deltaTime * doorSpeed);

        if (!isOpen && transform.position != closedStatePosition)
            transform.position = Vector3.MoveTowards(transform.position, closedStatePosition, Time.deltaTime * doorSpeed);
    }

    public void Open()
    {
        isOpen = true;
    }

    public void Close()
    {
        isOpen = false;
    }
}
