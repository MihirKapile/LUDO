using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
	public static int howManyPlayers;
	public void two_player()
	{
		SoundManager.buttonAudioSource.Play();
		howManyPlayers = 2;
		SceneManager.LoadScene("Ludo");
	}

	public void three_player()
	{
		SoundManager.buttonAudioSource.Play();
		howManyPlayers = 3;
		SceneManager.LoadScene("Ludo");
	}

	public void four_player()
	{
		SoundManager.buttonAudioSource.Play();
		howManyPlayers = 4;
		SceneManager.LoadScene("Ludo");
	}

	public void quit()
	{
		SoundManager.buttonAudioSource.Play();
		if(EditorApplication.isPlaying == true)
        {
			EditorApplication.isPlaying = false;
        }
		Application.Quit();
	}
}
