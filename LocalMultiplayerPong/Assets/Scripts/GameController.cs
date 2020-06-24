using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [HideInInspector] public static GameController perm;

    private int playerOneScore = 0;
    private int playerTwoScore = 0;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (!perm)
        {
            perm = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        playerOneScore = 0;
        playerTwoScore = 0;
        SceneManager.LoadScene("Game");
    }
}
