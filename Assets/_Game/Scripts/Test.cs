using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _damage = 100;

    private void Start()
    {
     _damage = GetCriticalChance();   
    }

    public int GetCriticalChance()
    {
        int randomValue = Random.Range(0,10);

        if (randomValue >= 8)
        {
            return _damage = 100;
        }
        else
        {
            return _damage = 20;
        }

    }
}