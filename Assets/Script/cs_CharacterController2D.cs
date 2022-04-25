using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_CharacterController2D : MonoBehaviour,IHit
{
    Rigidbody2D m_ridgid;

    public float speed = 0;
    public bool IsGaming = false;
    private float MoveInput;

    GameObject ProtectCircle;
    Gyroscope GO;
    bool gyinfo;
    float gySensitivity = 1.5f;

    private void Awake()
    {
        m_ridgid = GetComponent<Rigidbody2D>();
        m_ridgid.gravityScale = 0;
        //IsPortect = false;
        ProtectCircle = transform.Find("ProtectCricle").gameObject;
    }

    private void OnDestroy()
    {
        
    }

    private void Start()
    {
        GameManager.Instance.whenGameStart += StartGame;
        GameManager.Instance.whenGameOver += GameOver;

#if UNITY_ANDROID || UNITY_IOS
        gyinfo = SystemInfo.supportsGyroscope;
        GO = Input.gyro;
        GO.enabled = true;
#endif
    }

    public void StartGame()
    {
        speed = 9;
        m_ridgid.gravityScale = 15;
        IsGaming = true;
    }

    void GameOver()
    {
        speed = 0;
        IsGaming = false;
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

        #if UNITY_STANDALONE_WIN || UNITY_EDITOR
        MoveInput = Input.GetAxis("Horizontal");
        #endif

        //MoveInput Touch.
        #if UNITY_ANDROID || UNITY_IOS || UNITY_EDITOR
        if (Input.touchCount > 0)
        {
            Vector3 touchPos = Input.GetTouch(0).deltaPosition.normalized;
            MoveInput = touchPos.x;
        }
        else
        {
            if (gyinfo && GO.enabled)
            {
                float x = GO.gravity.normalized.x;
                MoveInput = x * gySensitivity;
            }
        }
#endif
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
        if (ProtectCircle.activeSelf)
        {
            return false;
        }
        else
        {
            GameManager.Instance.GameState(2);
            return true;   
        }
    }

    // --> Portacted Circle
    public void GetPortect()
    {
        if (ProtectCircle.activeSelf)
        {
            ProtectCircle.SendMessage("AddPower");
        }
        else
        {
            ProtectCircle.SetActive(true);
        }
    }

   
}
