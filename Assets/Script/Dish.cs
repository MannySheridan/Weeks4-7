using UnityEngine;

public class Dish : MonoBehaviour
{
    public float dirtiness = 100f;
    MeshRenderer meshRenderer; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        UpdateColour();
    }
    public void Clean(float amount)
    {
        dirtiness -= amount;

        if (dirtiness < 0)
        {
            dirtiness = 0;
        }

        UpdateColour();
    }
    void UpdateColour()
    {
        float cleanAmount = 1 - (dirtiness / 100f);

        rmeshRenderer.material.color = Color.Lerp(Color.black, Color.white, cleanAmount);
    }
    public bool IsClean()
    {
        return dirtiness <= 0;
    }
}
// Update is called once per frame
void Update()
    {
        
    }
}
