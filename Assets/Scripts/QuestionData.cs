using UnityEngine;
using System.Collections;

[System.Serializable] //Para poder editar en el Inspector.
public class QuestionData {

	//Variables importantes: preguntas, sus respectivas respuestas y la imagen a desplegar por pregunta.
	public string questionText;
	public AnswerData[] answers;
	//public Sprite questionImage;
}