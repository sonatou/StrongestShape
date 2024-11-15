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
            playerMovement player = other.GetComponent<playerMovement>();
            player.IncreaseSpeed(speedBonus);
            Destroy(gameObject);
        }
    }
}
