using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_CharacterController2D : MonoBehaviour
{
    Rigidbody2D m_ridgid;

    private float speed = 0;
    private bool IsBournd = false;
    private bool IsGaming = false;
    private float MoveInput;
    private float Airspeed = -1.5f;
    

    private void Awake()
    {
        m_ridgid = GetComponent<Rigidbody2D>();
        m_ridgid.gravityScale = 0;
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
        Debug.LogWarning("GameOver");
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            IsBournd = true;
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
    
    }

    private void FixedUpdate()
    {
        // MoveForward
        m_ridgid.MovePosition(new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime));
        // Move R/L
        Move(MoveInput);
    }
}
