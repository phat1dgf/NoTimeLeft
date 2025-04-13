using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimatorController : M_MonoBehaviour
{
    [SerializeField] private Animator _animator;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadAnimator();
    }

    private void LoadAnimator()
    {
        if (_animator != null) return;
        this._animator = this.GetComponent<Animator>();
    }
    
}
