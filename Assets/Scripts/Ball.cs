using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(this.name + ".OnCollisionEnter");
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log(this.name + ".OnCollisionStay");
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log(this.name + ".OnCollisionExit");
    }
}
