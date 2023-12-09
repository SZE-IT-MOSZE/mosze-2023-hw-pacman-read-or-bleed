using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject[] itemPrefabs;
    public GameObject largeFloor;
    public int numberOfItems = 10;

    void Start()
    {
        GenerateItems();
    }

    public void GenerateItems()
    {
        // Get the bounds of the large floor object
        Renderer floorRenderer = largeFloor.GetComponent<Renderer>();
        Bounds floorBounds = floorRenderer.bounds;

        for (int i = 0; i < numberOfItems; i++)
        {
            // Randomly choose X and Y coordinates within the bounds of the large floor object
            float randomX = Random.Range(floorBounds.min.x, floorBounds.max.x);
            float randomY = Random.Range(floorBounds.min.y, floorBounds.max.y);

            // Fixed Z coordinate (adjust as needed)
            Vector3 randomFloorPosition = new Vector3(
                randomX, // Randomized X-coordinate
                randomY, // Randomized Y-coordinate
                0.0f // Fixed Z-coordinate
            );

            // Randomly choose an item prefab
            GameObject randomItemPrefab = itemPrefabs[Random.Range(0, itemPrefabs.Length)];

            // Instantiate the item prefab at the chosen floor position
            Instantiate(randomItemPrefab, randomFloorPosition, Quaternion.identity);

            // Debug log to print the position of each instantiated item
            Debug.Log("Item Position: " + randomFloorPosition);
        }
    }
}
