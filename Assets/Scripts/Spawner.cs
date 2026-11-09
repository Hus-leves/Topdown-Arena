using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] area;
    public GameObject[] enemies;
    public GameObject Player;

    public float spawnTimer = 0.2f;

    private float timer;
    private void Update()
    {
        if (timer <= 0f)
        {
            timer = spawnTimer;
            SpawnEnemy();
        }
        timer -= Time.deltaTime;
    }

    void SpawnEnemy()
    {
        int side = Random.Range(0, area.Length);
        int enemy = Random.Range(0, enemies.Length);
        BoxCollider2D box = area[side].GetComponent<BoxCollider2D>();
        float x = Random.Range(box.bounds.min.x, box.bounds.max.x);
        float y = Random.Range(box.bounds.min.y, box.bounds.max.y);
        
        Instantiate(enemies[enemy], new Vector2(x, y), Quaternion.identity);
    }
}
