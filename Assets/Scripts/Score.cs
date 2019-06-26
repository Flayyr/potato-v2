using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score;
    [SerializeField] Text textComponent;
    private void Start()
    {
        score = 0;
        textComponent.text = "Score: " + score;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "good")
        {
            score++;
            textComponent.text = "Score: " + score;
        }
    }
}
