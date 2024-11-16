using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillerEnemyBehaviour : MonoBehaviour
{
    public Transform[] patrolPoints; // Lista de pontos para patrulha
    public float patrolSpeed = 2.0f; // Velocidade de patrulha
    public float waitTimeAtPoint = 1.0f; // Tempo de espera em cada ponto

    private int currentPointIndex = 0; // Índice do ponto atual na patrulha
    private bool waiting = false; // Controla se o inimigo está esperando

    private void Update()
    {
        Patrol();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            SceneManager.LoadScene(0);
        }
    }

    private void Patrol()
    {
        if (patrolPoints.Length == 0 || waiting) return;

        // Move o inimigo em direção ao ponto atual
        Transform targetPoint = patrolPoints[currentPointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, patrolSpeed * Time.deltaTime);

        // Verifica se chegou ao ponto atual
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            StartCoroutine(WaitAtPoint());
        }
    }

    private IEnumerator WaitAtPoint()
    {
        waiting = true;

        // Aguarda o tempo definido antes de ir para o próximo ponto
        yield return new WaitForSeconds(waitTimeAtPoint);

        // Atualiza para o próximo ponto da patrulha
        currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;

        waiting = false;
    }
}
