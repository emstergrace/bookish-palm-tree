using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASSubscriber : MonoBehaviour
{
	public float volumeMultipler = 1f;
	AudioSource[] audioS;

	private void Start() {
		audioS = GetComponentsInChildren<AudioSource>();
		if (AudioManager.Inst == null) return;
		for (int i = 0; i < audioS.Length; i++) {
			AudioManager.Inst.SubscribeSFXAudio(audioS[i]);
			audioS[i].volume *= volumeMultipler;
		}
		AudioManager.Inst.NewSoundVolume += AdjustVolume;
	}

	private void AdjustVolume(float val) {
		for (int i = 0; i < audioS.Length; i++) {
			if (audioS[i] != null)
				audioS[i].volume = val * volumeMultipler;
		}
	}

	private void OnDestroy() {
		for (int i = 0; i < audioS.Length; i++) {
			AudioManager.Inst.UnsubscribeSFXAudio(audioS[i]);
		}
	}
}
