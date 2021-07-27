using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{

    [SerializeField] private int _reward;
    [SerializeField] private int _health;

    private Player _target;
    private int _currentHealth;
    public int Reward => _reward;
    public Player Target => _target;
    public event UnityAction<Enemy> Died;

    private void Start()
    {
        _currentHealth = _health;
    }
    public void Init(Player player)
    {
        _target = player;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
            Die();
    }
    private void Die()
    {
        Destroy(gameObject);
        Died?.Invoke(this);
    }
}
