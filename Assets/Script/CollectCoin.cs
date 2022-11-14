using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    
   private void OnTriggerEnter(Collider other)
   {
       if(other.CompareTag("Coin"))
       {
         Destroy(other.gameObject); // coin temas halinde kaybolur
       }
   }
}
