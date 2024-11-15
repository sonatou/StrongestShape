using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowerBehaviour : MonoBehaviour
{
    [SerializeField] private float speedDecrease = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerMovement player = other.GetComponent<playerMovement>();
            player.DecreaseSpeed(speedDecrease);
            Destroy(gameObject);
        }
    }
}
