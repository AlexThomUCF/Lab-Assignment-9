using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MovableData
{
    public Vector3 position;
    public float direction;
}

[Serializable]
public class GameData
{
    // Player position
    public float playerX;
    public float playerY;
    public float playerZ;

    // Enemies and ships positions + directions
    public List<MovableData> enemyMovables = new List<MovableData>();

    // Score
    public int score;
}
