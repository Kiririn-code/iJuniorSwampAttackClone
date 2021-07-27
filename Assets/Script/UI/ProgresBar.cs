using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgresBar : Bar
{
    [SerializeField] private EnemySpawn _spawn;

    private void OnEnable()
    {
        _spawn.EnemyCountChanged += OnValueChanged;
        _slider.value = 0;
    }

    private void OnDisable()
    {
        _spawn.EnemyCountChanged -= OnValueChanged;
    }
}
