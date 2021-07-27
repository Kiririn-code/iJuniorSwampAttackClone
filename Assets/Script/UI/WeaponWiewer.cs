using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponWiewer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Image _image;

    private void OnEnable()
    {
        _player.ChangeSprite += OnImageChanged;
    }

    private void OnDisable()
    {
        _player.ChangeSprite -= OnImageChanged;
    }

    private void OnImageChanged(Sprite sprite)
    {
        _image.sprite = sprite;
    }
}
