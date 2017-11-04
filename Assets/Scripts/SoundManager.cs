using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	// From https://www.youtube.com/watch?v=XeYc3Rx4jrQ&list=PLGLfVvz_LVvSYnwKyw9xP5tEn7GSUWwZJ&index=2

	public static SoundManager Instance = null;

	private AudioSource soundEffectAudio;

	// Audio Clips
	// public AudioClip name;

	// Use this for initialization
	void Start () {

		// make sure it's only one SoundManager
		if(Instance == null) {
			Instance = this;
		} else if(Instance != this) {
			Destroy(gameObject);
		}

		AudioSource[] sources = GetComponents<AudioSource>();

		foreach(AudioSource source in sources) {
			if(source.clip == null) {
				soundEffectAudio = source;
			}
		}

	}

	public void PlayOneShot(AudioClip clip) {
		soundEffectAudio.PlayOneShot(clip);
	}
}
