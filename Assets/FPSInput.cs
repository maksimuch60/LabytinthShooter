using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]

public class FPSInput : MonoBehaviour
{
    private CharacterController _charController;
    private float speed = 4f; //Ќеоб€зательный элемент на случай, если вы захотите увеличить скорость.
    private float upspeed = 7f;
    private float gravity = -0.30f;
    bool IsGrounded = true;

    Vector3 move;

    void Start()
    {
        Cursor.visible = false;
        _charController = GetComponent<CharacterController>();
    }
    void Update()
    {
        speed = 4f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = upspeed;
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            IsGrounded = false;
            StartCoroutine(jump());
            move.y += 0.26f;
            _charController.Move(move * Time.deltaTime);
        }
        if(_charController.isGrounded && move.y < 0)
        {
            move.y = -0.14f;
        }
        move.y += gravity*Time.deltaTime;
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
        _charController.Move(move);
    }
    IEnumerator jump()
    {
        yield return new WaitForSeconds(0.47f);
        IsGrounded = true;
    }
}
