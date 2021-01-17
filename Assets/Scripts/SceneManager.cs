using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public int BrickWall_column;
    public int BrickWall_row;
    public float BrickWall_distance;
    public GameObject Ball;
    public float Ball_initial_velocity;

    private void Awake()
    {
        Debug.Log(this.name + ".Awake");

        // 物理エンジンの設定
        Physics.bounceThreshold = 0.1f; // デフォルト値(2) だとボールがくっつく

        // Ballの初速を設定
        var f = new Vector3(0f, -1f, 0f) * Ball_initial_velocity;
        Ball.GetComponent<Rigidbody>().AddForce(f, ForceMode.Impulse);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
