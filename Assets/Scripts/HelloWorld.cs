using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    public float initNumber = 0;
    public string logText;
    [SerializeField]
    private string logText2 = "----";


    private void Awake()
    {
        Debug.Log("Awake");
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");

        Debug.Log(logText);
        Debug.Log(logText2);

        float num = initNumber;
        Debug.Log(num);

        if (num > 0)
        {
            Debug.Log("でかい");
            var a = num + 1;
            Debug.Log(a);
        }
        else if (num < 0)
        {
            Debug.Log("ちいさい");
        }
        else
        {
            Debug.Log("ぜろ");
        }

        Debug.Log("Show transforms.name");
        Transform[] transforms = GameObject.FindObjectsOfType<Transform>();
        //var transforms = GameObject.FindObjectOfType<Transform>();
        foreach (var tf in transforms)
        {
            Debug.Log(tf.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
    }
}

