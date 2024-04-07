using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<PlayerController>().Die();
        }
    }
}
