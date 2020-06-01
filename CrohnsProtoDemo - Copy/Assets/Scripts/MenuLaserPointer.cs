using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuLaserPointer : MonoBehaviour
{
    public LineRenderer laserLineRenderer;
    public float laserWidth = 0.1f;
    public float laserMaxLength = 50f;
    public Vector3 endPosition;

    void Start()
    {
        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        laserLineRenderer.SetPositions(initLaserPositions);
        laserLineRenderer.startWidth = laserWidth;
        laserLineRenderer.endWidth = laserWidth;
    }
    void Update()
    {
            drawLaser(this.transform.position, Vector3.down, laserMaxLength);
            laserLineRenderer.enabled = true;
    }

    void drawLaser(Vector3 startingPos, Vector3 direction, float length)
    {
        Ray ray = new Ray(startingPos, direction);
        endPosition = startingPos + (length * direction);
        endPosition.y = 0;
        laserLineRenderer.SetPosition(0, startingPos);
        laserLineRenderer.SetPosition(1, endPosition);    
    }
}
