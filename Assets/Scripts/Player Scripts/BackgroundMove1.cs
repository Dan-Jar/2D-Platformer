using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove1 : MonoBehaviour
{
    public Transform mainCam;
   
    // ref to main background image
    public Transform middleImage;

    // ref to the side background image
    public Transform edgeImage;

    public float lengthImage = 53f;

   

    // Update is called once per frame
    void Update()
    {

        // moving images to right
        if (mainCam.position.x > middleImage.position.x)
        {
            edgeImage.position = middleImage.position + Vector3.right * lengthImage;
        }



        // moving images to left
        if (mainCam.position.x < middleImage.position.x)
        {
            edgeImage.position = middleImage.position + Vector3.left * lengthImage;

        }
        

        if(mainCam.position.x > edgeImage.position.x || mainCam.position.x < edgeImage.position.x)
        {
            // temp store middle image for lines 44 and 45 to execute properly 
            Transform temp = middleImage;

            middleImage = edgeImage;
            edgeImage = temp;
        }

    }
}
