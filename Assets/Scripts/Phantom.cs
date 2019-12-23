

using UnityEngine;

public class Phantom : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float offsetMax = 0.5f;
    public float offsetMin = 0.2f;
    public bool hitted = false;
    public float increaseDifficulty = 1.01f;

    public Sprite spriteAlive;
    public Sprite spriteHitted;

    private float maxValueY;
    private float minValueY;
    private int direction = 1;

    public SpriteRenderer spriteRenderer;
    public Phantom phantom;
    public AudioSource audioSource;
    
    void OnEnable()
    {
        maxValueY = transform.position.y + offsetMax;
        minValueY = transform.position.y - offsetMin;
    }

    void Update()
    {
        if(transform.position.y >= maxValueY){
            direction = -1;
        }
        
        if(transform.position.y <= minValueY) {
            direction = 1;
            gameObject.SetActive(false);

            if(hitted) {
                GameManager.instance.NewPhantom();
            } else {
                GameManager.instance.GameOver();
            }
        }

        transform.position = transform.position + new Vector3(0, direction * movementSpeed * Time.deltaTime, 0);      
    }

    public void ResetPhantom(int layer, Vector3 positionToSpawn) {
        spriteRenderer.sortingOrder = layer;
        transform.position = positionToSpawn;
        phantom.hitted = false;
        spriteRenderer.sprite = spriteAlive;
        gameObject.SetActive(true);
    }

    void OnHitPhantom() {

        if(!hitted) {
            hitted = true;
            direction = -1;
            movementSpeed *= increaseDifficulty;
            spriteRenderer.sprite = spriteHitted; 
            audioSource.Play();
            GameManager.instance.Score();
        }
        
    }
    void OnMouseDown()
    {
        OnHitPhantom();
    }

    void OnTouchDown()
    {
        OnHitPhantom();
    }
}
