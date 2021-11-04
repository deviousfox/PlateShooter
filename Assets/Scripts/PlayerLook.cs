using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private float joystickSensivity;

    private float rotY;
    private float rotX;

    private void Update()
    {

        rotX -= joystick.Vertical* joystickSensivity;
        rotY += joystick.Horizontal * joystickSensivity;

        transform.rotation = Quaternion.Euler(rotX, rotY, 0);
    }
}
