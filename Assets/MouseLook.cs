using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null) //ѕровер€ем, существует ли этот компонент.
            body.freezeRotation = true;
    }

    public RotationAxes axes = RotationAxes.MouseXAndY; //ќбъ€вл€ем общедоступную переменную,
                                                        //котора€ по€витс€ в редакторе Unity.
    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f; //ќбъ€вл€ем переменные, задающие поворот в вертикальной плоскости.

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    private float _rotationX = 0;

    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0); // это поворот в горизонтальной плоскости ђ
        }
        else if (axes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
            float delta = Input.GetAxis("Mouse X") * sensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);  // это комбинированный поворот ђ —юда поместим код дл€ комбинированного вращени€.
        }
    }
}
