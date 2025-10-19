using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyStats Stats { get; private set; }
    private float currentHP;

    public void SetStats(EnemyStats stats)
    {
        Stats = stats;
        currentHP = stats.HP;
        Debug.Log($"[Enemy] Stats applied: HP={stats.HP}, Speed={stats.Speed}, Score={stats.PointsAwarded}");
    }
    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        Debug.Log($"[Enemy] Took {damage} damage. Remaining HP: {currentHP}");

        if (currentHP <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"[Enemy] {name} died! Awarding {Stats.PointsAwarded} points.");
        // TODO: Add explosion, sound, or score logic here
        Destroy(gameObject);
    }
}
