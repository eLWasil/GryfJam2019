using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 50;
    [SerializeField]
    private float rotationSpeed = 500;

    private  PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        Rotate();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        var move = new Vector3(playerInput.GetAxis(PlayerInput.InputActions.Horizontal), 0, playerInput.GetAxis(PlayerInput.InputActions.Vertical));
        //transform.position += transform.InverseTransformDirection(move) * moveSpeed * Time.deltaTime;
        transform.position += move * moveSpeed * Time.deltaTime;
    }

    void Rotate()
    {
        var move = new Vector3(playerInput.GetAxis(PlayerInput.InputActions.RightHorizontal), 0, playerInput.GetAxis(PlayerInput.InputActions.RightVertical));
        if (move == Vector3.zero) return;

        Quaternion wantedRotation = Quaternion.LookRotation(move);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, wantedRotation, rotationSpeed * Time.deltaTime);

        //var move = new Vector3(playerInput.GetAxis(PlayerInput.InputActions.Rotation), 0, 0);
        //var rotation = playerInput.GetAxis(PlayerInput.InputActions.Rotation);
        //transform.Rotate(0, rotation * rotationSpeed * Time.deltaTime, 0);
    }
}
