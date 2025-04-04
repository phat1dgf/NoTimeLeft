using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class VehicleController : M_MonoBehaviour
{
    protected override void Reset()
    {
        base.Reset();
        this.transform.localPosition = new Vector3(-7,0,0);
    }
}
