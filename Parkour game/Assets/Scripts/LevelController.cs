using Sounds;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance;

    [SerializeField] private GameObject _winMenu;
    [SerializeField] private GameObject _loseMenu;
    [SerializeField] private SFPSC_FPSCamera _camera;

    [SerializeField] private AudioMixerGroup _audioMixerGroup;
    [SerializeField] private AudioClip _winSound;
    [SerializeField] private AudioClip _loseSound;
    public int Level;

    private void OnEnable()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        Level = SceneManager.GetActiveScene().buildIndex;
        PauseManager.SetPause(false);
        CursorHelper.LockAndHideCursor();
        _camera.sensitivity = SaveManager.Instance.CurrentProgress.MouseSensetivity;
    }

    public void TriggerWin()
    {
        SoundManager.Instance.PlaySound(_winSound, _audioMixerGroup);
        _camera.Locked = true;
        CursorHelper.ShowCursor();
        PauseManager.SetPause(true);
        _winMenu.SetActive(true);    
        Save();
    }

    public void TriggerLose()
    {
        SoundManager.Instance.PlaySound(_loseSound, _audioMixerGroup);
        _camera.Locked = true;
        CursorHelper.ShowCursor();
        PauseManager.SetPause(true);
        _loseMenu.SetActive(true);
    }

    public void LoadMenu()
    {
        Debug.Log("Menu");
        SceneManager.LoadScene(SaveManager.Instance.MainMenuSceneIndex);
    }

    public void Save()
    {
        if (SaveManager.Instance.CurrentProgress.Level < Level)
        {
            SaveManager.Instance.CurrentProgress.Level = Level;
        }
        SaveManager.Instance.CurrentProgress.LevelState[Level - 1] = 1;
        SaveManager.Instance.SaveData(SaveManager.Instance.CurrentProgress);
    }

}
