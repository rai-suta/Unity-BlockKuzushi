using UnityEngine;

public class ReflectBar : MonoBehaviour
{
    public string AxisName;
    public float MoveSpeed;

    [System.NonSerialized]
    Vector3 MoveVector;

    void FixedUpdate()
    {
        // ユーザー入力を反映
        var input = Input.GetAxis(AxisName);
        var v = MoveVector * Time.fixedDeltaTime;
        this.transform.Translate(v * input);
    }

    // Start is called before the first frame update
    void Start()
    {
        // 移動方向の軸を設定
        switch (AxisName)
        {
            case "Horizontal":
                MoveVector = Vector3.right * MoveSpeed;
                break;
            case "Vertical":
                MoveVector = Vector3.up * MoveSpeed;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        // 反射方向を中心位置から求める
        var this_tf = GetComponent<Transform>();
        var other_tf = other.gameObject.GetComponent<Transform>();
        var distance = other_tf.position - this_tf.position;
        var distance_n = distance.normalized;

        // 反射対象の速度を求める
        var other_rb = other.gameObject.GetComponent<Rigidbody>();
        other_rb.velocity = other_rb.velocity.magnitude * distance_n;
    }
}
