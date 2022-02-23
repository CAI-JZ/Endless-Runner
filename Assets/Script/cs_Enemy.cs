using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_Enemy : MonoBehaviour
{
    public GameObject ShortSword;
    public float Speed = 6f;
    public float dis = 10f;
    

    private float DistanceAixsY;
    private bool IsInRange;
    private bool AlreadyAttack;
    public float TimeBetweenAttack = 1.8f;
    private int Value = 50;

    GameObject Player;
    Rigidbody2D Rigid;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Rigid = GetComponent<Rigidbody2D>();
    }

    //Player Hit -> GAMEOVER
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.SendMessage("GameOver");
        }
    }

    // AttackPlayer
    void Attack()
    {
        if (IsInRange && !AlreadyAttack)
        {
            GameObject sword = cs_ObjectPool.Instance.GetObject(ShortSword);
            sword.transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
            sword.GetComponent<cs_Bullet>().SetSpeed(-transform.up);

            AlreadyAttack = true;
            Invoke(nameof(ResetAttack), TimeBetweenAttack);
        }
    }

    private void ResetAttack()
    {
        AlreadyAttack = false;
    }

    void ChasePlayer()
    {
        if (IsInRange)
        {
            DistanceAixsY = transform.position.x - Player.transform.position.x;
            if (DistanceAixsY <= -0.1f)
            {
                Rigid.MovePosition(new Vector2(transform.position.x + Speed * Time.deltaTime, transform.position.y));
                //print("Move Right");
            }
            else if (DistanceAixsY >= 0.1f)
            {
                Rigid.MovePosition(new Vector2(transform.position.x - Speed * Time.deltaTime, transform.position.y));
                //print("Move Left");
            }
            Attack();
        }
        
    }

    void Die()
    {
        cs_ObjectPool.Instance.PushObject(gameObject);
        cs_GameManager.Instance.UpdatePoint(Value);
        Debug.LogWarning("Enemy Die");
    }


    void Update()
    {
        
        IsInRange = Mathf.Abs(transform.position.y - Player.transform.position.y) <= dis;
    }

    private void FixedUpdate()
    {
        ChasePlayer();
    }
}
