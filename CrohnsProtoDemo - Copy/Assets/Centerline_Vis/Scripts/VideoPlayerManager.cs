using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerManager : MonoBehaviour {


    VideoPlayer videoPlayer;
    long current_frame;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        current_frame = 0;
    }

    // Use this for initialization
    void Start () {
        print("Video Player Count " + videoPlayer.clip.frameCount);
        videoPlayer.frame = current_frame;
        videoPlayer.Pause();


    }
	
	// Update is called once per frame
	void Update ()
    {
        //  if (OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick).y != 0)
        //change to if left control stick left then press left arrow. 
        if (Input.GetKey(KeyCode.LeftArrow))

       {

        

            current_frame -= 1;

            if (current_frame <= 0)
            {
                current_frame = 0;
            }

            videoPlayer.frame = current_frame;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            current_frame += 1;

            videoPlayer.StepForward();
        }


        //print("Current");
        //print(current_frame);
        //print(videoPlayer.frame);
        //print(" ");




    }
}
