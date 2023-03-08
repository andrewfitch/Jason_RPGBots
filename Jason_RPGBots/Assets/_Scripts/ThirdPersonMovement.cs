using System;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] float _turnSpeed = 1000f;
    [SerializeField] float  _moveSpeed = 5f;
    private Rigidbody _ridigbody;

    private void Awake()
    {
        _ridigbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float mouseMovement = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseMovement * Time.deltaTime * _turnSpeed, 0);
    }

    //For physics updates
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(horizontal, 0, vertical);
        velocity *= _moveSpeed * Time.fixedDeltaTime;
        Vector3 offset = transform.rotation * velocity;
        _ridigbody.MovePosition(transform.position + offset);
    }
}
