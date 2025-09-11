using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerOneController : MonoBehaviour
{
    [SerializeField] private CharacterController playerController;
    [SerializeField] private InputActionReference movement;
    [SerializeField] private int speed;
    private Vector3 movementDirection;



    // Start is called before the first frame update
    void Start()
    {
        movement.action.Enable();
    }

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        
        Vector2 inputDirection = movement.action.ReadValue<Vector2>();
        movementDirection = new Vector3(inputDirection.x, 0, inputDirection.y);
        playerController.Move(movementDirection* speed * Time.deltaTime);
    }
}

