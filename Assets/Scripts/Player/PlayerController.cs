using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

    [SerializeField]
    private float speedMultiple = 1;

    [SerializeField]
    private float attackMultiple = 1;

    public Boosts.boostTypes activeBoost { get; set; }
    private Stopwatch stopwatch = new Stopwatch();

    Player player;
    new Rigidbody rigidbody;
    float score;

    private void Awake()
    {
        player = GetComponent<Player>();
        rigidbody = GetComponent<Rigidbody>();
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
        var move = new Vector3(player.GetAxis(InputActions.Horizontal), 0, player.GetAxis(InputActions.Vertical));
        rigidbody.MovePosition(transform.position + move * moveSpeed * Time.fixedDeltaTime * speedMultiple);
    }

    void Rotate()
    {
        //var direction = new Vector3(player.GetAxis(InputActions.RightHorizontal), 0, player.GetAxis(InputActions.RightVertical));
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
                Destroy(hit[i].gameObject);
                score++;
            }

            ScoreManager.Instance.UpdateScore(player.ID, score);    
        }
    }

    void boostsController()
    {
        if (activeBoost == Boosts.boostTypes.NONE)
        {
            return;
        }


        stopwatch.Start();

        if (stopwatch.ElapsedMilliseconds <= Boosts.BONUS_TIME_MILISEC)
        {
            if (activeBoost == Boosts.boostTypes.SPEED)
            {
                speedMultiple   = 1.4f;
            }
            else if (activeBoost == Boosts.boostTypes.POWER)
            {
                attackMultiple = 1.5f;
            }
            else if (activeBoost == Boosts.boostTypes.GRENADE_HEAL)
            {
                PlayerBase.Instance.currentHP += 20;
            }
        }
        else
        {
            speedMultiple = 1;
            activeBoost = Boosts.boostTypes.NONE;
        }
            
    }
}
