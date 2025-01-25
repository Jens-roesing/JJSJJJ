using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    [SerializeField] private AudioSource _menuSource;
    [SerializeField] private AudioSource _ingameSource;
    [SerializeField] private AudioClip[] audioClips;
    private MusicIntensity _musicIntensityState;
    private bool _menuOpen;

    private enum MusicIntensity
    {
        Normal = 0,
        Heavy = 1,
        Extreme = 2,
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        PlayMenuMusic();
        GameManager.GetInstance().NewGameState.AddListener(HandleGameState);
    }

    private void HandleGameState(GameManager.GameState state)
    {
        if (state == GameManager.GameState.Pause)
            PlayMenuMusic();

        if (state == GameManager.GameState.Playing)
            PlayIngameMusic();
    }

    private void PlayMenuMusic()
    {
        if (_menuOpen == false)
            return;

        _menuOpen = true;
        _ingameSource.Pause();

        _menuSource.Play();
    }

    private void PlayIngameMusic()
    {
        _menuOpen = false;
        _menuSource.Pause();

        _ingameSource.clip = audioClips[(int)_musicIntensityState];
        _ingameSource.Play();
    }

    public static AudioManager GetInstance()
    {
        return instance;
    }
}
