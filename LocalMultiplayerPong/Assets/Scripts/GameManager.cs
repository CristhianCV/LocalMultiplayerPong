using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    private int playerOneScore = 0;
    private int playerTwoScore = 0;
    private int roundsToWin = 3;

    private bool isPlaying = false;

    public void StartGame()
    {
        playerOneScore = 0;
        UIManager.GetInstance().ChangeText(UIType.Gameplay, "PlayerOneScoreText", playerOneScore.ToString());
        playerTwoScore = 0;
        UIManager.GetInstance().ChangeText(UIType.Gameplay, "PlayerTwoScoreText", playerTwoScore.ToString());
        isPlaying = false;
        SceneManager.LoadScene("Game");
        UIManager.GetInstance().SwitchUI(UIType.Gameplay);
        UIManager.GetInstance().ActiveteObject(UIType.Gameplay, "StartRoundText", true);
    }

    public void StartRound(InputAction.CallbackContext context)
    {
        if (context.performed && !isPlaying)
        {
            UIManager.GetInstance().ActiveteObject(UIType.Gameplay, "StartRoundText", false);
            isPlaying = true;
            FindObjectOfType<BallController>().AddSpeed();
        }
    }

    public void EndRound()
    {
        StartCoroutine(ReloadScene());
    }

    private IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(1.5f);
        isPlaying = false;
        if (playerOneScore == roundsToWin)
        {
            SceneManager.LoadScene("GameOver");
            UIManager.GetInstance().SwitchUI(UIType.GameOver);
            UIManager.GetInstance().ChangeText(UIType.GameOver, "WinnerText", "PLAYER 1 WIN");
        }
        else if (playerTwoScore == roundsToWin)
        {
            SceneManager.LoadScene("GameOver");
            UIManager.GetInstance().SwitchUI(UIType.GameOver);
            UIManager.GetInstance().ChangeText(UIType.GameOver, "WinnerText", "PLAYER 2 WIN");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            UIManager.GetInstance().ActiveteObject(UIType.Gameplay, "StartRoundText", true);
        }
    }

    public void IncreasePlayerOneScore()
    {
        playerOneScore += 1;
        UIManager.GetInstance().ChangeText(UIType.Gameplay, "PlayerOneScoreText", playerOneScore.ToString());
        EndRound();
    }

    public void IncreasePlayerTwoScore()
    {
        playerTwoScore += 1;
        UIManager.GetInstance().ChangeText(UIType.Gameplay, "PlayerTwoScoreText", playerTwoScore.ToString());
        EndRound();
    }
}
