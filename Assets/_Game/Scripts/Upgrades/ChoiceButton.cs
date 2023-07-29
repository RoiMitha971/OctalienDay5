using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceButton : MonoBehaviour
{
    public GameObject[] stages;
    public GameObject choices;
    public float speed;
    public int tentactleAmoun;
    public float lenght;
    public int dashLevel;
    public float damage;

    public float regen;
    // Start is called before the first frame update
    void Start()
    {
        choices = transform.parent.gameObject;
        choices = choices.transform.parent.gameObject;
      /*  if (dashLevel != 0)
        {
            if (GameObject.FindObjectOfType<Upgrades>().dashLevel == 0)
            {
                stages[0].SetActive(true);
                stages[1].SetActive(false);
            }
            if (GameObject.FindObjectOfType<Upgrades>().dashLevel == 1)
            {
                stages[0].SetActive(false);
                stages[1].SetActive(true);
            }
        }*/
       
    }

    // Update is called once per frame
    void Update()
    {
            
    }
    public void Press()
    {
        GameObject.FindObjectOfType<Movement>().speed += speed;
        GameObject.FindObjectOfType<PlayerHealth>().regen += regen;
        Upgrades playerUpgrades = GameObject.FindObjectOfType<Upgrades>();

        playerUpgrades.tentactleAmount += tentactleAmoun;
        playerUpgrades.lenght += lenght;
        if (dashLevel != 0)
        {
            if (playerUpgrades.dashLevel == 0)
            {
                playerUpgrades.dashLevel = 1;
            }
            else if (playerUpgrades.dashLevel == 1)
            {
                playerUpgrades.dashLevel = 2;
            }

        }
        playerUpgrades.damage+=damage;

        playerUpgrades.choiceScreenUI.SetActive(false);

        TimeManager.instance.customTimeScale = 1f;
        GameObject.FindObjectOfType<Upgrades>().currentStage++;
        GameObject.FindObjectOfType<Upgrades>().CheckForNewStage(GameObject.FindObjectOfType<FoodCounter>().food);
        

        Destroy(choices);
    }
}
