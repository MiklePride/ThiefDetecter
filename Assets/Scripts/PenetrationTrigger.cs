using UnityEngine;

[RequireComponent (typeof(AlarmVolumeChanger))]

public class PenetrationTrigger : MonoBehaviour
{
    private AlarmVolumeChanger _volumeChanger;

    private void Awake()
    {
        _volumeChanger = GetComponent<AlarmVolumeChanger>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Thief>(out Thief thief))
        {
            _volumeChanger.TurnOnAlarm();
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.TryGetComponent<Thief>(out Thief thief))
        {
            _volumeChanger.TurnOffAlarm();
        }
    }
}
