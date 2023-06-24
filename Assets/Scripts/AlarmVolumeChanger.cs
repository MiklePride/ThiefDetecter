using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AlarmVolumeChanger : MonoBehaviour
{
    private AudioSource _alarmAudio;
    private float _minVolume = 0f;
    private float _maxVolume = 1.0f;
    private float _duration = 0.3f;

    private void Awake()
    {
        _alarmAudio = GetComponent<AudioSource>();
    }

    public void TurnOnAlarm()
    {
        StartCoroutine(IncreaseVolumeToMax());
    }

    public void TurnOffAlarm()
    {
        StartCoroutine(DecreaseVolumeToMin());
    }

    private IEnumerator IncreaseVolumeToMax()
    {
        _alarmAudio.Play();

        while (_alarmAudio.volume < _maxVolume) 
        {
            _alarmAudio.volume = Mathf.MoveTowards(_alarmAudio.volume, _maxVolume, _duration * Time.deltaTime);

            yield return null;
        }
    }

    private IEnumerator DecreaseVolumeToMin()
    {
        while (_alarmAudio.volume > _minVolume) 
        {
            _alarmAudio.volume = Mathf.MoveTowards(_alarmAudio.volume, _minVolume, _duration * Time.deltaTime);

            yield return null;
        }
    }
}
