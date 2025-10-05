

using UnityEngine;

public class EnemySpawner : Spawner
{
    public int spawnCount;
    public float spawnInterval; // in seconds
    private float timeSinceLastSpawn;
    private int spawnedEnemies;
    public EnemySpawner()
    {
        spawnCount = 3;
        spawnInterval = 5;
        timeSinceLastSpawn = 0f;
        spawnedEnemies = 0;
    }
    public override void Update(float deltaTime)
    {
        if (spawnedEnemies >= spawnCount)
            return;
        timeSinceLastSpawn += deltaTime;
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnEnemy();
            timeSinceLastSpawn = 0f;
            spawnedEnemies++;
        }
    }

    private void SpawnEnemy()
    {
        EnemyEntity enemy = EntityMgr.Instance.CreateEntity<EnemyEntity>();
        enemy.InitData(1002, Random.Range(-5, 5), 1); // Use the Random instance to generate a value
    }
}