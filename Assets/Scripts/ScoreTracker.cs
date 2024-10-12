using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public TMP_Text counter;
    private int score = 0;
    public void IncScore(int byVal) {
        score += byVal;
        counter.text = "Ice Samples: " + score;
    }
}
