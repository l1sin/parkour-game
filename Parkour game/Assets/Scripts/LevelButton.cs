using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _image;
    [SerializeField] private int _level;
    private void OnClick()
    {
        SceneManager.LoadScene(_level);
    }

    public void SetColor(Color color)
    {
        _image.color = color;
    }

    public void SetInteractable(bool state)
    {
        _button.interactable = state;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }
}
