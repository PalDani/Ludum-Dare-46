using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbulanceCar : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public Animator CarAnimator { get { return animator; } }

    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Quaternion startRotation;

    public static AmbulanceCar Instance;

    void Start()
    {
        Instance = this;

        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    void Update()
    {
        
    }

    public void Arrive()
    {
        GetComponent<TaskManager>().TriggerFirstInQueue();
        CarAnimator.SetTrigger("Arrive");
        //CarAnimator.ResetTrigger("Leave");
    }

    public void Leave()
    {
        CarAnimator.SetTrigger("Leave");
        //CarAnimator.ResetTrigger("Arrive");
        StartCoroutine(OnLeave());
    }

    private void ResetPos()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;
    }

    private IEnumerator OnLeave()
    {
        yield return new WaitForSeconds(3.3f);
        //ResetPos();
        CarAnimator.ResetTrigger("Arrive");
        CarAnimator.ResetTrigger("Leave");
    }
}
