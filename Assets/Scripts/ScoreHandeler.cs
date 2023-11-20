using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    private TextMeshProUGUI _textComp;
    private int _score = 0;
    public TextMeshProUGUI endScore;

    // Start is called before the first frame update
    void Start()
    {
        //Hämtar Komponenten för att kunna använda den
        _textComp = GetComponent<TextMeshProUGUI>();


        UpdateScoreText();
    }

    public void AddScore()
    {
        _score += 1;
        //_score ++; //Same but different
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        _textComp.text = "Points: " + _score.ToString();
    }

    public void UpdateEndScore()
    {
        _textComp.gameObject.SetActive(false);
        endScore.text = "You killed " + _score.ToString() + " enemies >B)";
    }

}
