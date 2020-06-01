using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class submenuItem : MonoBehaviour
{

    private void Start()
    {
        submenuBehavior.RegisterSubmenu(this.name, this.gameObject);
        //if (this.name != "camera")
        //{
            this.gameObject.SetActive(false);

        //}
    }
}
