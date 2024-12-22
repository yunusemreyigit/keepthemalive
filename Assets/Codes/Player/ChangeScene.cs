using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public LayerMask layerMask;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Door") && ((1 << other.gameObject.layer) & layerMask) != 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                SceneManager.LoadScene(other.gameObject.name);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Door") && ((1 << other.gameObject.layer) & layerMask) != 0)
        {
            print(other.tag);
            if (Input.GetKeyDown(KeyCode.Space))
                SceneManager.LoadScene(other.gameObject.name);
        }
    }
}
