using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class rotato : MonoBehaviour
{

   // public OVRGrabber LeftGrabber; // Drag grabber to inspector field
    public OVRGrabbable knob;
    private OVRInput.Controller hand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       
        if (knob.isGrabbed)
        {
            //Do something
            hand = OVRInput.GetActiveController();
            Quaternion angles = OVRInput.GetLocalControllerRotation(hand);
            transform.rotation = Quaternion.Euler(0, angles.eulerAngles.y, 0);
        }


        //Quaternion angles = InputTracking.GetLocalRotation(VRNode.Head);
      
        //transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);

    }


    private void FixedUpdate()
    {
    //    transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);
    }

}
