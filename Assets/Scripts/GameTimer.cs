using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {
    public float levelSeconds = 100;
        
    private Slider slider;
    private AudioSource audioSource;
    private bool isEndOfLevel = false;
    private LevelManager levelManager;
    private GameObject winLabel;

	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        winLabel = GameObject.Find("YouWin");
        if (!winLabel)
        {
            Debug.LogWarning("Please create YouWin object");
        } else
        {
            winLabel.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
        slider.value = 1 - (Time.timeSinceLevelLoad / levelSeconds);
        if (Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel)
        {
            DestroyAllTaggedObjects();
            audioSource.Play();
            winLabel.SetActive(true);
            Invoke("LoadNextLevel", audioSource.clip.length);
            isEndOfLevel = true;
        }
	}

    // Destroys all objects with "destroyOnWin" tag.
    void DestroyAllTaggedObjects ()
    {
        GameObject[] destroyOnWinArray = GameObject.FindGameObjectsWithTag("destroyOnWin");
        foreach (GameObject destroyMe in destroyOnWinArray)
        {
            Destroy(destroyMe);
        }
    }

    void LoadNextLevel ()
    {
        levelManager.LoadNextLevel();
    }
}
