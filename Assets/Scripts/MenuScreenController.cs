using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScreenController : MonoBehaviour {

	//Cargar el juego desde el menu, usando el botón de "Jugar".
	public void StartGame()
	{
		SceneManager.LoadScene("scene1");
	}

}