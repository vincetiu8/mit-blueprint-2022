using System;
using UnityEngine;

namespace Audio
{
    public class AudioSyncer : MonoBehaviour
    {
        [SerializeField] private FFTWindow fftWindow;
        [SerializeField] private float bias;
        [SerializeField] private float timeBetweenBeats;

        private float _previousAudioValue;
        private float _audioValue;
        private float _timer;

        protected virtual void Update()
        {
            _previousAudioValue = _audioValue;
            _audioValue = AudioSpectrum.SpectrumValues[fftWindow];

            if (_previousAudioValue > bias != _audioValue > bias)
            {
                if (_timer > timeBetweenBeats)
                {
                    OnBeat();
                }
            }

            _timer += Time.deltaTime;
        }

        protected virtual void OnBeat()
        {
            _timer = 0;
        }
    }
}