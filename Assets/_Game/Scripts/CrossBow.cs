using System.Collections;
using UnityEngine;

public class CrossBow : MonoBehaviour
{
    [SerializeField] private GameObject _arrow;
    [SerializeField] private float _delay = 0.75f;

    private bool _isCooldown = false;

    private void Update()
    {
        TransformRotation();
        HandleShoot();
    }

    private void TransformRotation()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDirection = mousePosition - (Vector2)transform.position;
        transform.up = lookDirection;
    }

    private void HandleShoot()
    {
        if (_isCooldown || !Input.GetMouseButtonDown(0)) return;

        Shoot();
        StartCoroutine(DealyShoot());
    }

    private void Shoot()
    {
        Instantiate(_arrow, transform.position, transform.rotation);
    }

    private IEnumerator DealyShoot()
    {
        _isCooldown = true;
        yield return new WaitForSeconds(_delay);
        _isCooldown = false;
    }
}