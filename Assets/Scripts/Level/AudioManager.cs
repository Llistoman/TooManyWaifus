using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	//Add audio clips if needed
	public AudioClip CombatMusic;
    public AudioClip WinMusic;
    public AudioClip GameOverMusic;

    public AudioClip fire;
    public AudioClip destroyEnemy;
    public AudioClip levelUp;
    public AudioClip moan;


    //Add audio sources, one for music, one for sounds
    public AudioSource MusicSource;
	public AudioSource FireSource;
    public AudioSource DestroySource;
    public AudioSource MoanSource;
    public AudioSource LevelSource;

    public void MusicStop() {
			MusicSource.Stop ();
	}

    public void FireStop()
    {
        FireSource.Stop();
    }

	public void PlayCombatMusic () {
		MusicSource.Stop ();
		MusicSource.clip = CombatMusic;
		MusicSource.loop = true;
		MusicSource.Play ();
	}

    public void PlayWinMusic()
    {
        MusicSource.Stop();
        MusicSource.clip = WinMusic;
        MusicSource.loop = true;
        MusicSource.Play();
    }

    public void PlayGameOverMusic()
    {
        MusicSource.Stop();
        MusicSource.clip = GameOverMusic;
        MusicSource.loop = true;
        MusicSource.Play();
    }

    public void PlayFire() {
        if(FireSource.clip == null)
            FireSource.clip = fire;
        FireSource.Play ();
	}

	public void PlayDestroyEnemy() {
		DestroySource.Stop ();			
		DestroySource.clip = destroyEnemy;
		DestroySource.Play ();
	}

    public void PlayLevelUp()
    {
        LevelSource.Stop();
        LevelSource.clip = levelUp;
        LevelSource.Play();
    }

    public void PlayMoan() {
		MoanSource.Stop ();			
		MoanSource.clip = moan;
		MoanSource.Play ();
	}
}
