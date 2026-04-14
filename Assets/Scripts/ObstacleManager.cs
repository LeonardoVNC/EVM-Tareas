using UnityEngine;
using UnityEngine.InputSystem;

public class ObstacleManager : MonoBehaviour
{
    public GameObject monedita;
    private Obstacle[,] grid = new Obstacle[8,8];
    private float heightUnit = 0.5f;

    void Start()
    {
        
    }

    void Update() 
    {
    }

    void Awake() {
        Obstacle[] allObstacles = GetComponentsInChildren<Obstacle>();

        foreach (Obstacle obs in allObstacles) {
            int xIndex = Mathf.RoundToInt((obs.transform.localPosition.x + 7) / 2);
            int zIndex = Mathf.RoundToInt((obs.transform.localPosition.z + 7) / 2);

            if (xIndex >= 0 && xIndex < 8 && zIndex >= 0 && zIndex < 8) {
                grid[xIndex, zIndex] = obs;
            }
        }
    }

    public void SetCubeHeight(int x, int z, int level) {
        if (grid[x, z] != null) {
            grid[x, z].Elevate(level);
        }
    }

    public void GenerateLevel(int targetX, int targetZ) {
        monedita.SetActive(false);

        for (int x = 0; x < 8; x++) {
            for (int z = 0; z < 8; z++) {
                float distance = Vector2.Distance(new Vector2(x, z), new Vector2(targetX, targetZ));
                int level = Mathf.Max(0, 5 - Mathf.RoundToInt(distance));

                if (level > 0 && level < 5) {
                    level += Random.Range(0, 2);
                }

                SetCubeHeight(x, z, level);
            }
        }

        Vector3 cubePos = grid[targetX, targetZ].transform.position;
        float targetY = 5 * heightUnit + 3.25f; 
        monedita.transform.position = new Vector3(cubePos.x, targetY, cubePos.z);
        
        monedita.SetActive(true);
    }
}
