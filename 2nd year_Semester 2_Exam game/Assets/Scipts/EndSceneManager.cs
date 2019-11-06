using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSceneManager : MonoBehaviour
{
    public Text GoldCollected;
    public Text HighScore;

    public int _GoldCollected;
    public int _HighScore;
        
    void Update()
    {
      

        
    }

    private void Start()
    {
        _HighScore = PlayerPrefs.GetInt("HighScore");
        _GoldCollected = PlayerPrefs.GetInt("MoneyEarned");

        if (_GoldCollected >= _HighScore)
        {
            _HighScore = _GoldCollected;
        }

        GoldCollected.text = _GoldCollected.ToString();
        HighScore.text = _HighScore.ToString();

        PlayerPrefs.SetInt("HighScore", _HighScore);
    }
}
