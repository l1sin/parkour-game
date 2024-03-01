using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private LevelButton[] _levelButtons;
    [SerializeField] private Color[] _colors;
    [SerializeField] private SliderController[] _sliders;

    private void Start()
    {
        PauseManager.SetPause(false);
        LoadLevels();
        LoadSliders();
#if UNITY_EDITOR || UNITY_STANDALONE
        Debug.Log("Ready");
#elif UNITY_WEBGL
        Yandex.FullScreenAd();
        Yandex.GameReady();
#endif
    }

    private void LoadLevels()
    {
        for (int i = 0; i < _levelButtons.Length; i++)
        {
            int levelState = SaveManager.Instance.CurrentProgress.LevelState[i];
            if (levelState == 0) _levelButtons[i].SetInteractable(false);
            _levelButtons[i].SetColor(_colors[levelState]);
        }
        int level = SaveManager.Instance.CurrentProgress.Level;
        if (level >= _levelButtons.Length) return;
        _levelButtons[level].SetInteractable(true);
    }

    public void Save()
    {
        SaveManager.Instance.SaveData(SaveManager.Instance.CurrentProgress);
    }
    public void LoadSliders()
    {
        foreach (SliderController s in _sliders)
        {
            s.LoadSlider();
        }
    }

}
