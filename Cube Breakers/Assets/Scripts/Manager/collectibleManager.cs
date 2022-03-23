using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collectibleManager : MonoBehaviour
{
    public static collectibleManager instance;
    public collectible collectiblePrefab;
    public float yPos;
    public float minX;
    public float maxX;
    public float delayTime = 1;
    public int score;
    public Text scoreText;
    //public Color[] RGBCodes = {};

    public Button replayButton;


    // Start is called before the first frame update
    void Start()
    {
        GenerateCollectibles();
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void Awake()
    {
        instance = this;
    }

    private void GenerateCollectibles()
    {
        StartCoroutine(GenerateCollectible());
    }

    public void UpdateScore()
    {
        score += 1;
        scoreText.text = "Score:" + score;
    }
    public void GameOver()
    {
        StopAllCoroutines();
        replayButton.gameObject.SetActive(true);
    }
    public void Replay()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
      
        replayButton.gameObject.SetActive(false);
        score =0;
        scoreText.text = "Score: " + score;
        GenerateCollectibles();
    }
    IEnumerator GenerateCollectible()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            var collectible = Instantiate(collectiblePrefab, transform);
       
           //int randomNumber = Random.Range(0, 4);
            //collectible.GetComponent<SpriteRenderer>().color = RGBCodes[randomNumber];
            var xPos = Random.Range(minX, maxX);
            var pos = new Vector3(xPos, yPos, 0);
            collectible.transform.position = pos;

        }
    }
}
