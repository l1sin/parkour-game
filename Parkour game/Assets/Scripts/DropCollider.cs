using UnityEngine;

public class DropCollider : MonoBehaviour
{
    public float DropTime;
    public float DestroyTime;
    [SerializeField] private Rigidbody rb;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Invoke("Drop", DropTime);
        }
    }

    private void Drop()
    {
        rb.isKinematic = false;
        Destroy(gameObject, DestroyTime);
    }
}
