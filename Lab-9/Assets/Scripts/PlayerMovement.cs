using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    private float minX = -12f;
    private float maxX = 12f;

    void Update()
    {
        float moveInput = 0f;

        if (Input.GetKey(KeyCode.A))
            moveInput = -1f;
        else if (Input.GetKey(KeyCode.D))
            moveInput = 1f;

        Vector3 move = new Vector3(moveInput * moveSpeed * Time.deltaTime, 0f, 0f);
        transform.position += move;

        // clamp position so player can't move past -12 or 12
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
