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

        // Brickプレファブをインスタンス化
        var prefab = (GameObject)Resources.Load("Brick");
        var prefab_size = prefab.transform.lossyScale;
        var wall_top_pos = new Vector3(-prefab_size.x * (BrickWall_column - 1) / 2, BrickWall_distance, 0f);
        for (int j = 0; j < BrickWall_row; j++)
        {
            for (int i = 0; i < BrickWall_column; i++)
            {
                var position = wall_top_pos + Vector3.Scale(prefab_size, new Vector3(i, j, 0f));
                var obj = GameObject.Instantiate(prefab, position, Quaternion.identity);
                obj.SetActive(true);
            }
        }

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
