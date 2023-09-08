using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockScript : MonoBehaviour
{
    PlayerScript playerScript;
    BonusBase bonusBase;

    public GameObject textObject;
    public GameObject bonusFire;
    public GameObject bonusSteel;
    public GameObject bonusNorm;
    public GameObject bonusBomb;
    public GameObject particleEffect;
    public GameDataScript gameData;
    Text textComponent;
    public int hitsToDestroy;
    public int points;
    public float move;

    // Start is called before the first frame update
    void Start()
    {
        if (textObject != null)
        {
            textComponent = textObject.GetComponent<Text>();
            textComponent.text = hitsToDestroy.ToString();
            playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        }
        move = -0.005f;
    }

    void CreateBonus(GameObject prefab, GameObject gameObject, int retValue)
    {
        GameObject newBonus = new GameObject();
        newBonus = Instantiate(prefab, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0),Quaternion.identity);
        newBonus.AddComponent<BonusBase>();
        newBonus.GetComponent<BonusBase>().bonusNumber = retValue;
        }

    void OnCollisionEnter2D(Collision2D collision)
    {
        {
            
            if (collision.transform.name != "Ball(Clone)")
            {
                move = -move;
            }
            else
            {
                
                hitsToDestroy = hitsToDestroy - gameData.damage;
                if (hitsToDestroy <= 0)
                {
                    if (gameObject.name == "Green Block(Clone)")
                    {
                            var retValue = Random.Range(1, 5);
                            switch (retValue)
                            {
                                case (1):
                                CreateBonus(bonusFire, gameObject, 1);
                                break;
                            case (2):
                                CreateBonus(bonusSteel, gameObject, 2);
                                break;
                            case (3):
                                CreateBonus(bonusNorm, gameObject, 3);
                                break;
                            case (4):
                                CreateBonus(bonusBomb, gameObject, 4);
                                break;
                        }
                            
                    }
                    //particleEffect.GetComponent<ParticleSystem>();
                    //particleEffect.Play();
                    GameObject Puff = Instantiate(particleEffect, this.gameObject.transform.position, Quaternion.identity);
                    Destroy(gameObject);
                    playerScript.BlockDestroyed(points);

                }
                else if (textComponent != null)
                    textComponent.text = hitsToDestroy.ToString();
                
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "Yellow Block(Clone)")
        {
            this.transform.Translate(new Vector3(move* Time.timeScale, 0, 0));
        }

    }
}
