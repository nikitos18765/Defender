using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _baseSpeed = 2.5f;
    [SerializeField] private float _speedPerLevel = 0.5f;
    [SerializeField] private float _fightInterval = 1f;
    [SerializeField] private int _rewardForKill = 2;
    [SerializeField] private int _health = 2;

    public static List<Enemy> ActiveEnemies = new List<Enemy>();

    private float _currentSpeed;
    private float _borderPositionX;
    private Coroutine _coroutine;
    private Corn _target;
    private bool _isMoving = true;

    private void Start()
    {
        _currentSpeed = _baseSpeed + _speedPerLevel;
    }

    private void OnEnable()
    {
        ActiveEnemies.Add(this);
    }

    private void OnDisable()
    {
        ActiveEnemies.Remove(this);
    }

    private void Update()
    {
        if (_target == false) return;

        _isMoving = transform.position.x > _borderPositionX;

        if (_isMoving)
            Move();
        else if (_coroutine == null)
            _coroutine = StartCoroutine(DelayAttack());
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health == 0)
        {
            _target.AddCrystals(_rewardForKill);
            Destroy(gameObject);
        }
    }

    public void SetTarget(Corn corn)
    {
        _target = corn;
        _borderPositionX = corn.transform.position.x;
    }

    private IEnumerator DelayAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(_fightInterval);
            _target.TakeDamage();
        }
    }

    private void Move()
    {
        if (_coroutine != null)
        {
            StopCoroutine(DelayAttack());
            _coroutine = null;
        }

        transform.position += -transform.right * _currentSpeed * Time.deltaTime;
    }
}