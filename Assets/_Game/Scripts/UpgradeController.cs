using UnityEngine;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour
{
    private const string HealthGrade = "healthGrade";

    [SerializeField] private int _healthGradePrice = 2;
    [SerializeField] private Corn _corn;
    [SerializeField] private Text _text;

    private int _healthGrade;

    private void Awake()
    {
        _healthGrade = PlayerPrefs.GetInt(HealthGrade, 0);
    }
    private void Update()
    {
        _text.text = _healthGradePrice.ToString();
    }
    public void OnClickUpgradeHealth()
    {
        if (_corn.TrySpentCrystals(_healthGradePrice))
        {
            _healthGrade++;
            PlayerPrefs.SetInt(HealthGrade, _healthGrade);
            PlayerPrefs.Save();
            _corn.RecalculateHealth();
        }
    }
}