using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectableBehaviour : MonoBehaviour
{
    [SerializeField] private float speedBonus = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            player.IncreaseSpeed(speedBonus);

            CanvasController.instance.UpdateScore((int)speedBonus);

            Destroy(gameObject);
        }
    }
}
