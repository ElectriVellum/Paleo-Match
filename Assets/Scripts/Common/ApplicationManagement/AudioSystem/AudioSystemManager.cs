using UnityEngine;

namespace Assets.Scripts.Common.ApplicationManagement.AudioSystem
{
    public class AudioSystemManager : MonoBehaviour
    {
        private static AudioSystemManager _instance;

        public static AudioSystemManager Instance
        {
            get
            {
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }

        [SerializeField()]
        private AudioSource _musicAudioSource;

        [SerializeField()]
        private AudioSource _soundsAudioSource;

        [SerializeField()]
        private AudioClip _titleBackgroundMusic;

        [SerializeField()]
        private AudioClip _windowShowSound;

        [SerializeField()]
        private AudioClip _windowHideSound;

        [SerializeField()]
        private AudioClip _buttonClickSound;

        public AudioSource MusicAudioSource
        {
            get
            {
                return _musicAudioSource;
            }
        }

        public AudioSource SoundsAudioSource
        {
            get
            {
                return _soundsAudioSource;
            }
        }

        public bool MuteMusic
        {
            get
            {
                if (_musicAudioSource == null)
                {
                    return (PlayerPrefs.GetInt("MuteMusic", 0) == 0) ? false : true;
                }
                return _musicAudioSource.mute;
            }
            set
            {
                if (_musicAudioSource != null)
                {
                    _musicAudioSource.mute = value;
                }
                PlayerPrefs.SetInt("MuteMusic", (value == false) ? 0 : 1);
            }
        }

        public bool MuteSounds
        {
            get
            {
                if (_soundsAudioSource == null)
                {
                    return (PlayerPrefs.GetInt("MuteSounds", 0) == 0) ? false : true;
                }
                return _soundsAudioSource.mute;
            }
            set
            {
                if (_soundsAudioSource != null)
                {
                    _soundsAudioSource.mute = value;
                }
                PlayerPrefs.SetInt("MuteSounds", (value == false) ? 0 : 1);
            }
        }

        public AudioSystemManager()
        {
            Instance = this;
            _musicAudioSource = null;
            _soundsAudioSource = null;
            _titleBackgroundMusic = null;
            _windowShowSound = null;
            _windowHideSound = null;
            _buttonClickSound = null;
        }

        private void Awake()
        {
            var audioSources = GetComponents<AudioSource>();
            if (_musicAudioSource == null && _soundsAudioSource == null)
            {
                if (audioSources != null && audioSources.Length == 2)
                {
                    _musicAudioSource = audioSources[0];
                    _soundsAudioSource = audioSources[1];
                }
            }
            else if (_musicAudioSource == null)
            {
                if (audioSources != null && audioSources.Length == 1)
                {
                    _musicAudioSource = audioSources[0];
                }
            }
            else if (_soundsAudioSource == null)
            {
                if (audioSources != null && audioSources.Length == 1)
                {
                    _soundsAudioSource = audioSources[0];
                }
            }
            MuteMusic = (PlayerPrefs.GetInt("MuteMusic", 0) == 0) ? false : true;
            MuteSounds = (PlayerPrefs.GetInt("MuteSounds", 0) == 0) ? false : true;
        }

        private void Start()
        {
            PlayTitleBackgroundMusic();
        }

        public void PlayTitleBackgroundMusic()
        {
            PlayBackgroundMusic(_titleBackgroundMusic);
        }

        public void PlayBackgroundMusic(AudioClip audioClip = null)
        {
            if (_musicAudioSource != null && audioClip != null)
            {
                StopBackgroundMusic();
                _musicAudioSource.loop = true;
                _musicAudioSource.clip = audioClip;
                _musicAudioSource.Play();
            }
        }

        public void StopBackgroundMusic()
        {
            if (_musicAudioSource != null && _musicAudioSource.isPlaying == true)
            {
                _musicAudioSource.Stop();
            }
        }

        public void PlayWindowShowSound(AudioClip showSound = null)
        {
            if (showSound != null)
            {
                PlayOneShotSound(showSound);
            }
            else
            {
                PlayOneShotSound(_windowShowSound);
            }
        }

        public void PlayWindowHideSound(AudioClip hideSound = null)
        {
            if (hideSound != null)
            {
                PlayOneShotSound(hideSound);
            }
            else
            {
                PlayOneShotSound(_windowHideSound);
            }
        }

        public void PlayButtonClickSound(AudioClip clickSound = null)
        {
            if (clickSound != null)
            {
                PlayOneShotSound(clickSound);
            }
            else
            {
                PlayOneShotSound(_buttonClickSound);
            }
        }

        public void PlayOneShotSound(AudioClip audioClip = null)
        {
            if (_soundsAudioSource != null && audioClip != null)
            {
                _soundsAudioSource.PlayOneShot(audioClip);
            }
        }
    }
}