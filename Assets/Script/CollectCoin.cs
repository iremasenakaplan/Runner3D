using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //textMesh e ulasmak icin

public class CollectCoin : MonoBehaviour
{
  public int Score;
  public TextMeshProUGUI CoinText;
    
   private void OnTriggerEnter(Collider other)
   {
       if(other.CompareTag("Coin"))
       {
         AddCoin();
         Destroy(other.gameObject); // coin temas halinde kaybolur
       }
   }

   private void OnCollisionEnter(Collision collision)
   {
       if(collision.gameObject.CompareTag("Collision"))
       {
          Debug.Log("Touched obstacle...");
       }
   }

   public void AddCoin()
   {
       Score++;
       CoinText.text = "Score: " + Score.ToString();
   }
}
