using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Upgrades : MonoBehaviour
{

    public float[] stages;
    public int currentStage;
    public TMP_Text text;
    public GameObject choiceScreenUI;
    public GameObject upgradesPlace;
    public GameObject upgrades;
    public GameObject[] tentactles;
    public int tentactleAmount;
    public float lenght;
    public float[] dashLevels;
    public int dashLevel;
    public GameObject dashIndicator;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CheckForNewStage(float food)
    {
        text.text = stages[currentStage].ToString();        
        if (food>=stages[currentStage])
        {
            TimeManager.instance.customTimeScale = 0f;
            choiceScreenUI.SetActive(true);

            Instantiate(upgrades, upgradesPlace.transform);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < tentactles.Length; i++)
        {
            if (i<tentactleAmount)
            {
               
                tentactles[i].SetActive(true);
                tentactles[i].GetComponent<Tail>().minDist = lenght;
            }
            else
            {
                tentactles[i].SetActive(false);

            }
        }

        
        //Activate the dash energy bar once dash is unlocked
        if (dashLevel>0)
        {
            dashIndicator.SetActive(true);
        }
        
        GameObject.FindObjectOfType<Movement>().dashStrenght = dashLevels[dashLevel];
    }
}
