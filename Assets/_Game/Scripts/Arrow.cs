using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private int _damage = 1;
    [SerializeField] private float _lifeTime = 2f;

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
            enemy.TakeDamage(_damage);

        Destroy(gameObject);
    }

    private void Update()
    {
        transform.position += transform.up * _speed * Time.deltaTime;
    }
}