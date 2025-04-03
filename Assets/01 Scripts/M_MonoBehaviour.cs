using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_MonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponents();
    }
    protected virtual void Reset()
    {
        this.LoadComponents();
    }
    protected virtual void LoadComponents()
    {

    }
}
