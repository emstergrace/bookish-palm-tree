using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{

    public Slider sound = null;
	public Slider music = null;

	private void Start() {
		sound.value = AudioManager.Sound * sound.maxValue;
		music.value = AudioManager.Music * music.maxValue;
		sound.onValueChanged.AddListener((x) => { AudioManager.Inst.SetSoundLevel(x/sound.maxValue); });
		music.onValueChanged.AddListener((x) => { AudioManager.Inst.SetMusicLevel(x/music.maxValue); });
	}
}
