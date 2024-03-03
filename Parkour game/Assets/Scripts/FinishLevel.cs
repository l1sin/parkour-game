using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;
    private void Update()
    {
        transform.Rotate(_rotation * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            LevelController.Instance.TriggerWin();
        }
    }
}
