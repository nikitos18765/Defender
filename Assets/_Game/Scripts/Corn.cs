using UnityEngine;

public class Corn : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [field: SerializeField] public int StartHealth { get; private set; } = 10;
    [field: SerializeField] public int HealthPerUpgrade { get; private set; } = 2;

    public int Health { get; private set; }
    public int Crystals { get; private set; }

    private void Awake()
    {
        LoadGameData();
    }

    public void RecalculateHealth()
    {
        int healthGrade = PlayerPrefs.GetInt("healthGrade", 0);
        Health = StartHealth + healthGrade * HealthPerUpgrade;
    }

    public void TakeDamage()
    {
        Health -= _damage;
    }

    public void AddCrystals(int value)
    {
        Crystals += value;
        SaveController.SaveCrystals(Crystals);
    }

    public bool TrySpentCrystals(int value)
    {
        if (Crystals < value)
        {
            return false;
        }

        Crystals -= value;
        SaveController.SaveCrystals(Crystals);
        return true;
    }

    private void LoadGameData()
    {
        int healthGrade = PlayerPrefs.GetInt("healthGrade", 0);
        Health = StartHealth + (healthGrade * HealthPerUpgrade);
        Crystals = PlayerPrefs.GetInt("crystals", 0);
    }

}