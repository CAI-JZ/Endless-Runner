using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField]
    private EnemyUnit[] EnemyUnits;

    Rigidbody2D Rigid;

    private EnemyUnit Enemy;
    private float DistanceAixsY;
    private bool IsInRange;
    private bool AlreadyAttack;
    private float Value;
    public float _value => Value;

    private GameObject Player;

    private void OnEnable()
    {
        //Simple Math of Random EnemyType
        int r = Random.Range(1, 100);
        int R = r % EnemyUnits.Length;
        Enemy = EnemyUnits[R];
        //Inisially the Enemy
        GetComponent<SpriteRenderer>().sprite = Enemy.ArtWork;
        GetComponent<BoxCollider2D>().size = new Vector2(Enemy.SizeX, Enemy.SizeY);
        Value = Enemy.Value;
  
        Player = GameObject.FindGameObjectWithTag("Player");
        Rigid = GetComponent<Rigidbody2D>();
    }

    void Attack()
    {
        if (IsInRange && !AlreadyAttack && Enemy.CanAttack)
        {
            GameObject sword = ObjectPool.Instance.GetObject(Enemy.Bullet);
            sword.transform.position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
            sword.GetComponent<cs_Bullet>().SetSpeed(-transform.up);

            AlreadyAttack = true;
            Invoke(nameof(ResetAttack), Enemy.AttackCoolDown);
        }
    }
    private void ResetAttack()
    {
        AlreadyAttack = false;
    }

    void ChasePlayer()
    {
        if (IsInRange && Enemy.CanChasingPlayer)
        {
            DistanceAixsY = transform.position.x - Player.transform.position.x;
            if (DistanceAixsY <= -0.1f)
            {
                Rigid.MovePosition(new Vector2(transform.position.x + Enemy.Speed * Time.deltaTime, transform.position.y));
                //print("Move Right");
            }
            else if (DistanceAixsY >= 0.1f)
            {
                Rigid.MovePosition(new Vector2(transform.position.x - Enemy.Speed * Time.deltaTime, transform.position.y));
                //print("Move Left");
            }
            Attack();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && ProtectCricle.IsProtect)
        {
            GameManager.Instance.GameState(2);
        }
    }

    void Update()
    {
        if(GameManager.Instance._state == 1)
        IsInRange = Mathf.Abs(transform.position.y - Player.transform.position.y) <= Enemy.DisToAttack;
    }

    private void FixedUpdate()
    {
        ChasePlayer();

    }

    
}
