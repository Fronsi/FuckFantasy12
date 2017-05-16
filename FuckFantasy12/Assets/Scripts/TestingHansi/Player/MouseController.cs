using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {

    public enum eRotationAxis { MouseY, MouseX};
    public eRotationAxis cameraDirection = eRotationAxis.MouseY;
    public float fRotationSpeedX = 10.0f;
    public float fRotationSpeedY = 10.0f;

    private float xMin = -60.0f;
    private float xMax = 60.0f;
    private float fRotationX = 0.0f;

	// Use this for initialization
	void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked; ;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (cameraDirection == eRotationAxis.MouseY)
        {
            transform.Rotate(0.0f, Input.GetAxis("Mouse X") * fRotationSpeedY, 0.0f);
        }
        if (cameraDirection == eRotationAxis.MouseX)
        {
            fRotationX += Input.GetAxis("Mouse Y") * fRotationSpeedX;
            fRotationX = Mathf.Clamp(fRotationX, xMin, xMax);
            transform.localEulerAngles = new Vector3(-fRotationX, transform.localEulerAngles.y, 0.0f);
        }
	}
}
