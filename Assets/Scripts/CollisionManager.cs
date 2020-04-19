using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] private LayerMask PropsMask;

    // Start is called before the first frame update
    void Start()
    {
        IgnoreNPCCollisionToElevators();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void IgnoreNPCCollisionToElevators()
    {
        Physics.IgnoreLayerCollision(PropsMask, PropsMask, true);
    }
}
