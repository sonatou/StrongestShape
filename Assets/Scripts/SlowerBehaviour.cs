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
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            player.DecreaseSpeed(speedDecrease);
            Destroy(gameObject);
        }
    }
}
