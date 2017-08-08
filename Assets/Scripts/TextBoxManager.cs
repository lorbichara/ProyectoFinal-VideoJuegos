using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextBoxManager : MonoBehaviour {

  public GameObject textBox;

  public Text theText;

  public TextAsset textFile;
  public string[] textLines;

  public int currentLine;
  public int endAtLine;

  public bool isActive;

  private bool isTyping = false;
  private bool cancelTyping = false;

  public float typeSpeed;

  public int activeChar;

  // Use this for initialization
  void Start()
  {
    if (textFile != null)
    {
      textLines = (textFile.text.Split('\n')); //Splittear el archivo de texto cuando hay un salto de línea.
    }

    if (endAtLine == 0)
    {
      endAtLine = textLines.Length - 1;
    }

    if (isActive) {
      EnableTextBox();
    } else{
      Debug.Log("Here");
      DisableTextBox();
    }
  }

  void Update()
  {
    if(Input.GetKey(KeyCode.Q))
    {
      Application.LoadLevel("MenuScreen");
    }
    if (!isActive)
    {
      return;
    }

    //theText.text = textLines [currentLine];

    if (Input.GetKeyDown (KeyCode.Space))
    {
      if (!isTyping) 
      {
        currentLine += 1;

        if (currentLine > endAtLine) 
        {
          DisableTextBox();
        } 

        else 
        {
          if(SelectCharacter(textLines[currentLine]))
          {
            currentLine += 1;
          }
          StartCoroutine(TextScroll(textLines[currentLine]));
        }

      }
      else if (isTyping && !cancelTyping)
      {
        cancelTyping = true;
        CharacterList.DeActivateCharacter(activeChar);
      }
    }
  }

  public bool SelectCharacter(string line){
    for(int i = 0; i < 6; i++)
    {
      if(CharacterList.list[i] == line)
      {
        CharacterList.ActivateCharacter(i);
        activeChar = i;
        return true;
      }
    }
    return false;
  }

  private IEnumerator TextScroll (string lineOfText)
  {
    int letter = 0;

    theText.text = "";
    isTyping = true;
    cancelTyping = false;

    while (isTyping && !cancelTyping && (letter < lineOfText.Length - 1))
    {
      theText.text += lineOfText[letter];
      letter += 1;
      yield return new WaitForSeconds(typeSpeed);
    }

    theText.text = lineOfText;
    isTyping = false;
    cancelTyping = false;
  }

  public void EnableTextBox()
  {
    textBox.SetActive (true);
    isActive = true;
    if(SelectCharacter(textLines[currentLine])){
      currentLine++;
    }
    StartCoroutine(TextScroll(textLines[currentLine]));
  }

  public void DisableTextBox()
  {
    textBox.SetActive(false);
    isActive = false;

    Scene currentScene = SceneManager.GetActiveScene();

    // Retrieve the name of this scene.
    string sceneName = currentScene.name;

    if (sceneName == "scene1")
      SceneManager.LoadScene("scene2");
    else if (sceneName == "scene2")
      SceneManager.LoadScene("preguntas");
    else if (sceneName == "scene3")
      SceneManager.LoadScene("scene4");
    else if (sceneName == "scene4")
      SceneManager.LoadScene("preguntas2");
  }

  public void ReloadScript(TextAsset theText)
  {
    if (theText != null)
    {
      textLines = new string[1];
      textLines = (textFile.text.Split('\n'));
    }
  }
}




















