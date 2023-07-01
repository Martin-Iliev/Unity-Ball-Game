using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform target;
    [SerializeField]
    GameObject player;

    public float xOffset, yOffset, zOffset;
    public float rotateX,rotateY,rotateZ;
    public float _tiltAmount = 5f;
    public float _rotationSpeed = 0.5f;

    void FixedUpdate()
    {
        transform.position = player.transform.position + new Vector3(xOffset, yOffset, zOffset);

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float rotX = verticalInput * _tiltAmount;
        float rotZ = -horizontalInput * _tiltAmount;

        Quaternion finalRot = Quaternion.Euler(rotX, 0, rotZ) * Quaternion.Euler(rotateX, rotateY, rotateZ);
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, finalRot, _rotationSpeed);
        //transform.localRotation = Quaternion.Lerp(transform.localRotation, finalRot, _rotationSpeed);   
    }
}