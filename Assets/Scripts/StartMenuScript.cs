using UnityEngine;
using System.Collections;

public class StartMenuScript : MonoBehaviour {

	private GUISkin skin;

  void Start()
  {
    // Load a skin for the buttons
    skin = Resources.Load("GUISkin") as GUISkin;
  }

  void OnGUI()
  {
    const int buttonWidth = 128;
    const int buttonHeight = 60;

    // Set the skin to use
    GUI.skin = skin;

    // Draw a button to start the game
    if (GUI.Button(
      // Center in X, 2/3 of the height in Y
      new Rect(Screen.width / 2 - (buttonWidth / 2), (3 * Screen.height / 4) - (buttonHeight / 2), buttonWidth, buttonHeight),
      "START"
      ))
    {
      // On Click, load the first level.
      Application.LoadLevel("Stage"); // "Stage1" is the scene name
    }
  }

}
