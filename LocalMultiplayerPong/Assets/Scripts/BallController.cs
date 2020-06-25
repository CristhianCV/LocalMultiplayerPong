using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float movementSpeedRaise;

    private float movementSpeedX;
    private float movementSpeedY;

    private float minBaseSpeed = 5f;
    private float maxBaseSpeed = 7f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * movementSpeedX * Time.deltaTime + transform.up * movementSpeedY * Time.deltaTime);
    }

    public void AddSpeed()
    {
        movementSpeedX = (Random.Range(0, 2) * 2 - 1) * Random.Range(minBaseSpeed, maxBaseSpeed);
        movementSpeedY = (Random.Range(0, 2) * 2 - 1) * Random.Range(minBaseSpeed, maxBaseSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Paddle")
        {
            movementSpeedX = -(movementSpeedX + Mathf.Sign(movementSpeedX) * movementSpeedRaise);
            movementSpeedY = movementSpeedY + Mathf.Sign(movementSpeedY) * movementSpeedRaise;
        }
        else if (collision.gameObject.tag == "Wall")
        {
            movementSpeedY = -movementSpeedY;
        }
        else if (collision.gameObject.tag == "LeftGoal")
        {
            movementSpeedX = 0;
            movementSpeedY = 0;
            GameController.instance.IncreasePlayerTwoScore();
            GameController.instance.EndRound();
        }
        else if (collision.gameObject.tag == "RightGoal")
        {
            movementSpeedX = 0;
            movementSpeedY = 0;
            GameController.instance.IncreasePlayerOneScore();
            GameController.instance.EndRound();
        }
    }
}
