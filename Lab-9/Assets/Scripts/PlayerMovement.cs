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

        // Player can't move past -12 or 12
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

        public void SaveData(GameData data) // Saves players position
    {
        Vector3 p = transform.position;
        data.playerX = p.x;
        data.playerY = p.y;
        data.playerZ = p.z;
    }

    public void LoadData(GameData data) // Loads players position
    {
        transform.position = new Vector3(data.playerX, data.playerY, data.playerZ);
    }
}