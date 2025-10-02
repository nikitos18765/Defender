using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Corn _cornTarget;
    [SerializeField] private Transform _bottomBorder;
    [SerializeField] private Transform _topBorder;
    [SerializeField] private float _minInterval = 1f;
    [SerializeField] private float _maxInterval = 3f;
    [SerializeField] private int _baseSpawnCount = 1;

    private float _spawnTimer;

    public int SpawnCounter { get; private set; }

    private void Start()
    {
        SpawnCounter = _baseSpawnCount + LevelController.Level;
    }

    private void Update()
    {
        if (SpawnCounter == 0) return;

        _spawnTimer -= Time.deltaTime;

        if (_spawnTimer <= 0)
        {
            SpawnEnemy();
        }
    }

    public void InitSpawner(int level)
    {
        SpawnCounter = _baseSpawnCount + level;
    }

    private void SpawnEnemy()
    {
        SpawnCounter--;
        _spawnTimer = Random.Range(_minInterval, _maxInterval);
        float randomY = Random.Range(_topBorder.position.y, _bottomBorder.position.y);

        Vector2 spawnPosition = new(transform.position.x, randomY);

        Enemy enemy = Instantiate(_enemy, spawnPosition, Quaternion.identity);
        enemy.SetTarget(_cornTarget);
    }
}