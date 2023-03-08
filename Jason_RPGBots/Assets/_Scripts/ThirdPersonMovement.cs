using System;
using TMPro;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] float _turnSpeed = 1000f;
    [SerializeField] float  _moveSpeed = 5f;
    private Rigidbody _ridigbody;
    private Animator _animator;

    private void Awake()
    {
        _ridigbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        float mouseMovement = Input.GetAxis(StringLiterals.MouseX);
        transform.Rotate(0, mouseMovement * Time.deltaTime * _turnSpeed, 0);
    }

    //For physics updates
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis(StringLiterals.Horizontal);
        float vertical = Input.GetAxis(StringLiterals.Vertical);
        if(Input.GetKey(KeyCode.LeftShift)) 
        {
            vertical *= 2f;
        }

        Vector3 velocity = new Vector3(horizontal, 0, vertical);
        velocity *= _moveSpeed * Time.fixedDeltaTime;
        Vector3 offset = transform.rotation * velocity;
        _ridigbody.MovePosition(transform.position + offset);
        _animator.SetFloat(StringLiterals.AnimatorHorizontal, vertical, 0.1f, Time.deltaTime);
        _animator.SetFloat(StringLiterals.AnimatorVertical, horizontal, 0.1f, Time.deltaTime);
        Debug.Log(vertical);
    }
}
