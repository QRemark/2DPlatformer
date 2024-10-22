using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundAudioMaker : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;

    private float _maxVolume = 1.0f;
    private float _changeVolumeSpeed = 0.1f;
    private float _targetVolume;

    private void Awake()
    {
        _sound.volume = 0f;
    }

    private void Start()
    {
        PlayMaxVolume();
    }

    private void Update()
    {
        ChangeVolume();
    }

    private void PlayMaxVolume()
    {
        _sound.Play();
        _targetVolume = _maxVolume;
    }

    private void ChangeVolume()
    {
        _sound.volume = Mathf.MoveTowards(_sound.volume, _targetVolume,
            _changeVolumeSpeed * Time.deltaTime);
    }
}
