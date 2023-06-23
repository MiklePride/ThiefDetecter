using UnityEngine;

public class PenetrationTrigger : MonoBehaviour
{
    [SerializeField] private float _duration;

    private AudioSource _alarmAudio;
    private bool _isPlaying = false;
    private float _minimumVolume;
    private float _maximumVolume = 1.0f;

    private void Start()
    {
        _alarmAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_isPlaying)
        {
            _alarmAudio.volume += Mathf.MoveTowards(_minimumVolume, _maximumVolume, _duration * Time.deltaTime);
        }
        else
        {
            _alarmAudio.volume += Mathf.MoveTowards(_minimumVolume, _maximumVolume, -_duration * Time.deltaTime);

            if (_alarmAudio.volume <= _minimumVolume)
                _alarmAudio.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Thief>(out Thief thief) && _isPlaying == false)
        {
            _alarmAudio.Play();
            _isPlaying = true;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.TryGetComponent<Thief>(out Thief thief) && _isPlaying == true)
        {
            _isPlaying = false;
        }
    }
}
