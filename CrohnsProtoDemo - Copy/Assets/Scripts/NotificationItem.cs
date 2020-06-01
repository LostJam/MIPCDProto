using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationItem : MonoBehaviour
{

    void Start()
    {
        //for each item with this script attached
        //search for its name as a bool key in the dictionary
        //if its true, add this game object 

        // if its a reference for other notifications (above and below, those objects also need to activate 
        if (this.name == "freeBelowRef")
        {

        }

       if (NotificationManager.checkedFeatures.ContainsKey(this.name))
        {
                // only add it if the boolean is set
                if (NotificationManager.checkedFeatures[this.name])
                {
                    NotificationManager.RegisterNotif(this.gameObject);
                }
                this.gameObject.SetActive(false);
            
        }

    }


}
