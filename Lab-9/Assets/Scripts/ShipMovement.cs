using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private int direction = 1;

    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * direction * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundary"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            direction *= -1; // flip direction
        }
    }

    // For save/load
    public float GetDirection() => direction;
    public void SetDirection(float dir) => direction = (dir >= 0f) ? 1 : -1;
}