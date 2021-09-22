using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public Text topScoreText;

    void Awake()
    {
        ScenePersistance.Instance.LoadScore();

        if (ScenePersistance.Instance.TopScorePlayerName != "")
        {
            topScoreText.text = "High Score: " + ScenePersistance.Instance.TopScore + " by " + ScenePersistance.Instance.TopScorePlayerName;
        }
        else
        {
            topScoreText.text = null;
        }
    }


}
