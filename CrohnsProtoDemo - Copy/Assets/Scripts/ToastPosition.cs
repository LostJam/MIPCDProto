using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToastPosition : MonoBehaviour
{
    public Camera oculus;
    public Transform childToast;
    private string typeOfNotif;
    private float startTime;
    private float t = 0;
    Vector3 finalPosition;
    Vector3 toast;
    Vector3 distance;

    private void OnEnable()
    {
        startTime = Time.time;
        //get first position of notification
        toast = transform.position;
        distance = (toast - oculus.transform.position);
        typeOfNotif = this.gameObject.name;
    }

    void FixedUpdate()
    {
        t = (Time.time - startTime);
        if (t < 3)
        {
            

            switch (typeOfNotif)
            {
                case "above":
                    transform.position = new Vector3(childToast.position.x, 4, childToast.position.z);
                    break;
                case "below":

                    finalPosition = oculus.transform.forward;
                    finalPosition.normalized.Scale(distance);
                    transform.position = toast + new Vector3(finalPosition.x, 0, finalPosition.z);

                    break;
                case "free":
                    break;
                case "error":
                    break;
                case "arrow":
                    break;

            }
            transform.LookAt(oculus.transform);
        }
        else
        {
            this.gameObject.SetActive(false);
        }

    }
}
