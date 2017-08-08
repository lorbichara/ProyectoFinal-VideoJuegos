using UnityEngine;
using System.Collections;

[System.Serializable]
public class RoundData {

	//Variables de cada nivel.
	public string name;
	public int timeLimitInSeconds; //tiempo que tiene el jugador en esta ronda
	public int pointsAddedForCorrectAnswer;
	public QuestionData [] questions;

}
