using UnityEngine;

public class DeathCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            //other.GetComponent<CharacterHealth>().Die();
            Debug.Log("Death");
        }
    }
}
