using System;

[Serializable]
public class Progress
{
    public int Level;
    public int[] LevelState;
    public float SFXVolume;
    public float MusicVolume;
    public float MouseSensetivity;

    public Progress()
    {
        Level = 0;
        LevelState = new int[15];
        SFXVolume = 1f;
        MusicVolume = 1f;
        MouseSensetivity = 3f;
    }
}
