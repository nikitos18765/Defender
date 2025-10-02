using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private Text _text;

    private void Update()
    {
        _text.text =LevelController.Level.ToString();
    }
}