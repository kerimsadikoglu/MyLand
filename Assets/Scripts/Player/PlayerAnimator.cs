using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    [SerializeField] private Animator playerAC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ManageAnimations(Vector3 move)
    {

        if (move.magnitude > 0)
        {
            PlayerRunAnimation();
            playerAC.transform.forward = move.normalized;
        }
        else
        {
            PlayerIDLEAnimation();
        }
    }

    private void PlayerRunAnimation()
    {
        playerAC.Play("RUN");
    }
    private void PlayerIDLEAnimation()
    {
        playerAC.Play("IDLE");
    }
}
