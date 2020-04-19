using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public List<Task> taskList;
    private LinkedList<Task> tasksToExecute = new LinkedList<Task>();

    public bool autoStart = true;
    public float delayBeforeFirstStart = 3f;
    public float delayBetweenStarts = 3f;
    public bool repeatFirst = false;

    private void Start()
    {
        foreach (var t in taskList)
        {
            tasksToExecute.AddLast(t);
        }
    }

    public void TriggerFirstInQueue()
    {
        StartCoroutine(DelayedFirstTrigger());
    }

    public void TriggerAll()
    {
        StartCoroutine(DelayedTriggerAll());
    }

    private IEnumerator DelayedFirstTrigger()
    {
        yield return new WaitForSeconds(delayBeforeFirstStart);
        tasksToExecute.First.Value.Execute();
        if(!repeatFirst)
            tasksToExecute.RemoveFirst();
    }

    private IEnumerator DelayedTriggerAll()
    {
        yield return new WaitForSeconds(delayBeforeFirstStart);
        foreach (var t in taskList)
        {
            StartCoroutine(DelayedTrigger(t));
            //tasksToExecute.RemoveFirst();
        }
    }

    private IEnumerator DelayedTrigger(Task t)
    {
        yield return new WaitForSeconds(delayBetweenStarts);
        t.Execute();
    }
}
