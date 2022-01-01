using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Campfire : MonoBehaviour
{
    [SerializeField] private Slider _bar;
    [SerializeField] private float _burningSpeed;

    private float _fuelCount = 100;
    public event UnityAction GameOver;

    private void Update()
    {
        _fuelCount -= _burningSpeed * Time.deltaTime;
        _bar.value = _fuelCount / 100;

        if (_fuelCount < 0)
            GameOver?.Invoke();
    }
}
