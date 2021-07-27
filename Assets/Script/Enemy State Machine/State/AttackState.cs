using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackState : State
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private float _lastAttackTime;
    private Animator _animator;

    private void Start()
    {
            _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (_lastAttackTime >= _delay)
        {
            Attack(Target);
            _lastAttackTime = 0;
        }
        _lastAttackTime += Time.deltaTime;
    }

    private void Attack(Player target)
    {
        _animator.Play("Attack");
        target.ApplyDamage(_damage);
    }

    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}
