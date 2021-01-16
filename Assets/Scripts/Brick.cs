using UnityEngine;

public class Brick : MonoBehaviour
{
    private Color[] color_list = new Color[] { Color.red, Color.green, Color.white };
    private int color_idx;
    private GameObject surface;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(this.name + ".Start");

        // メッシュの色を設定
        surface = transform.Find("Surface").gameObject;
        var surface_mesh = surface.GetComponent<MeshRenderer>();
        surface_mesh.material.color = color_list[color_idx];
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 衝突回数によってメッシュの色を変える
        color_idx++;
        if (color_idx >= color_list.Length)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            var surface_mesh = surface.GetComponent<MeshRenderer>();
            surface_mesh.material.color = color_list[color_idx];
        }
    }
}
