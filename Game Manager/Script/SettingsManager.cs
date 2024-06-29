/*
    Remove // to Enable
    Required to Install Packages First before Enabling
*/


using System.Threading.Tasks;
//using Cinemachine.PostFX;
using UnityEngine;
using UnityEngine.Audio;
//using UnityEngine.Localization.Settings;
//using UnityEngine.Rendering.Universal;

public class SettingsManager : MonoBehaviour
{   
    public static int[] availableFramerate = {30, 60, 90, 120};
    [SerializeField] AudioMixer audioMixer;
    public static AudioMixer _audioMixer;

    public async void Initialize() 
    {
        _audioMixer = audioMixer;
        Display.Framerate = Display.Framerate;
        Display.VSync = Display.VSync;
        Sound.Master = Sound.Master;
        Sound.Music = Sound.Music;
        Sound.Effect = Sound.Effect;
        Sound.UI = Sound.UI;
        Sound.Voice = Sound.Voice;
        Quality.Shadow = Quality.Shadow;
        Quality.PostProcessing = Quality.PostProcessing;
        Quality.AntiAliasing = Quality.AntiAliasing;

        /*
        // Enable when Localization has instaled on project
        while (LocalizationSettings.AvailableLocales.Locales.Capacity <= 0)
        {
            await Task.Yield();
        }
        */
        
        Display.Language = Display.Language;
        await Task.Yield();
    }

    public static class Display 
    {
        public static int Framerate 
        {
            get {
                return PlayerPrefs.GetInt("display_framerate", availableFramerate.Length-1);
            }
            set {
                PlayerPrefs.SetInt("display_framerate", value);
                Application.targetFrameRate = availableFramerate[value];
            }
        }

        public static int Language 
        {
            get {
                return PlayerPrefs.GetInt("display_language", 0);
            }
            set {
                PlayerPrefs.SetInt("display_language", value);
                // Place Your Code Here
                //LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[value];
            }
        }

        public static int VSync
        {
            get {
                return PlayerPrefs.GetInt("display_vsync", 0);
            }
            set {
                PlayerPrefs.SetInt("display_vsync", value);
                QualitySettings.vSyncCount = value;
            }
        }
    }

    public static class Sound 
    {
        public static float Master 
        {
            get {
                return PlayerPrefs.GetFloat("sound_master", 1.0f);
            }
            set {
                PlayerPrefs.SetFloat("sound_master", value);
                _audioMixer.SetFloat("volume_master", value > 0 ? Mathf.Log10(value) * 20f : -80f);
            }
        }

        public static float Music 
        {
            get {
                return PlayerPrefs.GetFloat("sound_music", 1.0f);
            }
            set {
                PlayerPrefs.SetFloat("sound_music", value);
                _audioMixer.SetFloat("volume_music", value > 0 ? Mathf.Log10(value) * 20f : -80f);
            }
        }

        public static float Effect 
        {
            get {
                return PlayerPrefs.GetFloat("sound_effect", 1.0f);
            }
            set {
                PlayerPrefs.SetFloat("sound_effect", value);
                _audioMixer.SetFloat("volume_effect", value > 0 ? Mathf.Log10(value) * 20f : -80f);
            }
        }

        public static float UI
        {
            get {
                return PlayerPrefs.GetFloat("sound_ui", 1.0f);
            }
            set {
                PlayerPrefs.SetFloat("sound_ui", value);
                _audioMixer.SetFloat("volume_ui", value > 0 ? Mathf.Log10(value) * 20f : -80f);
            }
        }

        public static float Voice 
        {
            get {
                return PlayerPrefs.GetFloat("sound_voice", 1.0f);
            }
            set {
                PlayerPrefs.SetFloat("sound_voice", value);
                _audioMixer.SetFloat("volume_voice", value > 0 ? Mathf.Log10(value) * 20f : -80f);
            }
        }
    }

    public static class Quality 
    {
        public static int PostProcessing 
        {
            get {
                return PlayerPrefs.GetInt("quality_postporcessing", 1);
            }
            set {
                PlayerPrefs.SetInt("quality_postporcessing", value);
                // Place Your Code Here
                //Camera.main.GetComponent<UniversalAdditionalCameraData>().renderPostProcessing = value == 1;
            }
        }

        public static int Shadow 
        {
            get {
                return PlayerPrefs.GetInt("quality_shadow", 0);
            }
            set {
                PlayerPrefs.SetInt("quality_shadow", value);
                // Place Your Code Here
                //Camera.main.GetComponent<UniversalAdditionalCameraData>().renderShadows = value == 1;
            }
        }

        public static int AntiAliasing 
        {
            get {
                return PlayerPrefs.GetInt("quality_AA", 0);
            }
            set {
                PlayerPrefs.SetInt("quality_AA", value);
                // Place Your Code Here
            }
        }
    }
}
