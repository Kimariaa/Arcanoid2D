using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusBase : MonoBehaviour
{
    GameObject player;
    public GameDataScript gameData;
    public int bonusNumber;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameData = player.GetComponent<PlayerScript>().gameData;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(new Vector3(0, -0.008f * Time.timeScale, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            BonusActivate();
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    public virtual void BonusActivate()
    {
        
        GameObject[] gameObjects;
        switch (bonusNumber)
        {
            case (1):
                gameObjects = GameObject.FindGameObjectsWithTag("Ball");
                foreach (var obj in gameObjects)
                    obj.GetComponent<Renderer>().material.color = Color.yellow;
                gameData.damage = 4;
                break;
            case (2):
                gameObjects = GameObject.FindGameObjectsWithTag("Ball");
                foreach (var obj in gameObjects)
                    obj.GetComponent<Renderer>().material.color = Color.gray;
                gameData.damage = 40;
                break;
            case (3):
                gameObjects = GameObject.FindGameObjectsWithTag("Ball");
                foreach (var obj in gameObjects)
                    obj.GetComponent<Renderer>().material.color = Color.white;
                gameData.damage = 1;
                break;
            case (4):
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().Bonus();
                break;
        }
    }

    
}
