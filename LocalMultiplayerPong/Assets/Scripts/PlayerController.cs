using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private float maximumYPosition = 4.2f;
    private Vector2 movementVector;

    public void Movement(InputAction.CallbackContext context)
    {
        movementVector = context.ReadValue<Vector2>().normalized;
    }

    void Update()
    {
        float deltaY = movementVector.y * movementSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y + deltaY, -maximumYPosition, maximumYPosition), transform.position.z);
    }
}
