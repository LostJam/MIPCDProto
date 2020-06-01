using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public compute newComp;

//managaement class that changes the properties/uniforms in the shader to match
public class compute : MonoBehaviour
{
    private Matrix4x4 indexToWorld;
    public Matrix4x4 ITW {
        get
        {
            return indexToWorld;
        }
        set
        {
            if(value != indexToWorld)
            {
                //newComp.setFloat("ITW", value);
            }
        }
    }

   // float4x4 indexToWorld;
    //float3 paintPos0;
    //float paintRadius;
    //float3 paintPos1;
    //float paintValue;
    //float3 texelSize;

    //float3 CameraPosition;
    //float Projection43;
    //float3 LightPosition;
    //float Projection33;
    //float3 PlanePoint;
    //float Density;
    //float3 PlaneNormal;
    //float LightDensity;
    //float3 LightDirection;
    //float Exposure;
    //float3 WorldScale;
    //float LightIntensity;
    //float LightAngle;
    //float LightAmbient;
    //float TresholdValue;

    //create all the uniforms,
    //if theyve been changed set dirty to true
    //when true dispatch compute shader. 


    bool dirty;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (dirty) dispatch 
    }
}
