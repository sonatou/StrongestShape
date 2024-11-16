using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rollSpeed = 2.0f;
    public float gridSize = 1.0f;
    private bool isRolling = false;

    private void Update()
    {
        if (isRolling) return;

        if (Input.GetKeyDown(KeyCode.W)) Roll(Vector3.forward);
        else if (Input.GetKeyDown(KeyCode.S)) Roll(Vector3.back);
        else if (Input.GetKeyDown(KeyCode.A)) Roll(Vector3.left);
        else if (Input.GetKeyDown(KeyCode.D)) Roll(Vector3.right);
    }

    void Roll(Vector3 direction)
    {
        Vector3 anchor = transform.position + (Vector3.down + direction) * (gridSize / 2);
        Vector3 axis = Vector3.Cross(Vector3.up, direction);

        StartCoroutine(RollCoroutine(anchor, axis));
    }

    IEnumerator RollCoroutine(Vector3 anchor, Vector3 axis)
    {
        isRolling = true;

        for (int i = 0; i < 90; i += (int)rollSpeed)
        {
            transform.RotateAround(anchor, axis, rollSpeed);
            yield return null;
        }

        transform.position = new Vector3(
            Mathf.Round(transform.position.x / gridSize) * gridSize,
            transform.position.y,
            Mathf.Round(transform.position.z / gridSize) * gridSize
        );

        isRolling = false;
    }

    public void IncreaseSpeed(float speedIncrement)
    {
        rollSpeed += speedIncrement;
        Debug.Log("Nova velocidade de rotação: " + rollSpeed);
    }

    public void DecreaseSpeed(float speedDecrement)
    {
        rollSpeed -= speedDecrement;
        Debug.Log("Nova velocidade de rotação: " + rollSpeed);
    }
}
