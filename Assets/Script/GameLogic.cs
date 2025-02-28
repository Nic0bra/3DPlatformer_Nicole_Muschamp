using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    //Initialize variables
    public GameObject startCanvas;
    [SerializeField] GameObject gameCanvas;
    [SerializeField] GameObject winCanvas;
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] PlayerStats bigVegasStats;
    [SerializeField] GameObject player;

    //Start the game
    public void StartGame()
    {
        //Set Game Canvas to true and all others to false
        startCanvas.SetActive(false);
        gameCanvas.SetActive(true);
        winCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);

        //Reset health for new game
        bigVegasStats.health = bigVegasStats.maxHealth;

        //Set player position
        player.transform.position = player.transform.position;
    }

    //End game with a win
    public void WinGame()
    {
        //Set Win Canvas to true and all others to false
        startCanvas.SetActive(false);
        gameCanvas.SetActive(false);
        winCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
    }

    //End game with loss
    public void GameOver()
    {
        //Set Game Over Canvas to true and all others to false
        startCanvas.SetActive(false);
        gameCanvas.SetActive(false);
        winCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
    }

    //Restart the game
    public void RestartGame()
    {
        //Reset health for new game
        bigVegasStats.health = bigVegasStats.maxHealth;

        //Set player position
        player.transform.position = player.transform.position;

        //Go back to start canvas
        startCanvas.SetActive(true);
        gameCanvas.SetActive(false);
        winCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
    }
}
