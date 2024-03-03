using Sounds;
using UnityEngine;
using UnityEngine.Audio;

public class JumpCollider : MonoBehaviour
{
    public float _force;
    [SerializeField] private AudioMixerGroup _audioMixerGroup;
    [SerializeField] private AudioClip _sound;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            SoundManager.Instance.PlaySound(_sound, _audioMixerGroup);
            collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.up) * _force, ForceMode.Impulse);
        }
    }
}
