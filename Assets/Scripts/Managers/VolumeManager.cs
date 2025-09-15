using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Managers
{
    public class VolumeSlider : MonoBehaviour
    {
        public AudioMixerGroup musicMixer, sfxMixer;
        public Slider musicVolumeSlider, sfxVolumeSlider;

        public void SetMusicVolume()
        {
            musicMixer.audioMixer.SetFloat("MusicVolume", Mathf.Log10(musicVolumeSlider.value) * 20);
        }

        public void SetSFXVolume()
        {
            sfxMixer.audioMixer.SetFloat("SFXVolume", Mathf.Log10(sfxVolumeSlider.value) * 20);
        }
    }
}