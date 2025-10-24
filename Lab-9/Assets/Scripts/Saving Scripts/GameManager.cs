using System.Collections.Generic;
using UnityEngine;

public class GameManager_SaveLoad : MonoBehaviour
{
    [Header("References")]
    public TransformSaver saver;
    public GameObject playerObject;
    public EnemySpawner spawner;
    public List<GameObject> ships;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            SaveGame();

        if (Input.GetKeyDown(KeyCode.L))
            LoadGame();
    }

    public void SaveGame()
    {
        GameData data = new GameData();

        // Player
        if (playerObject != null)
        {
            Vector3 p = playerObject.transform.position;
            data.playerX = p.x;
            data.playerY = p.y;
            data.playerZ = p.z;
        }

        // Score
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        data.score = (scoreManager != null) ? scoreManager.GetCurrentScore() : 0;

        // Active enemies
        data.enemyMovables.Clear();
        Enemy[] activeEnemies = FindObjectsOfType<Enemy>();
        foreach (var e in activeEnemies)
        {
            MovableData m = new MovableData();
            m.position = e.transform.position;

            ShipMovement shipMove = e.GetComponent<ShipMovement>();
            m.direction = shipMove != null ? shipMove.GetDirection() : 1f;

            data.enemyMovables.Add(m);
        }

        // Active ships
        foreach (var ship in ships)
        {
            if (ship != null)
            {
                MovableData m = new MovableData();
                m.position = ship.transform.position;
                ShipMovement shipMove = ship.GetComponent<ShipMovement>();
                m.direction = shipMove != null ? shipMove.GetDirection() : 1f;
                data.enemyMovables.Add(m);
            }
        }

        saver.Save(data);
        Debug.Log("Game Saved! Score: " + data.score);
    }

    public void LoadGame()
    {
        // Load the saved data
        GameData data = saver.Load();

        // Update ScoreManager so UI refreshes
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            int currentScore = scoreManager.GetCurrentScore();
            int difference = data.score - currentScore;
            if (difference != 0)
                scoreManager.AddScore(difference);
        }

        // Player
        if (playerObject != null)
            playerObject.transform.position = new Vector3(data.playerX, data.playerY, data.playerZ);

        // Restore enemies/ships
        ApplyEnemyPositions(data.enemyMovables);

        Debug.Log("Game Loaded! Score: " + data.score);
    }

    private void ApplyEnemyPositions(List<MovableData> savedMovables)
    {
        if (savedMovables == null)
            savedMovables = new List<MovableData>();

        List<Enemy> currentEnemies = new List<Enemy>(FindObjectsOfType<Enemy>());
        int i = 0;

        // Move existing enemies
        for (; i < savedMovables.Count && i < currentEnemies.Count; i++)
        {
            if (currentEnemies[i] != null)
            {
                currentEnemies[i].transform.position = savedMovables[i].position;
                ShipMovement shipMove = currentEnemies[i].GetComponent<ShipMovement>();
                if (shipMove != null)
                    shipMove.SetDirection(savedMovables[i].direction);

                currentEnemies[i].gameObject.SetActive(true);
            }
        }

        // Spawn missing enemies
        for (; i < savedMovables.Count; i++)
        {
            if (spawner != null)
            {
                GameObject[] prefabs = Resources.LoadAll<GameObject>("EnemyPrefabs");
                if (prefabs.Length > 0)
                {
                    int index = Random.Range(0, prefabs.Length);
                    GameObject newEnemy = Instantiate(prefabs[index], savedMovables[i].position, Quaternion.identity);
                    newEnemy.transform.SetParent(spawner.transform);

                    ShipMovement shipMove = newEnemy.GetComponent<ShipMovement>();
                    if (shipMove != null)
                        shipMove.SetDirection(savedMovables[i].direction);
                }
            }
        }

        // Deactivate extra enemies
        for (int j = savedMovables.Count; j < currentEnemies.Count; j++)
        {
            if (currentEnemies[j] != null)
                currentEnemies[j].gameObject.SetActive(false);
        }
    }
}