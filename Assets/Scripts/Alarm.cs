using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    private AudioSource _alarmAudio;
    private Coroutine _changeValue;
    private float _targetVolume;
    private float _duration = 0.3f;

    private void Awake()
    {
        _alarmAudio = GetComponent<AudioSource>();
    }

    public void TurnOnAlarm()
    {
        float maxValue = 1f;
        _targetVolume = maxValue;

        _alarmAudio.Play();

        if (_changeValue != null)
            StopCoroutine(_changeValue);

        _changeValue = StartCoroutine(ChangeValue(_targetVolume));
    }

    public void TurnOffAlarm()
    {
        float minValue = 0f;
        _targetVolume = minValue;

        StopCoroutine(_changeValue);
        _changeValue = StartCoroutine(ChangeValue(_targetVolume));
    }

    private IEnumerator ChangeValue(float targetVolume)
    {
        while (_alarmAudio.volume != targetVolume)
        {
            _alarmAudio.volume = Mathf.MoveTowards(_alarmAudio.volume, targetVolume, _duration * Time.deltaTime);

            yield return null;
        }
    }
}
