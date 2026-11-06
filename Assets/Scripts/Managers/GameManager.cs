using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI text;
    public float playerhealth = 100f;
    int score;




    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeHealth(float healthIncrement)
    {
        playerhealth -= healthIncrement;
        Debug.Log("playerhealth");
        text.text = "Health:" + playerhealth.ToString();
        if (playerhealth <= 0f)
        {
            playerDie();
        }

    }
    public void ChangeScore(int scoreIncrement)

    {


        score += scoreIncrement;

        text.text = "Score: " + score.ToString();

    }

    void playerDie()
    {
        Debug.Log("End");
        //Application.Quit();
    }
}
