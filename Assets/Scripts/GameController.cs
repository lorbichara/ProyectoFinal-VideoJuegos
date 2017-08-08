using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	//Variables
	public Text questionDisplayText;
	public Text scoreDisplayText;
	public Text timeRemainingDisplayText;
	public SimpleObjectPool answerButtonObjectPool;
	public Transform answerButtonParent;
	public GameObject questionDisplay;
	public GameObject roundEndDisplay;
	public Image questionImageDisplay;

	private DataController dataController;
	private RoundData currentRoundData;
	private QuestionData [] questionPool;

	private bool isRoundActive;
	private float timeRemaining;
	private int questionIndex;
	public static int playerScore;
	private List<GameObject> answerButtonGameObjects = new List<GameObject> ();


	// Use this for initialization
	void Start () {
		dataController = FindObjectOfType<DataController> ();
		currentRoundData = dataController.GetCurrentRoundData ();
		questionPool = currentRoundData.questions;
		timeRemaining = currentRoundData.timeLimitInSeconds;

		UpdateTimeRemainingDisplay ();

		playerScore = 0;
		questionIndex = 0;

		ShowQuestion ();
		isRoundActive = true;
	}

	//Desplegar preguntas
	private void ShowQuestion()
	{
		RemoveAnswerButtons ();
		QuestionData questionData = questionPool [questionIndex];
		questionDisplayText.text = questionData.questionText;

		for (int i = 0; i < questionData.answers.Length; i++) 
		{
			GameObject answerButtonGameObject = answerButtonObjectPool.GetObject (); 
			answerButtonGameObjects.Add (answerButtonGameObject);
			answerButtonGameObject.transform.SetParent (answerButtonParent);

			AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
			answerButton.Setup (questionData.answers [i]);

			//questionImageDisplay.sprite = questionData.questionImage;
		}

	}

	//Borrar las respuestas de la pregunta anterior para poner las nuevas.
	private void RemoveAnswerButtons() 
	{
		while (answerButtonGameObjects.Count > 0) 
		{
			answerButtonObjectPool.ReturnObject (answerButtonGameObjects [0]);
			answerButtonGameObjects.RemoveAt (0);
		}
	}

	//Contestar pregunta... aquí se ganan/pierden puntos. (El valor de los puntos dados está en "preguntas" en el DataController.
	public void AnswerButtonClicked(bool isCorrect) 
	{
		if (isCorrect) {
			playerScore += currentRoundData.pointsAddedForCorrectAnswer;
			scoreDisplayText.text = "Score: " + playerScore.ToString ();

			if (questionPool.Length > questionIndex + 1) {
				questionIndex++;
				ShowQuestion ();
			} 
			else 
			{
				EndRound ();
			}

		} 

		else 
		{
			playerScore -= currentRoundData.pointsAddedForCorrectAnswer;
			scoreDisplayText.text = "Score: " + playerScore.ToString ();
			//if(playerScore < 0)
			//	SceneManager.LoadScene ("perder");
		}

		//este if va aquí si queremos que avance la pregunta sin importar que la haya contestado mal.
		/*if (questionPool.Length > questionIndex + 1) {
			questionIndex++;
			ShowQuestion ();
		} 
		else 
		{
			EndRound ();
		}
	*/

	}

	//Terminar el nivel.
	public void EndRound()
	{
		isRoundActive = false;

		questionDisplay.SetActive (false);
		//roundEndDisplay.SetActive (true);

		Scene currentScene = SceneManager.GetActiveScene();

		// Retrieve the name of this scene.
		string sceneName = currentScene.name;

		if (sceneName == "Game")
			SceneManager.LoadScene("scene3");

		if (sceneName == "Game2")
			SceneManager.LoadScene("ganar");

		if (sceneName == "final")
			SceneManager.LoadScene("ganar");
	}
		
	//Regresar al menu. Esta función va con un botón.
	public void ReturnToMenu()
	{
		SceneManager.LoadScene ("MenuScreen");
	}

	//Modificar el tiempo restante.
	private void UpdateTimeRemainingDisplay()
	{
		timeRemainingDisplayText.text = "Time: " + Mathf.Round (timeRemaining).ToString ();
	}

	// Update is called once per frame
	void Update () 
	{
    if(Input.GetKey(KeyCode.Q))
    {
     Application.LoadLevel("MenuScreen");
    }
		if (isRoundActive) 
		{
			timeRemaining -= Time.deltaTime;
			UpdateTimeRemainingDisplay ();

			if (timeRemaining <= 0f) 
			{
				SceneManager.LoadScene ("perder");
			}
		}
	}
}
