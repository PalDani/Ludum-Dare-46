using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class DoorDetector : MonoBehaviour
{
    public DoorGroup doorGroup;
    public float detectionRange = 3;

    [SerializeField] private int count;

    private List<GameObject> npcListInRange = new List<GameObject>();

    RaycastHit hit;

    void Start()
    {
        
    }

    void Update()
    {
        count = npcListInRange.Count;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NPC")
        {
            npcListInRange.Add(other.gameObject);
            doorGroup.Open();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC")
        {
            npcListInRange.Remove(other.gameObject);
            if(npcListInRange.Count == 0)
                doorGroup.Close();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
