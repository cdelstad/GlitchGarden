using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "diffifulty";
    const string LEVEL_KEY = "level_unlocked_";
    // level_unlocked_1, 2, 3, etc

    public static void SetMasterVolume (float volume)
    {
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        } else
        {
            Debug.Log("Master Volume out of range.");
        }
    }

    public static float GetMasterVolume ()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void UnlockLevel (int level)
    {
        if (level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1); // Use 1 for true
        }
        else
        {
            Debug.Log("Trying to unlock a level not in build order");
        }
    }

    public static bool IsLevelUnlocked(int level)
    {
        if (level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            int levelExists = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
            if (levelExists == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            Debug.Log("Level is not in valid range.");
            return false;
        }

    }

    public static void SetDifficulty(float diff)
    {
        if (diff >= 1f && diff <= 3f)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, diff);
        }
        else
        {
            Debug.Log("Difficulty is out of range.");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }



}
