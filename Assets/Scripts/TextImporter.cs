using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextImporter : MonoBehaviour {

	public TextAsset textFile;
	public string[] textLines;

	// Use this for initialization
	void Start () {

		if (textFile != null)
		{
			textLines = (textFile.text.Split ('\n')); //Splittear el archivo de texto cuando hay un salto de línea.
		
		}
		
	}

}



















