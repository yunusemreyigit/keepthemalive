using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        animator.SetBool("walking", false);    
    }

    void Update()
    {
        
    }
}
