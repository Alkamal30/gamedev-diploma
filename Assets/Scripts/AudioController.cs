using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance
    {
        get
        {
            return _instance;
        }
    }

    private static AudioController _instance;

    [SerializeField] private AudioSource _backgroundAudioSource;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _successClip;
    [SerializeField] private AudioClip _deathClip;
    [SerializeField] private AudioClip _bossFightClip;

    private void Awake()
    {
        _instance = this;
    }

    public void PlaySuccessClip()
    {
        _audioSource.PlayOneShot(_successClip);
    }

    public void PlayDeathClip()
    {
        _audioSource.PlayOneShot(_deathClip);
    }

    public void PlayerBossFightClip()
    {
        _backgroundAudioSource.clip = _bossFightClip;
        _backgroundAudioSource.Play();
    }
}
