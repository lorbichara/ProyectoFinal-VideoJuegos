using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour {

	public void ChangeScene(string scene){
		SceneManager.LoadScene(scene);
	}
}
