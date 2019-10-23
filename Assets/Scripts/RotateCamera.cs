using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private bool LookingLeft = true;
    private int DegreesOfRotation = 90;

    private void RotateRight()
    {
        Camera.main.transform.Rotate(0, DegreesOfRotation, 0);
    }

    private void RotateLeft()
    {
        Camera.main.transform.Rotate(0, -DegreesOfRotation, 0);
    }

    public void OnButtonPress()
    {
        if(LookingLeft)
        {
            RotateRight();
            LookingLeft = false;
        } else
        {
            RotateLeft();
            LookingLeft = true;
        }
    }
}
