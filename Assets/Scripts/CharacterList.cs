using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterList : MonoBehaviour {
  public static string[] list;
  public static AudioSource baby;

	// Use this for initialization
	void Start() {

    list = new string[6];
		list[0] = "Matthew Whitehouse";
    list[1] = "Jesús Flores Bilbao";
    list[2] = "Mari Pérez";
    list[3] = "Juan Pérez";
    list[4] = "Brayan Pérez";
    list[5] = "Customs Officer Ramirez";
    baby = GetComponentInParent<AudioSource>();
	}

  public static void ActivateCharacter(int charIndex){
    GameObject character;
    if(charIndex == 4){
     baby.Play();
     character = GameObject.Find(list[3]);
     SpriteRenderer charSprite = character.GetComponent<SpriteRenderer>();
     charSprite.enabled = true;
    }
    float scaleFactor;
    string currentScene = SceneManager.GetActiveScene().name;
    if( currentScene == "scene2" || currentScene == "scene3" ){
      scaleFactor = 50f;
    }else{
      scaleFactor = 60f;
    }
    character = GameObject.Find(list[charIndex]);
    Transform transform = character.transform;
    transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
  }

  public static void DeActivateCharacter(int charIndex){
    GameObject character = GameObject.Find(list[charIndex]);
    Transform transform = character.transform;
    transform.localScale = new Vector3(50f, 50f, 50f);
  }
}
