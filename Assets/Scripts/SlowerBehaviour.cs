using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowerBehaviour : MonoBehaviour
{
    [SerializeField] private float speedDecrease = 1f;
    [SerializeField] CameraShake shake;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            StartCoroutine(SlowPlayer(player));
        }
    }

    public IEnumerator SlowPlayer(PlayerMovement player)
    {
        StartCoroutine(shake.Shake(0.3f, 0.2f));
        player.DecreaseSpeed(speedDecrease);
        gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
