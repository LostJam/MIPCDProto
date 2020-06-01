using UnityEngine;
using System.Collections;

public class menuSwitcher : MonoBehaviour
{
    public GameObject[] menus;
    private int currentIndex;

    // Use this for initialization
    void Start()
    {
        currentIndex = 0;

        //Turn all cameras off, except the first default one
        for (int i = 1; i < menus.Length; i++)
        {
            menus[i].SetActive(false);
        }

        //If any cameras were added to the controller, enable the first one
        if (menus.Length > 0)
        {
            menus[0].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If the b button is pressed, switch to the next camera
        //Set the camera at the current index to inactive, and set the next one in the array to active
        //When we reach the end of the camera array, move back to the beginning or the array.
       // OVRInput.Update();

      //  Debug.Log("HIT THE STICKKKKKKK" + OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick, OVRInput.Controller.RTouch));


        var released = OVRInput.GetUp(OVRInput.Button.Two, OVRInput.Controller.RTouch);
        if (released)
        {
            currentIndex++;
            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA Switching to the next menu" + currentIndex);
            if (currentIndex < menus.Length)
            {
                menus[currentIndex - 1].SetActive(false);
                menus[currentIndex].SetActive(true);
            }
            else
            {
                menus[currentIndex - 1].SetActive(false);
                currentIndex = 0;
                menus[currentIndex].SetActive(true);
            }
        }
    }
}