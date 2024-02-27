using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCollider : MonoBehaviour
{
    public float _force;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.up) * _force, ForceMode.Impulse);
        }
    }
}
