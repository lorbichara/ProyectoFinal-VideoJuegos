using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DataC2 : MonoBehaviour //Supply round data to game controller.
{

	public RoundData[] allRoundData;

	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad (gameObject); //when load new scene, this will persist.

		//Scene currentScene = SceneManager.GetActiveScene();

		// Retrieve the name of this scene.
		//string sceneName = currentScene.name;

		SceneManager.LoadScene("Game2");
		//else if (sceneName == "preguntas2")
		//	SceneManager.LoadScene("Game2");
	}

	//Datos del nivel.
	public RoundData GetCurrentRoundData()
	{
		return allRoundData [0];

	}
}