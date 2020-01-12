using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{


    [SerializeField] GameObject spawnZone;
    [SerializeField] Text textDisplay;
    [SerializeField] List<GameObject> dogs;
    [SerializeField] List<Vector2> spawnPositions;
    Renderer spawnZoneRenderer;
    private float totalHeldTime;
    public float TotalHeldTime {
        get { return totalHeldTime; }
        set {
            totalHeldTime = value;
            UpdateHud((int)value);
            TrySpawnDog();
        }
    }

    private float dogSpawnTimer = 0f;
    // Start is called before the first frame update
    void Start() {
        spawnZoneRenderer = spawnZone.GetComponent<Renderer>();
    }

    public void IncreaseHeldTime(float amount) {
        TotalHeldTime += amount;
        dogSpawnTimer += amount;
    }

    void TrySpawnDog() {
        int flooredDogTimer = Mathf.FloorToInt(dogSpawnTimer);
        if (flooredDogTimer > 1 && flooredDogTimer % 30 == 0) {
            int randomDogInt = Random.Range(0, dogs.Count);
            var dog = dogs[randomDogInt];
            GameObject.Instantiate(dog, RandomInitialSpawn(), Quaternion.identity);
            dogSpawnTimer = 0f;
        }
    }

    void UpdateHud(int toDisplay) {
        textDisplay.text = "points: " + toDisplay;
    }

    public Vector2 RandomInitialSpawn() {
        int randomDogSpawn = Random.Range(0, spawnPositions.Count);
        return spawnPositions[randomDogSpawn];
  }

    public Vector3 RandomDestination() {
        float width = spawnZoneRenderer.bounds.size.x / 2;
        float height = spawnZoneRenderer.bounds.size.y / 2;
        return new Vector3(Random.Range(spawnZone.transform.position.x - width, spawnZone.transform.position.x + width), Random.Range(spawnZone.transform.position.y - height, spawnZone.transform.position.y + height));
    }

}
