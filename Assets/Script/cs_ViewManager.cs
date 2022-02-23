using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cs_ViewManager : MonoBehaviour
{
    public GameObject[] Targets;
    public Camera Camera;

    private bool IsVisible(Camera cam, GameObject target)
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(cam);
        var point = target.transform.position;

        foreach (var plane in planes)
        {
            if (plane.GetDistanceToPoint(point) > 0)
            {
                return false;
            }           
        }
        return true;
    }



    // Update is called once per frame
    void Update()
    {
        foreach (GameObject tar in Targets)
        {
            if (IsVisible(Camera, tar))
            {
                tar.SendMessage("Attack");
            }
        }
       
    }
}
