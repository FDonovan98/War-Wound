using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Rotates the camera to switch the view between two 'scenes'
public class RotateCamera : MonoBehaviour
{
    private bool lookingLeft = true;
    private int degreesOfRotation = 90;

    private void RotateRight()
    {
        Camera.main.transform.Rotate(0, degreesOfRotation, 0);
    }

    private void RotateLeft()
    {
        Camera.main.transform.Rotate(0, -degreesOfRotation, 0);
    }

    public void OnButtonPress()
    {
        if(lookingLeft)
        {
            RotateRight();
            lookingLeft = false;
        } else
        {
            RotateLeft();
            lookingLeft = true;
        }
    }
}
