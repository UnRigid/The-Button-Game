using UnityEngine;
using System.Threading.Tasks;

public class BallSpawner : MonoBehaviour
{

    public static BallSpawner instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
    }

    bool GameHasntEnded = true;
    [SerializeField] float Step = 2f;
    [SerializeField] float DelayInSecs = 1f;
    [SerializeField] private GameObject ball;


    private void Start()
    {
        Spawn();
    }

    private void CreateBall(float Delta)
    {
        Instantiate(ball, new Vector3(transform.position.x + Delta, transform.position.y, transform.position.z), transform.rotation);
    }

    async void Spawn()
    {
        while (GameHasntEnded)
        {
            int randNum = Random.Range(1, 10);
            float[] SpawnedPositions = new float[randNum];
            for (int i = 0; i < randNum; i++)
            {
                SpawnedPositions[i] = 1000;
            }
            for (int i = 0; i < randNum; i++)
            {
                bool canSpawn = true;
                int MaxCount = (int)(12 / Step);
                int Position = Random.Range(-MaxCount, MaxCount + 1);
                for (int j = 0; j < randNum; j++)
                {
                    if (Position == SpawnedPositions[j])
                    {
                        canSpawn = false;
                    }
                }
                if (canSpawn)
                {
                    SpawnedPositions[i] = Position;
                    CreateBall(Step * Position);
                }

            }

            await Task.Delay((int)(DelayInSecs * 1000));
        }
        
    }

    private void OnDestroy() {
        GameHasntEnded = false;
    }

}
