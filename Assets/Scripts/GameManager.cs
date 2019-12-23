
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public Text scoreText;
    public Text recordText;
    public GameObject buttonStart;
    public Phantom phantom;

    private Spawner spawner;
    private bool shouldSpawn;
    private int score = 0;

    void Awake()
    {
        Time.timeScale = 0f;
        recordText.text = "High Score: " + PlayerPrefs.GetInt ("highscore");
        spawner = GetComponent<Spawner>();

        if(instance == null) {
            instance = this;
        }else if(GameManager.instance != this) {
            Destroy(gameObject);
        }
    }

    public void Score() {
        score += 1;

        scoreText.text = "" + score;
    }

    public void NewPhantom() {
        spawner.SpawnPhantom();
        shouldSpawn = false;
    }

    public void GameOver() {
        if(PlayerPrefs.GetInt ("highscore") < score) {
            PlayerPrefs.SetInt ("highscore", score);
            recordText.text = "High Score: " + PlayerPrefs.GetInt ("highscore") + " - NEW*";
        }

        buttonStart.SetActive(true);
    }

    void Update()
    {
        if(shouldSpawn) {
            NewPhantom();
        }
    }

    public void StartGame() {
        phantom.movementSpeed = 1f;
        Time.timeScale = 1f;
        score = 0;
        scoreText.text = "" + score;
        recordText.text = "High Score: " + PlayerPrefs.GetInt ("highscore");
        buttonStart.SetActive(false);
        shouldSpawn = true;
    }
}
