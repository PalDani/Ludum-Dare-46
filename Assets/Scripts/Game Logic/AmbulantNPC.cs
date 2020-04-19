using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AmbulantNPC : MonoBehaviour
{
    public NPC npcObj;
    public float leaveRange = 4f;
    public float leaveTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<NavMeshAgent>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(npcObj.CurrentPath, transform.position) <= leaveRange)
        {
            DisconnectFromCarrying();
        }
    }

    public void DisconnectFromCarrying()
    {
        transform.parent = null;
        npcObj.EnableAgent();
        npcObj.SetPath(GameObject.Find("[Ambulant Exit path]").transform.position);
        npcObj.animator.SetBool("Move", true);
        StartCoroutine(Leave());
    }

    private IEnumerator Leave()
    {
        yield return new WaitForSeconds(leaveTime);
        AmbulanceCar.Instance.Leave();
        Destroy(gameObject);
    }
}
