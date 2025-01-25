using UnityEngine;
using UnityEngine.UI;

public class Logo : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private float _changeDelay = 0.2f;
    private float _timer;

    private Image _image;
    private int _currentSprite;

    void Awake()
    {
        _image = GetComponent<Image>();
    }


    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer < _changeDelay)
            return;

        _image.sprite = _sprites[_currentSprite];
        if (_currentSprite < _sprites.Length - 1)
            _currentSprite++;
        else
            _currentSprite = 0;

        _timer = 0;
    }
}
