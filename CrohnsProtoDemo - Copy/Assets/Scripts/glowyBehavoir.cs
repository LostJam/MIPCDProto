using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glowyBehavoir : MonoBehaviour
{
    private float start = 7;
    private float startTime;
    private float end = 0;
    public Camera center;
    private GameObject body;
    private Material glowyMat;
    private Vector4 emission = Vector4.one;
    private Vector3 cameraVec;
    private Vector3 cameraToBody;

    // Start is called before the first frame update
    void Start()
    {
        glowyMat = gameObject.GetComponent<Renderer>().material;
    }

    void OnEnable()
    {
        startTime = Time.time; 
    }

    void Update()
    {
        if (body == null)
        {
            if (submenuBehavior.Organs.ContainsKey("body"))
            {
                body = submenuBehavior.Organs["body"];
            }
        }
        if (this.name == "Plane")
        {
            if (body != null)
            {
                //get the direction from the center to the body (cameraToBody)
                //get angle between ctb and cameraCev
                //if ^ less than
                cameraVec = center.transform.forward;
            }
        }
        else
        {
            float t = ((Time.time - startTime) / 2);
            glowyMat.SetVector("_EmissionColor", emission * Mathf.Lerp(start, end, Mathf.Clamp01(t)));
            if (t > 1)
            {
                enabled = false;
            }
        }

    }
}
