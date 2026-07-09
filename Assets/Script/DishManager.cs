using UnityEngine;
using UnityEngine.UI;

public class DishManager : MonoBehaviour
{
    public GameObject dishPrefab;
    public Transform spawnPoint;

    public Slider scrubSlider;

    public Text cleanlinessText;
    public Text dishCountText;

    Dish currentDish;

    float dirtTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnDish();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDish != null)
        {

            currentDish.transform.Rotate(0, 50 * Time.deltaTime, 0);


            dirtTimer += Time.deltaTime;

            if (dirtTimer >= 1f)
            {
                currentDish.dirtiness += 2f;

                if (currentDish.dirtiness > 100)
                {
                    currentDish.dirtiness = 100;
                }

                dirtTimer = 0;
            }

            cleanlinessText.text =
                "Cleanliness: " +
                (100 - currentDish.dirtiness).ToString("0") + "%";
        }
    }
    public void ScrubDish()
    {
        if (currentDish == null)
        {
            return;
        }

        float scrubAmount = scrubSlider.value;

        currentDish.Clean(scrubAmount);

        if (currentDish.IsClean())
        {
            Destroy(currentDish.gameObject);

            cleanlinessText.text = "Dish Cleaned!";

            currentDish = null;

            dishCount--;

            dishCountText.text = "Dishes: " + dishCount;
        }
    }
    public void SpawnDish()
    {
        if (currentDish == null)
        {
            GameObject newDish = Instantiate(dishPrefab,spawnPoint.position,spawnPoint.rotation);

            currentDish = newDish.GetComponent<Dish>();

            dishCount++;

            dishCountText.text = "Dishes: " + dishCount;
        }
    }
    void UpdateDishCount()
    {
        int count = FindObjectsByType<Dish>(FindObjectsSortMode.None).Length;

        dishCountText.text = "Dishes: " + count;
    }
}