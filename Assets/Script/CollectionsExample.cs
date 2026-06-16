using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CollectionsExample : MonoBehaviour
{
    private List<string> animals;
    public SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int number = 1;
        float decimalNumber = 1.5f;
        string word = "Hello World";

        Vector3 position = new Vector3(1f, 0f, 0f);
        Color grayColor = new Color(0.3f, 03f, 0.3f, 1f);
        spriteRenderer.color = grayColor;

        animals = new List<string>();
        animals.Add("Raccon");
        //animals.Add("Dog");

        for(int i = 0; i < animals.Count; i++)
        {
            Debug.Log(animals[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
