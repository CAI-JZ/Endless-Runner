using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_CharacterController2D : MonoBehaviour,IHit
{
    Rigidbody2D m_ridgid;

    private float speed = 0;
    private bool IsGaming = false;
    private float MoveInput;
    private float Airspeed = -1.5f;

    
    //PortectCircle;
    private int PortectValue;

    //Attack
    private int BulletNum;
    [SerializeField]
    GameObject Bullet;
    private bool IsAttack;


    private void Awake()
    {
        m_ridgid = GetComponent<Rigidbody2D>();
        m_ridgid.gravityScale = 0;
        BulletNum = 10;
        //IsPortect = false;
        PortectValue = 0;
        
    }

    public void StartGame()
    {
        speed = 10;
        m_ridgid.gravityScale = 15;
        IsGaming = true;
    }

    void GameOver()
    {
        speed = 0;
        IsGaming = false;
    }

    void AirState()
    {
        transform.position += Vector3.up * Airspeed * Time.deltaTime;
        if (transform.position.y >= -12.5f || transform.position.y < -13.5f)
        {
            Airspeed = -Airspeed;
            print(Airspeed);
        }
    }

    private void Move(float MoveOffset)
    {
        if (IsGaming)
        {
            m_ridgid.AddForce(new Vector2(MoveOffset * 250, 0));
            m_ridgid.rotation = (MoveOffset * 20);
        }
    }

    void Update()
    {
        // Move R/L
        MoveInput = Input.GetAxis("Horizontal");
        //Attack
        IsAttack = Input.GetKeyDown(KeyCode.Mouse0);

        Fire(IsAttack);
    }

    private void FixedUpdate()
    {
        // MoveForward
        m_ridgid.MovePosition(new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime));
        // Move R/L
        Move(MoveInput);
        
    }

    public bool Hit()
    {
        if (PortectValue > 0)
        {
            return false;
        }
        else
        {
            cs_GameManager.Instance().GameState(2);
            print("GameOver");
            return true;   
        }
        //throw new System.NotImplementedException();
        
    }

    // --> Portacted Circle
    public void GetPortect()
    {
        if (PortectValue > 0)
        {
            PortectValue += 5;
            print(PortectValue);
        }
        else
        {
            PortectValue = 5;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Sword" && PortectValue > 0)
        {
            print(PortectValue);
            collision.GetComponent<Rigidbody2D>().gravityScale = -1;
            collision.GetComponent<SpriteRenderer>().flipY = true;
            collision.GetComponent<Rigidbody2D>().AddForce(transform.up * 3f, ForceMode2D.Impulse);
            PortectValue--;
        }
    }

    // --> Bullet
    public void GetBullet()
    {
        BulletNum++;
    }

    private void Fire(bool Click)
    {
        if (Click && BulletNum>0)
        {
            GameObject bullet = ObjectPool.Instance.GetObject(Bullet);
            Bullet.transform.position = new Vector3(transform.position.x, transform.position.y + 1.1f, transform.position.z);
            //Bullet.GetComponent<Rigidbody2D>().gravityScale = -1;
            Bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * 3f, ForceMode2D.Impulse);
            BulletNum--;
        }
    }
}
