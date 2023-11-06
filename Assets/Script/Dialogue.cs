using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public Sprite profile;
    public string[] speechTxT;
    public string actorName;

    public LayerMask playerLayer;
    public float radious;

    private DialogueControl dc;
    bool onRadious;

     private void Start()
    {

     dc = FindObjectOfType<DialogueControl>();

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&& onRadious) 
        {
           dc.Speech(profile, speechTxT, actorName);
        }
    }
    private void FixedUpdate()
    {
        Interact();
    }
    public void Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radious, playerLayer);

        if (hit != null )
        {
            onRadious = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
        }
        else
        {
            onRadious = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radious);
    }

}