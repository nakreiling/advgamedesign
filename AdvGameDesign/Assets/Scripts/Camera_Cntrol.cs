using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Cntrol : MonoBehaviour {

	public enum RotationAxis
    {
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxis axes = RotationAxis.MouseX;

    //minimum and maximum vertical rotation for player
    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    //set sensitivity
    public float sensHorizontal = 10.0f;
    public float sensVertical = 10.0f;

    //vertical angle of where the player is looking
    public float _rotationX = 0;


	// Update is called once per frame
	void Update () {

        if(axes == RotationAxis.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensHorizontal, 0);
        } else if (axes == RotationAxis.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensVertical;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert); //clamps the vertical angle within the min and max limits
                                                                             //(45 degrees)

            //keep the y angle the same so there is no horizontal rotation
            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
		
	}
}
