using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	void Start(){
	}

    public string nextLevel;

    public void NextLevel()
    {
        if (nextLevel == null) return;
        SceneManager.LoadScene(nextLevel);
    }


	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

}
