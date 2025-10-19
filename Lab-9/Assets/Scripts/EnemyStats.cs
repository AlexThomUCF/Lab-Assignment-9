using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats
{
    private EnemyStats() { }

    private float hp = 10f;
    private float speed = 5f;
    private int pointsAwared = 100;

    // ?? Public read-only accessors
    public float HP => hp;
    public float Speed => speed;
    public int PointsAwarded => pointsAwared;


    public class Builder
    {
        private readonly EnemyStats enemyStats = new EnemyStats();
        public Builder WithHP(float _hp)
        {
            enemyStats.hp = _hp;
            return this;
        }

        public Builder WithSpeed(float _speed)
        {
            enemyStats.speed = _speed;
            return this;
        }

        public Builder WithScore(int _score)
        {
            enemyStats.pointsAwared = _score;
            return this;
        }

        public EnemyStats Build()
        {
            return enemyStats;
        }

    }
}
