using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collission) 
    {
        if(collission.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            print("voçe pego a star");
        }
    }
}
