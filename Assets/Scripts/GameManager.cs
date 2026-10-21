using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI text;
    public float playerhealth = 100f;

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
    public void Changehealth(float healthIncrement)
    {
        playerhealth -= healthIncrement;
        Debug.Log("playerhealth");
        text.text = "Health:" + playerhealth.ToString();
        if (playerhealth <= 0f)
        {
            playerDie();
        }

    }
    void playerDie()
    {
        Debug.Log("End");
        //Application.Quit();
    }
}
