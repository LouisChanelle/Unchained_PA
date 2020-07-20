using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScored : MonoBehaviour
{
    public Text score;
    private Score getS;
    
    void Awake()
    {
        score.text = bossDeath.setScore.text;
    }
}
