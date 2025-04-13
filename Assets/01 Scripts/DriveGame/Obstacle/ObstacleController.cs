using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : M_MonoBehaviour
{
    protected void Update()
    {
        if(this.transform.position.x <= -11)
        {
            this.gameObject.SetActive(false);
        }
    }
}
