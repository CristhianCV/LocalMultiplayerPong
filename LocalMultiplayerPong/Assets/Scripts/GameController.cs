using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [HideInInspector] public static GameController instance;
    [SerializeField] private GameObject ball;

    private int playerOneScore = 0;
    private int playerTwoScore = 0;

    private bool isPlaying = false;

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

    public void StartGame()
    {
        GameController.instance.playerOneScore = 0;
        GameController.instance.playerTwoScore = 0;
        SceneManager.LoadScene("Game");
    }

    public void StartRound(InputAction.CallbackContext context)
    {
        GameObject newBall;
        if (context.performed && !isPlaying)
        {
            PlayerUIController.instance.ShowStartRoundText(false);
            GameController.instance.isPlaying = true;
            newBall = Instantiate(ball, Vector3.zero, Quaternion.identity);
            newBall.GetComponent<BallController>().AddSpeed();
        }
    }

    public void EndRound()
    {
        StartCoroutine(ReloadScene());
    }

    private IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(1.5f);
        Debug.Log("start");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("end");
        GameController.instance.isPlaying = false;
        PlayerUIController.instance.ShowStartRoundText(true);
    }

    public void IncreasePlayerOneScore()
    {
        GameController.instance.playerOneScore += 1;
        PlayerUIController.instance.UpdateScores(playerOneScore, playerTwoScore);
    }

    public void IncreasePlayerTwoScore()
    {
        GameController.instance.playerTwoScore += 1;
        PlayerUIController.instance.UpdateScores(playerOneScore, playerTwoScore);
    }
}
