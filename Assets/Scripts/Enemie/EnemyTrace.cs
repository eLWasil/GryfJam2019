using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrace : MonoBehaviour
{
    [SerializeField]
    float scoreForKill = 10;

    [SerializeField]
    float HP = 2;

    public float speed;

    EnemyRespawnController respawnController;
    new Rigidbody rigidbody;

    bool blockInput;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Init(EnemyRespawnController respawnController)
    {
        this.respawnController = respawnController;
    }

    void Update()
    {
        if (!PlayerBase.Instance.IsGameRunning || blockInput == true)
            return;

        var granary = PlayerBase.Instance.gameObject;

        var direction = (granary.transform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    public void ApplyDamage(PlayerController player, float damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            player.Score += scoreForKill;
            UIManager.Instance.UpdateScore(player.ID, player.Score);
            Destroy(gameObject);
        }
        else
        {
            rigidbody.AddForce(player.transform.forward * 80, ForceMode.VelocityChange);
            StartCoroutine(BlockInput());
        }
    }

    IEnumerator BlockInput()
    {
        blockInput = true;
        yield return new WaitForSeconds(1);
        blockInput = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var playerBase = collision.transform.GetComponent<PlayerBase>();

        if (playerBase == null) return;

        playerBase.ApplyDamage(5);
        Destroy(gameObject);
    }
}
