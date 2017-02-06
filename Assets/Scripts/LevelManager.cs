using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float autoLoadNextLevelAfter;

    void Start()
    {
        if(autoLoadNextLevelAfter <= 0)
        {
            Debug.Log("Level Autoload Disabled. Use a positive number in seconds.");
        } else
        {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }
    }

	public void LoadLevel(string name){
		Debug.Log ("Level Load Requested for: " + name);
		SceneManager.LoadScene (name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

	public void LoadNextLevel () {
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}

}
