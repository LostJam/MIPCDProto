using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFollowsVolume : MonoBehaviour
{
    private GameObject body;
    public Transform oculus;
    private Vector3 startPos;
    private Vector3 startMenuPos;

    void Update()
    {
        if (body == null)
        {
            if (submenuBehavior.Organs.ContainsKey("body"))
            {
                body = submenuBehavior.Organs["body"];
            }
        }
        if (body != null)
        {
            this.transform.LookAt(2 * transform.position - oculus.position);
            if (!grabbingBehavior.holding)
            {
                startPos = body.transform.position;
                startMenuPos= this.transform.position;
            }
            else
            {
                this.transform.position = Vector3.Lerp(this.transform.position, startMenuPos + (body.transform.position - startPos), Mathf.Clamp01(Time.deltaTime * 2));
            }
        }
    }
}
