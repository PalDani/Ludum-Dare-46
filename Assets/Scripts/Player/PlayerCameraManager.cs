using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraManager : MonoBehaviour
{

    [SerializeField] private float rotateSpeed = 1;

    [SerializeField] private float YRotationDgAllowance = 15;
    [SerializeField] private LayerMask clickLayer;

    private float minYRotDg;
    private float maxYRotDg;
    private Camera cam;

    private RaycastHit hit;

    GameObject mouseWorldPos;

    [Header("Components")]
    [SerializeField] private PlayerSelectionManager selectionManager;

    private void Awake()
    {
        mouseWorldPos = new GameObject("[Mouse In World]");
    }

    void Start()
    {
        cam = GetComponent<Camera>();
        if (selectionManager == null)
            selectionManager = GetComponent<PlayerSelectionManager>();

        minYRotDg = transform.rotation.y - YRotationDgAllowance;
        maxYRotDg = transform.rotation.y + YRotationDgAllowance;

        if(minYRotDg > maxYRotDg)
        {
            var temp = minYRotDg;
            minYRotDg = maxYRotDg;
            maxYRotDg = temp;
        }

        GetComponent<UnityEngine.Rendering.PostProcessing.PostProcessVolume>().isGlobal = true;
    }


    void Update()
    {
        MouseMovement();
        InputManager();
    }

    private void InputManager()
    {
        var ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(1))
        {
            
            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Untagged")
                {
                    selectionManager.DeselectCurrent();
                }

                if (hit.collider.tag == "NPC")
                {
                    WindowManager.Instance.ShowNPCData(hit.transform.GetComponent<NPCLink>().NPCObject.GetComponent<Patient>());
                }
            }
        }

        if(Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                /*if (hit.transform.tag == "Untagged" && selectionManager.SelectedObject != null)
                {
                    selectionManager.DeselectCurrent();
                }*/

                if(/*hit.collider.gameObject.name == "[Radio]"*/hit.collider.tag == "Radio")
                {
                    hit.collider.GetComponent<Radio>().Switch();
                }

                if (hit.collider.tag == "NPC")
                {;
                    selectionManager.Select(hit.collider.GetComponent<NPCLink>().NPCObject);
                    //Instantiate(clickEffect, hit.transform.position + Vector3.up, Quaternion.identity);
                }

                if(hit.transform.tag == "TreatmentRoom")
                {
                    TreatmentRoom selectedRoom = hit.collider.GetComponent<RoomLink>().Room;
                    if(selectionManager.SelectedObject != null && selectionManager.SelectedObject.GetComponent<Patient>() != null)
                    {
                        if(!selectedRoom.IsInUse)
                        {
                            selectionManager.SelectedObject.GetComponent<Patient>().npcComponent.SetPath(selectedRoom.roomEntry.position);
                        } else
                        {
                            selectedRoom.HighlightDisplay();
                        }
                    }
                }
            }
        }
    }

    public void MouseMovement()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10;
        var mouseInWorld = cam.ScreenToWorldPoint(mousePos);

        mouseWorldPos.transform.position = mouseInWorld;
    }

    private void ClampCamera()
    {
        //var rotation = new Vector3(transform.localRotation.x , Mathf.Clamp(transform.rotation.y, minYRotDg, maxYRotDg), transform.localRotation.z);
        //transform.Rotate(rotation, Space.Self);
    }
}
