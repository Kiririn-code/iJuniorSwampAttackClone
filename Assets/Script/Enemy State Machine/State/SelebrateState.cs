using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SelebrateState : State
{
    private Animator _animator;

    private void Start()
    {
        _animator.Play("Selebrate");
    }
    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}
