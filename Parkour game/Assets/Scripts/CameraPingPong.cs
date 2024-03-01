using UnityEngine;

public class CameraPingPong : MonoBehaviour
{
    [SerializeField] private Transform[] _pos;
    [SerializeField] private float _speed;

    private void Update()
    {
        float i = Mathf.PingPong(Time.time * _speed, 1);
        transform.rotation = Quaternion.Lerp(_pos[0].rotation, _pos[1].rotation, i);
    }
}
