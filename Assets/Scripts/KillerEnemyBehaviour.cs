using System.Collections;
using UnityEngine;

public class KillerEnemyBehaviour : MonoBehaviour
{
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private float patrolSpeed = 2.0f;
    [SerializeField] private float waitTimeAtPoint = 1.0f;

    private int _currentPointIndex;
    private bool _waiting;

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

        CanvasController.Instance.PlayerLoss();
    }

    private void Patrol()
    {
        if (patrolPoints.Length == 0 || _waiting) return;

        Transform targetPoint = patrolPoints[_currentPointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, patrolSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            StartCoroutine(WaitAtPoint());
        }
    }

    private IEnumerator WaitAtPoint()
    {
        _waiting = true;

        yield return new WaitForSeconds(waitTimeAtPoint);

        _currentPointIndex = (_currentPointIndex + 1) % patrolPoints.Length;

        _waiting = false;
    }
}
