using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesChoice : MonoBehaviour
{
    public GameObject[] buttons;
    public GameObject[] places;

    public GameObject[] selected;
    // Start is called before the first frame update
    void Start()
    {        for (int i = 0; i < places.Length; i++)
        {
            int choice = Random.Range(0, buttons.Length);
            bool resetChoice = true;
            while (resetChoice==true)
            {
                resetChoice = false;
                for (int h = 0; h < i; h++)
                {
                    if (selected[h] == buttons[choice]||(GameObject.FindObjectOfType<Upgrades>().dashLevel==2&&choice==3))
                    {
                        resetChoice = true;
                    }
                }
                if (resetChoice==true)
                {
                    choice = Random.Range(0, buttons.Length);
                }
            }

            selected[i] = buttons[choice];
            Instantiate(buttons[choice],places[i].transform);

        }
        StartCoroutine(SpawnUpgradesWithDelay());
    }

    IEnumerator SpawnUpgradesWithDelay()
    {
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("Test"+i);
            yield return new WaitForSeconds(0.5f);
        }
        
    }

  
}
