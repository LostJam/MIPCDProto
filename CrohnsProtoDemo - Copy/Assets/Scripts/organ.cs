using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class organ : MonoBehaviour
{

    private void Start()
    {
        submenuBehavior.RegisterOrgan(this.name, this.gameObject);
    }
}
