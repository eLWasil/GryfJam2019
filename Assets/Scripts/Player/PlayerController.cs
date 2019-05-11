using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    BoxCollider hitBox;

    [SerializeField]
    float moveSpeed = 50;
    [SerializeField]
    float rotationSpeed = 500;

    PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        Rotate();
        OnAttack();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        var move = new Vector3(playerInput.GetAxis(PlayerInput.InputActions.Horizontal), 0, playerInput.GetAxis(PlayerInput.InputActions.Vertical));
        transform.position += move * moveSpeed * Time.deltaTime;
    }

    void Rotate()
    {
        var direction = new Vector3(playerInput.GetAxis(PlayerInput.InputActions.RightHorizontal), 0, playerInput.GetAxis(PlayerInput.InputActions.RightVertical));

        if (direction == Vector3.zero) return;

        Quaternion wantedRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, wantedRotation, rotationSpeed * Time.deltaTime);
    }

    void OnAttack()
    {
        if (playerInput.GetButtonDown(PlayerInput.InputActions.Attack))
        {
            var hit = Physics.OverlapBox(hitBox.transform.position, hitBox.size * 2, hitBox.transform.rotation, 1 << LayerMask.NameToLayer("Enemy"));

            for (int i = 0; i < hit.Length; i++)
            {
                Destroy(hit[i].gameObject);
            }
        }
    }
}
