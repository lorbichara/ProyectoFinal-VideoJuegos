using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DataController : MonoBehaviour //Supply round data to game controller.
{

	public RoundData[] allRoundData;

	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad (this); //when load new scene, this will persist.

		SceneManager.LoadScene("Game");
		//else if (sceneName == "preguntas2")
		//	SceneManager.LoadScene("Game2");
	}

	//Datos del nivel.
	public RoundData GetCurrentRoundData()
	{
		return allRoundData [0];

	}
}
