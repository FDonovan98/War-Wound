using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private bool LookingLeft = true;

    private void RotateRight()
    {
        Camera.main.transform.Rotate(0.0f, 45.0f, 0.0f);
    }

    private void RotateLeft()
    {
        Camera.main.transform.Rotate(0.0f, -45.0f, 0.0f);
    }

    private void OnGUI()
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
