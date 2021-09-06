using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] float _RotationSpeed;
    [SerializeField] float _MoveSpeed;
    [SerializeField] float _ScrollSpeed;
    Camera _cam;
    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            float rotateX = Input.GetAxis("Mouse X");
            float rotateY = Input.GetAxis("Mouse Y");
            transform.Rotate(new Vector3(0, rotateX, -rotateY) *Time.deltaTime* _RotationSpeed);
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        }
        float translateForward = Input.GetAxis("Vertical");
        float translateRight = Input.GetAxis("Horizontal");
        float translateUp = 0;
        if (Input.GetKey(KeyCode.Space))
        {
            translateUp = 1;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            translateUp = -1;
        }

        float scrollDelta = Input.mouseScrollDelta.y;
        Vector2 camLocalPos = _cam.transform.localPosition;
        camLocalPos.x = Mathf.Clamp(camLocalPos.x + scrollDelta * _ScrollSpeed, 0, 100);
        _cam.transform.localPosition = camLocalPos;

        Vector3 forward = Vector3.ProjectOnPlane(_cam.transform.forward, Vector2.up).normalized;
        Vector3 right = Quaternion.Euler(0, 90, 0) * forward;


        Vector3 translation = (forward * translateForward + right * translateRight + Vector3.up * translateUp)*Time.deltaTime* _MoveSpeed;
        transform.position+= translation;
    }
}
