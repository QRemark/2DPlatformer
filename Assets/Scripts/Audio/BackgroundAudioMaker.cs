using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundAudioMaker : MonoBehaviour
{
    [SerializeField] private AudioSource _sound;

    private float _maxVolume = 1.0f;
    private float _changeVolumeSpeed = 0.1f;
    private float _targetVolume;
    private Coroutine _volumeChanger;

    private void Awake()
    {
        _sound.volume = 0f;
    }

    private void Start()
    {
        PlayMaxVolume();
    }

    //private void Update()
    //{
    //    ChangeVolume();
    //}

    private void PlayMaxVolume()
    {
        _sound.Play();
        SetTargetVolume(_maxVolume);
    }

    //private void ChangeVolume()
    //{
    //    _sound.volume = Mathf.MoveTowards(_sound.volume, _targetVolume,
    //        _changeVolumeSpeed * Time.deltaTime);
    //}

    private void SetTargetVolume(float targetVolume)
    {
        _targetVolume = targetVolume;

        if (_volumeChanger != null)
            StopCoroutine(_volumeChanger);

        _volumeChanger = StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        while (Mathf.Abs(_sound.volume - _targetVolume) > 0.1f)
        {
            _sound.volume = Mathf.MoveTowards(_sound.volume, _targetVolume, _changeVolumeSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
