using UnityEngine;
using System.Collections;

public class spawn : MonoBehaviour
{
   [Header("Tribe Members Settings")]
    public GameObject[] tribeMemberPrefabs; // Множественное число для массивов
    public Transform[] spawnPoints;
    [SerializeField] private int initialCount = 1; // SerializeField для приватных полей
    
    [Header("Level Settings")]
    public GameObject[] levelFloors; // Единый стиль именования
    public int currentLevel = 0; // Более понятное название
    public float floorOffset = 307f; // float вместо int для позиций
    
    private Vector3 _currentFloorPosition;
    private int _lastTribeIndex = -1; // Более понятное название
    
    private void Start()
    {
        _currentFloorPosition = levelFloors[0].transform.position;
        SpawnTribeMembers();
    }
    
    private void SpawnTribeMembers()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int membersToSpawn = Mathf.Min(initialCount + i, spawnPoints.Length); // Постепенное увеличение
            
            for (int j = 0; j < membersToSpawn; j++)
            {
                SpawnSingleMember(spawnPoints[i]);
            }
        }
    }
    
    private void SpawnSingleMember(Transform spawnPoint)
    {
        int randomIndex = GetRandomTribeIndex();
        Instantiate(tribeMemberPrefabs[randomIndex], spawnPoint.position, spawnPoint.rotation);
        _lastTribeIndex = randomIndex;
    }
    
    private int GetRandomTribeIndex()
    {
        int randomIndex;
        do {
            randomIndex = Random.Range(0, tribeMemberPrefabs.Length);
        } while (randomIndex == _lastTribeIndex && tribeMemberPrefabs.Length > 1); // Защита от бесконечного цикла
        
        return randomIndex;
    }
    
    public void LoadNextLevel()
    {
        currentLevel++;
        Vector3 newFloorPosition = new Vector3(
            _currentFloorPosition.x - floorOffset, 
            _currentFloorPosition.y, 
            _currentFloorPosition.z
        );
        
        int randomFloorIndex = Random.Range(0, levelFloors.Length);
        Instantiate(levelFloors[randomFloorIndex], newFloorPosition, Quaternion.identity);
        
        StartCoroutine(LevelTransitionCoroutine());
    }
    
    private IEnumerator LevelTransitionCoroutine() // Более точное название
    {
        yield return new WaitForSeconds(5f);
        
        // Удаляем только старый этаж, если он существует
        if (currentLevel > 0 && levelFloors.Length > 0)
        {
            Destroy(levelFloors[0]);
            // Сдвигаем массив
            for (int i = 1; i < levelFloors.Length; i++)
            {
                levelFloors[i-1] = levelFloors[i];
            }
            System.Array.Resize(ref levelFloors, levelFloors.Length - 1);
        }
        
        floorOffset += 307f;
        _currentFloorPosition.x -= floorOffset;
    }
}
