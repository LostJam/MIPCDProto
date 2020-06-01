using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabbingBehavior : MonoBehaviour
{
    public CustomLaserPointer laser;
    GameObject itemHit = null;
    GameObject itemHeld; 
    GameObject heldParent;
    public static bool holding;
    Vector3 min;
    Vector3 max;

    // Update is called once per frame
    void Update()
    {
        itemHit = laser.itemHit;
        if (holding)
        {
            //released completely
            if (laser.triggerUp)
            {
                //should set item back to original parent and detach from hand
                //if the laser is parented and itemHit exists
             //   if (itemHeld != null) //basically if holding??
                //{
                    if(itemHeld.transform.parent == laser.transform)
                    {
                        if (heldParent)
                        {
                            Debug.Log(heldParent);
                            itemHeld.transform.SetParent(heldParent.transform);
                        }
                        else
                        {
                        itemHeld.transform.SetParent(null);
                        }
                    }
                    holding = false;
                    itemHeld = null;
               // }
            } 
            else
            {
                if (itemHeld.name == "Dial") // touching dial
                {
                    Vector3 euler = laser.transform.localEulerAngles;
                    itemHeld.transform.localRotation = Quaternion.Euler(euler.z, itemHeld.transform.localEulerAngles.y, itemHeld.transform.localEulerAngles.z);
                }
                else if (itemHeld.name == "Handle")
                {
                    Vector3 itemPos = new Vector3(0, 0, 0);

                    min = itemHeld.transform.parent.gameObject.GetComponent<Collider>().bounds.min;
                    max = itemHeld.transform.parent.gameObject.GetComponent<Collider>().bounds.max;

                    // if (itemHeld.transform.localPosition.x > min.x && itemHeld.transform.localPosition.x < max.x)
                    // if (itemHeld.transform.localPosition.x > -112 && itemHeld.transform.localPosition.x < 110)
                    itemPos = itemHeld.transform.localPosition;
                    itemPos.x = Mathf.Lerp(itemHeld.transform.localPosition.x, itemHeld.transform.InverseTransformPoint(laser.endPosition).x, (15 * Time.deltaTime));
                    itemHeld.transform.localPosition = itemPos;
                
                }
                else if ((itemHeld.GetComponent<OVRGrabbable>() != null) && (laser.transform.childCount < 2))
                {
                    Debug.Log("HIIIIIIIIIIIIIII");
                    if (itemHeld.transform.parent != null)
                    {
                        heldParent = itemHeld.transform.parent.gameObject;
                    }
                    itemHeld.transform.SetParent(laser.transform);
                    if (laser.thumbAxis.y > 0.0)
                    {
                        Vector3 newPos = itemHeld.transform.localPosition;
                        newPos.y += laser.thumbAxis.y;
                        itemHeld.transform.localPosition = newPos;
                    }

                }

            }
        }
        else
        {
            //touching logs the hits
            if (laser.shootingLaser) 
            {
                if (itemHit != null)
                {

                    if (itemHit.name == "Dial") // touching dial
                    {
                        if (laser.isDown) {
                            itemHeld = itemHit;
                            holding = true;
                            Vector3 euler = laser.transform.localEulerAngles;
                            itemHeld.transform.localRotation = Quaternion.Euler(euler.z, itemHeld.transform.localEulerAngles.y, itemHeld.transform.localEulerAngles.z);
                        }
                    }
                    if ((itemHit.name == "Handle") && (laser.isDown))
                    {

                        holding = true;
                        itemHeld = itemHit;
                    }
                    else if ((itemHit.GetComponent<OVRGrabbable>() != null) && (laser.transform.childCount < 2) && (laser.isDown))
                    {
                        holding = true;
                        itemHeld = itemHit;
                        if (itemHeld.transform.parent != null)
                        {
                            heldParent = itemHeld.transform.parent.gameObject;
                        }
                        itemHeld.transform.SetParent(laser.transform);

                        if (laser.thumbAxis.y > 0.0)
                        {
                            Vector3 newPos = itemHeld.transform.localPosition;
                            newPos.y += laser.thumbAxis.y;
                            itemHeld.transform.localPosition = newPos;
                        }
                        Debug.Log("holding " + itemHeld);
                    }
                }
            }

        }




    }
}
