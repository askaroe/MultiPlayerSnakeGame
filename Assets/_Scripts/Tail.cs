using UnityEngine;

public class Tail : MonoBehaviour
{
    public Transform networkOwner;
    public Transform followTransform;

    [SerializeField]
    private float _delayTime = 0.1f;
    [SerializeField]
    private float _distance = 0.3f;
    [SerializeField]
    private float _moveStep = 10f;

    private Vector3 _targetPosition;

    private void Update()
    {
        _targetPosition = followTransform.position - followTransform.forward * _distance;
        _targetPosition += (transform.position - _targetPosition) * _delayTime;
        _targetPosition.z = 0f;

        transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * _moveStep);
    }
}
