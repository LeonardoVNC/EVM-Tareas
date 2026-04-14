using UnityEngine;
using UnityEngine.InputSystem;

public class ObstacleManager : MonoBehaviour
{
    private Obstacle[,] grid = new Obstacle[8,8];

    void Start()
    {
        
    }

    void Update() 
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame) {
            Debug.Log("Test subee");
            TestDiagonal();
        }
    
        if (Keyboard.current.rKey.wasPressedThisFrame) {
            Debug.Log("Test bajaa");
            ResetGrid();
        }
    }

    void Awake() {
        Obstacle[] allObstacles = GetComponentsInChildren<Obstacle>();

        Debug.Log("Normalizando matriz wiii");
        foreach (Obstacle obs in allObstacles) {
            int xIndex = Mathf.RoundToInt((obs.transform.localPosition.x + 7) / 2);
            int zIndex = Mathf.RoundToInt((obs.transform.localPosition.z + 7) / 2);

            if (xIndex >= 0 && xIndex < 8 && zIndex >= 0 && zIndex < 8) {
                grid[xIndex, zIndex] = obs;
            }
        }
        Debug.Log("Lista la matriz wiii");
    }

    public void SetCubeHeight(int x, int z, int level) {
        if (grid[x, z] != null) {
            grid[x, z].Elevate(level);
        }
    }



    //TEST

    void TestDiagonal() {
        for (int i = 0; i < 8; i++) {
            SetCubeHeight(i, i, i); 
        }
    }

    void ResetGrid() {
        for (int x = 0; x < 8; x++) {
            for (int z = 0; z < 8; z++) {
                SetCubeHeight(x, z, 0);
            }
        }
    }
}
