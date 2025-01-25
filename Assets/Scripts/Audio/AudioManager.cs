using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    [SerializeField] private AudioSource _menuSource;
    [SerializeField] private AudioSource _ingameSource;
    [SerializeField] private AudioClip[] audioClips;
    private MusicIntensity _musicIntensityState;
    private bool _menuOpen;

    public enum MusicIntensity
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
        _ingameSource.Pause();

        if (!_menuSource.isPlaying)
            _menuSource.Play();
    }

    private void PlayIngameMusic()
    {
        _menuOpen = false;
        _menuSource.Pause();

        _ingameSource.clip = audioClips[(int)_musicIntensityState];

        if (!_ingameSource.isPlaying)
            _ingameSource.Play();
    }

    public void SetMusicIntensity(MusicIntensity musicIntensity)
    {
        _musicIntensityState = musicIntensity;
    }

    public static AudioManager GetInstance()
    {
        return instance;
    }
}
