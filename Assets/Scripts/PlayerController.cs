using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputSystem_Actions inputs;    
    public CharacterController controller;
    [SerializeField]private Vector2 moveInputs;

    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;
    public float verticalVelocity;
    public float gravity = -9.8f;
    public void Awake()
    {
        controller = GetComponent<CharacterController>();
        inputs = new();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void OnEnable()
    {
        inputs.Enable();
        inputs.Player.Move.performed += ctx => moveInputs = ctx.ReadValue<Vector2>();
        inputs.Player.Move.canceled += ctx => moveInputs = Vector2.zero;
    }

    

    void Start()
    {
        
    }

    
    void Update()
    {
        Move();
    }
    public void Move()
    {
        transform.Rotate(Vector3.up *moveInputs.x * rotationSpeed * Time.deltaTime);
        Vector3 dir = transform.forward *moveSpeed * moveInputs.y;
        verticalVelocity += Physics.gravity.y * Time.deltaTime;
        if (!controller.isGrounded && verticalVelocity < 0) 
        {
            verticalVelocity = -2f;
            dir.y = verticalVelocity;        
        }
        controller.Move(dir * Time.deltaTime);
    }   

}
