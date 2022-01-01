using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DayLightCycle : MonoBehaviour
{
    [SerializeField] private Slider _clock;
    [SerializeField] private Image _clockBackground;
    [SerializeField] private Image _clockForeground;
    [SerializeField] private float _dayLength;
    [SerializeField] private Color _dayClockColor;
    [SerializeField] private Color _nightClockColor;

    public event UnityAction SunIsRisingUp;
    public event UnityAction SunIsGoingDown;

    private float _currentTime;
    private bool _isNight;

    private void Start()
    {
        _clockBackground.color = _nightClockColor;
        _clockForeground.color = _dayClockColor;
        _isNight = false;
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        
        if(_currentTime > _dayLength)
        {
            SwitchDayAndNight();
        }
        
        _clock.value = _currentTime / _dayLength;
    }

    private void SwitchDayAndNight()
    {
        _currentTime = 0;
        _isNight = !_isNight;

        if (_isNight == false)
        {
            _clockBackground.color = _nightClockColor;
            _clockForeground.color = _dayClockColor;
        }
        else
        {
            _clockBackground.color = _dayClockColor;
            _clockForeground.color = _nightClockColor;
        }
    }
}
