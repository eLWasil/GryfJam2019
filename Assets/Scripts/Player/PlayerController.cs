using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    BoxCollider hitBox;

    [SerializeField]
    float moveSpeed = 50;
    [SerializeField]
    float rotationSpeed = 500;

    Player player;
    new Rigidbody rigidbody;

    public float Score;

    public PlayerId ID { get { return player.ID; } }

    private void Awake()
    {
        player = GetComponent<Player>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!PlayerBase.Instance.IsGameRunning)
            return;

        Rotate();
        OnAttack();
    }

    private void FixedUpdate()
    {
        if (!PlayerBase.Instance.IsGameRunning)
            return;

        Move();
    }

    void Move()
    {
        var move = new Vector3(player.GetAxis(InputActions.Horizontal), 0, player.GetAxis(InputActions.Vertical));
        rigidbody.MovePosition(transform.position + move * moveSpeed * Time.fixedDeltaTime);
    }

    void Rotate()
    {
        var direction = new Vector3(player.GetAxis(InputActions.Horizontal), 0, player.GetAxis(InputActions.Vertical));

        if (direction == Vector3.zero) return;

        Quaternion wantedRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, wantedRotation, rotationSpeed * Time.deltaTime);
    }

    void OnAttack()
    {
        if (player.GetButtonDown(InputActions.Attack))
        {
            var hit = Physics.OverlapBox(hitBox.transform.position, hitBox.size * 2, hitBox.transform.rotation, 1 << LayerMask.NameToLayer("Enemy"));

            for (int i = 0; i < hit.Length; i++)
            {
                var enemy = hit[i].transform.GetComponent<EnemyTrace>();

                if (enemy)
                {
                    enemy.ApplyDamage(this, 1);
                }
                else
                {
                    Destroy(hit[i].gameObject);
                }
            }

        }
    }
}
