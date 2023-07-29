using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FoodCounter : MonoBehaviour
{
    public TMP_Text text;
    public float food;
    public Animator textAnim;

    private float cachedFood;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cachedFood < food)
        {
            cachedFood = food;
            textAnim.SetTrigger("Pop");
            GameObject.FindObjectOfType<Upgrades>().CheckForNewStage(food);
            text.text = food.ToString() ;

        }

        
    }
}
