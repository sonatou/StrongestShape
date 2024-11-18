using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillerEnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private float patrolSpeed = 2.0f;
    [SerializeField] private float waitTimeAtPoint = 1.0f;

    private int currentPointIndex = 0;
    private bool waiting = false;

    [SerializeField] private CameraShake cameraShake;

    private void Update()
    {
        Patrol();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(KillPlayer(other));
        }
    }

    public IEnumerator KillPlayer(Collider player)
    {
        StartCoroutine(cameraShake.Shake(0.3f, 0.3f));
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        Destroy(player.gameObject);
        //SceneManager.LoadScene(0);

        CanvasController.instance.PlayerLoss();
    }

    private void Patrol()
    {
        if (patrolPoints.Length == 0 || waiting) return;

        Transform targetPoint = patrolPoints[currentPointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, patrolSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            StartCoroutine(WaitAtPoint());
        }
    }

    private IEnumerator WaitAtPoint()
    {
        waiting = true;

        yield return new WaitForSeconds(waitTimeAtPoint);

        currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;

        waiting = false;
    }
}
