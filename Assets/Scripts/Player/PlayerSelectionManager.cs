using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectionManager : MonoBehaviour
{
    public GameObject SelectedObject;
    public GameObject SelectionMarker;
    public Vector3 SelectionMarkerOffset;

    private GameObject selectionMarkerInstance;

    void Start()
    {
        GameObject go = Instantiate (SelectionMarker, Vector3.zero, Quaternion.identity);
        go.name = "[Selection Marker]";
        selectionMarkerInstance = go;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void LateUpdate()
    {
        if (SelectedObject != null)
            selectionMarkerInstance.transform.position = SelectedObject.transform.position + SelectionMarkerOffset;
        else selectionMarkerInstance.transform.position = Vector3.zero;
    }

    public void Select(GameObject go)
    {
        SelectedObject = go;
    }

    public void DeselectCurrent()
    {
        selectionMarkerInstance.transform.position = Vector3.zero;
        SelectedObject = null;
    }
}
