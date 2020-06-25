using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour
{
    [HideInInspector] public static PlayerUIController instance;

    [SerializeField] private Text playerOneScoreText;
    [SerializeField] private Text playerTwoScoreText;
    [SerializeField] private Text startRoundText;

    // Start is called before the first frame update
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowStartRoundText(bool isVisible)
    {
        PlayerUIController.instance.startRoundText.enabled = isVisible;
    }

    public void UpdateScores(int playerOneScore, int playerTwoScore)
    {
        PlayerUIController.instance.playerOneScoreText.text = playerOneScore.ToString();
        PlayerUIController.instance.playerTwoScoreText.text = playerTwoScore.ToString();
    }
}
