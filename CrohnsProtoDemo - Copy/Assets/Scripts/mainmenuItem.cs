using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainmenuItem : MonoBehaviour
{
    private void Start()
    {
        submenuBehavior.RegisterMainMenu(this.name, this.gameObject);
        if (this.name == "larry1" || this.name == "larry2"/* || this.name == */)
        {
            this.transform.parent.parent.parent.parent.gameObject.SetActive(false);
        }
        //else if (this.name == "larry2")
        //{
        //    this.transform.parent.parent.parent.parent.gameObject.SetActive(false);
        //}
        //else if (this.name == "body")
        //{
        //    this.transform.gameObject.SetActive(false);
        //}
    }
}
