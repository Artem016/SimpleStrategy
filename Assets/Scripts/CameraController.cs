using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 10.0f;
    public float translateSpeed = 10.0f;
    public float zoomSpeed = 1000.0f;
    private float _mult = 1f;

    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        float rotate = 0f;

        if (Input.GetKey(KeyCode.Q))
            rotate = -1f;
        else if(Input.GetKey(KeyCode.E))
        {
            rotate = 1f;
        }

        _mult = Input.GetKey(KeyCode.LeftShift) ? 2f : 1f;
        
        transform.Rotate(Vector3.up * rotationSpeed * rotate* _mult * Time.deltaTime, Space.World);
        transform.Translate(new Vector3(hor, 0 , ver) * _mult * translateSpeed * Time.deltaTime, Space.Self);
        transform.position += transform.up * -zoomSpeed * Time.deltaTime * Input.GetAxis("Mouse ScrollWheel");
        transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(transform.position.y, -20f, 30f),
            transform.position.z);


    }
}
