using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    // called when the player collects a coin
    public void SetScoreText (int score)
    {
        scoreText.text = score.ToString();
    }
     

}
