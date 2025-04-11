using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : M_MonoBehaviour
{
    [SerializeField] private float _speed;
    protected override void Reset()
    {
        base.Reset();

    }
    private void Update()
    {
        RoadLooping();
        RoadMoving();
    }

    private void RoadMoving()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;
    }


    private void RoadLooping()
    {
        if (this.transform.position.x <= -24)
        {
            this.transform.position = Vector3.zero;
        }
    }
}
