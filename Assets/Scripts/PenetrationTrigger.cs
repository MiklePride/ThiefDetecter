using UnityEngine;
using UnityEngine.Events;

public class PenetrationTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _triggeredEnter;
    [SerializeField] private UnityEvent _triggeredExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Thief>(out Thief thief))
        {
            _triggeredEnter.Invoke();
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.TryGetComponent<Thief>(out Thief thief))
        {
            _triggeredExit.Invoke();
        }
    }
}
