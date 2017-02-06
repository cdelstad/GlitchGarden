using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour
{
    public int starCost = 100;
    private StarDisplay starDisplay;

    void Start ()
    {
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
    }

    // for identification purpose. Change then to tags later?
    public void AddStars (int amount)
    {
        starDisplay.AddStars(amount);
    }
}
