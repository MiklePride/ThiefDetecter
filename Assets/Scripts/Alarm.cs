using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Alarm : MonoBehaviour
{
    private AudioSource _alarmAudio;
    private float _targetVolume;
    private float _duration = 0.3f;

    private void Awake()
    {
        _alarmAudio = GetComponent<AudioSource>();
    }

    public void TurnOnAlarm()
    {
        _targetVolume = 1f;

        StartCoroutine(ChangeValue(_targetVolume));
    }

    public void TurnOffAlarm()
    {
        _targetVolume = 0f;

        StartCoroutine(ChangeValue(_targetVolume));
    }

    private IEnumerator ChangeValue(float targetVolume)
    {
        _alarmAudio.Play();

        while (_alarmAudio.volume != targetVolume)
        {
            _alarmAudio.volume = Mathf.MoveTowards(_alarmAudio.volume, targetVolume, _duration * Time.deltaTime);

            yield return null;
        }
    }
}
