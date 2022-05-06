using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCamera : MonoBehaviour
{
    [SerializeField] private float _speedMovement = 1f;
    [SerializeField] private float _boostMultiplier = 2f;
    [SerializeField] private float _speedRotation = 1f;

    [SerializeField] private KeyCode _stopKey = KeyCode.Space;
    [SerializeField] private KeyCode _boostKey = KeyCode.LeftShift;

    private readonly string _verticalAcceleration = "Vertical";
    private readonly string _horizontalAcceleration = "Horizontal";

    private void Update()
    {
        if (Input.GetKey(_stopKey)) return;

        Movement();
        Rotation();
    }

    private void Movement()
    {
        var vertical = Input.GetAxis(_verticalAcceleration);
        var horizontal = Input.GetAxis(_horizontalAcceleration);
        var boost = Input.GetKey(_boostKey) ? _boostMultiplier : 1f;
        var direction = Vector3.forward * vertical + Vector3.right * horizontal;
        transform.Translate(direction * _speedMovement * boost * Time.deltaTime);
    }

    private void Rotation()
    {
        var x = Input.GetAxis("Mouse X");
        var y = Input.GetAxis("Mouse Y");
        var lastMouse = new Vector3(-y * _speedRotation, x * _speedRotation, 0);
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
    }


}
