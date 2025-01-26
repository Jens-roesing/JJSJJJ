using System.Collections;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    [SerializeField] private AudioSource _menuSource;
    [SerializeField] private AudioSource _ingameSource;
    [SerializeField] private AudioSource _effectSounds;
    [SerializeField] private AudioSource _bubbleEffects;
    [SerializeField] private AudioClip[] audioClips;
    [SerializeField] private AudioClip[] _bubbleClips;
    [SerializeField] private float bubbleDelay = 0.1f;
    private MusicIntensity _musicIntensityState;
    private bool _menuOpen;
    private int testDing;

    [SerializeField] private AudioSource _krakenSource;
    [SerializeField] private AudioClip[] _krakendmgSounds;
    [SerializeField] private AudioSource _krakenDeath;

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            testDing++;
            PlaySelectSound(testDing);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(PlayBubblePopSounds(7));
        }

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

    public void PlaySelectSound(int index)
    {
        _effectSounds.pitch = 1 + ((float)index / 10);
        _effectSounds.Play();
    }

    public IEnumerator PlayBubblePopSounds(int bubbleCount)
    {
        yield break;
        int soundIndex = 0;
        for (int i = 0; i < bubbleCount; i++)
        {
            yield return new WaitForSeconds(bubbleDelay);
            if (soundIndex < _bubbleClips.Length - 1)
                soundIndex++;
            else
                soundIndex = 0;

            Debug.Log("Sound: " + soundIndex);
            _bubbleEffects.PlayOneShot(_bubbleClips[soundIndex]);
        }

        yield return null;
    }

    public void PlayKrakenDMGSound()
    {
        _krakenSource.clip = _krakendmgSounds[Random.Range(0, _krakendmgSounds.Length)];
        _krakenSource.Play();
    }

    public void PlayKrakenDeathSound()
    {
        _krakenDeath.Play();
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
