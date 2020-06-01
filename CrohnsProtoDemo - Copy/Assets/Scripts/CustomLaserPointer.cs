using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomLaserPointer : MonoBehaviour
{
    public LineRenderer laserLineRenderer;
    public float laserWidth = 0.01f;
    public float laserMaxLength = 50f;
    private GraphicRaycaster castBoy;
    public Vector3 endPosition;
    public bool isDown;
    public bool triggerUp;
    public bool shootingLaser;
    public bool leftClick;
    public bool thumbUp;
    public bool thumbDown;
    public Vector2 thumbAxis;

    public GameObject itemHit = null; 


    public OvrAvatar ovrAvatar;

    void Start()
    {
        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        laserLineRenderer.SetPositions(initLaserPositions);
        laserLineRenderer.startWidth = laserWidth;
        laserLineRenderer.endWidth = laserWidth;

    }
    void Update()
    {
      //  if (OVRInput.Get(OVRInput.RawTouch.RIndexTrigger))
      //  {
        if (ovrAvatar)
        {
            if (ovrAvatar.HandRight)
            {
                shootingLaser = true;
                ShootLaserFromTargetPosition(ovrAvatar.HandRight.transform.position, ovrAvatar.HandRight.transform.forward, laserMaxLength);
                laserLineRenderer.enabled = true;
            }
        }
        else
        {
            laserLineRenderer.enabled = false;
            shootingLaser = false;
        }

       // IF THERES AN ITEM IN HAND tODO
       // }
        // isDown is our "right click" 
        thumbUp = OVRInput.Get(OVRInput.RawButton.RThumbstickUp);
        thumbDown = OVRInput.Get(OVRInput.RawButton.RThumbstickDown);
        thumbAxis = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);
     //   Debug.Log(thumbAxis);
        leftClick = OVRInput.GetDown(OVRInput.RawButton.RHandTrigger);
        triggerUp = OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger);
        isDown = OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger);
    }

    void ShootLaserFromTargetPosition(Vector3 targetPosition, Vector3 direction, float length)
    {
        Ray ray = new Ray(targetPosition, direction);
        endPosition = targetPosition + (length * direction);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, length))
        {
            itemHit = raycastHit.collider.gameObject;
            endPosition = raycastHit.point;

            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            pointerData.position = endPosition; 

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);

            if (results.Count > 0)
            {
           
                castBoy = results[results.Count - 1].gameObject.GetComponentInParent<GraphicRaycaster>();
                results.Clear();

                PointerEventData ped = new PointerEventData(null);
                ped.position = endPosition;
                ////Create list to receive all results
                List<RaycastResult> rez = new List<RaycastResult>();
                //put the results of the event data in the list
                castBoy.Raycast(ped, rez);

            }
        }
        
        laserLineRenderer.SetPosition(0, targetPosition);
        laserLineRenderer.SetPosition(1, endPosition);

    }

    
}