using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 100;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private List<Weapon> _weapons;

    private int _currentHealth;
    private Weapon _currentWeapon;
    private Animator _animator;
    private int _currentWeaponNumber = 0;

    public int Money { get; private set; }

    public event UnityAction<int,int> OnHealthChanged;
    public event UnityAction<Sprite> ChangeSprite;

    private void Start()
    {
        ChangeWeapon(_weapons[_currentWeaponNumber]);
        _currentHealth = _health;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.Play("Shoot");
            _currentWeapon.Shoot(_shootPoint);
        }
    }

    private void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
        ChangeSprite?.Invoke(_currentWeapon.Icon);
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        OnHealthChanged?.Invoke(_currentHealth,_health);
    }

    public void AddMoney(int money)
    {
        Money += money;
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        _weapons.Add(weapon);
    }

    public void SetPreviousWeapon()
    {
        if (_currentWeaponNumber == _weapons.Count - 1)
            _currentWeaponNumber = 0;
        else
            _currentWeaponNumber++;

        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    public void SetNextWeapon()
    {
        if (_currentWeaponNumber == 0)
            _currentWeaponNumber = _weapons.Count - 1;
        else
            _currentWeaponNumber--;

        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }
}
