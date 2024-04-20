using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class AudioManager : MonoBehaviour
{
    public static AudioManager Inst { get; private set; }

	[Header("Sounds")]
	[SerializeField] private List<Sound> sounds = new List<Sound>(); 
	public Dictionary<string, AudioSource> SoundsDictionary { get; private set; } = new Dictionary<string, AudioSource>();

	[SerializeField] private List<AudioSource> sceneAudio = new List<AudioSource>();
	private static float soundVolume = 0.5f; public static float Sound { get { return soundVolume; } }

	public Action<float> NewSoundVolume;

	[Header("Music")]
	[SerializeField] private AudioSource menuMusic = null;
	[SerializeField] private AudioSource mainTheme = null; public void SetMainTheme(AudioSource aSo) { mainTheme = aSo; aSo.Play(); }
	private static float musicVolume = 0.5f; public static float Music { get { return musicVolume; } }

	private void Awake() {
		Inst = this;
		for (int i = 0; i < sounds.Count; i++) {
			SoundsDictionary.Add(sounds[i].name, sounds[i].audio);
		}
		DontDestroyOnLoad(this.gameObject);
	}

	private void Start() {

		SetSoundLevel(soundVolume);
		SetMusicLevel(musicVolume);
	}

	public void SubscribeSFXAudio(AudioSource source) {
		sceneAudio.Add(source);
		source.volume = soundVolume;
	}
	public void UnsubscribeSFXAudio(AudioSource source) {
		sceneAudio.Remove(source);
	}

	public void SetSoundLevel(float level) {
		soundVolume = level;
		foreach(AudioSource source in sceneAudio) {
			source.volume = soundVolume;
		}
		foreach (KeyValuePair<string, AudioSource> keys in SoundsDictionary) {
			if (keys.Value != null)
				keys.Value.volume = level;
		}

		NewSoundVolume?.Invoke(level);
	}

	public void SetMusicLevel(float level) {
		musicVolume = level;
		if (menuMusic != null) menuMusic.volume = musicVolume;
		if (mainTheme != null) mainTheme.volume = musicVolume;
	}

	public void PlayMainTheme() {
		mainTheme.Play();
	}

	/// <summary>
	/// Use this to replace playing any specific audio
	/// </summary>
	/// <param name="name"></param>
	public void PlaySound(string name) {
		if (SoundsDictionary.ContainsKey(name)) {
			if (SoundsDictionary[name] != null)
				SoundsDictionary[name].Play();
			else {
				Debug.LogError("Sounds dictionary contains listing for [" + name + "] but no sound associated");
			}
		}
		else
			Debug.LogError("Sounds dictionary does not contain sound for " + name);
	}

	public void StopSound(string name) {
		if (SoundsDictionary.ContainsKey(name)) {
			if (SoundsDictionary[name] != null)
				SoundsDictionary[name].Stop();
			else {
				Debug.LogError("Sounds dictionary contains listing for [" + name + "] but no sound associated");
			}
		}
		else
			Debug.LogError("Sounds dictionary does not contain sound for " + name);
	}

}
[System.Serializable]
public class Sound
{
	public string name;
	public AudioSource audio;
}
