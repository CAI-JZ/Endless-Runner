using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_DistanceCheck : MonoBehaviour
{

    public static bool IsGround;
    private Vector3 CurrentPos;

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 CurrentPos = GetComponent<Transform>().position;
        //IsGround = CheckDistance();
    }
}
