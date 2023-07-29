using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FloatingHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    //[SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Gradient colorGradient;
    private float amount;
    public Image fill;



    public void UpdateHealthBar( float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
        //slider.maxValue = maxValue;
        fill.color = colorGradient.Evaluate(slider.value);
    }

    void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
        transform.position = target.position + offset;
    }
}
