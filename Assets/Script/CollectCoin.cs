using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //textMesh e ulasmak icin
using UnityEngine.SceneManagement;

public class CollectCoin : MonoBehaviour
{
  public int Score;
  public TextMeshProUGUI CoinText;
  public PlayerController playerController;
    
   private void OnTriggerEnter(Collider other)
   {
       if(other.CompareTag("Coin"))
       {
         AddCoin();
         Destroy(other.gameObject); // coin temas halinde kaybolur
       }
       else if(other.CompareTag("End"))
       {
         Debug.Log("tebriks!!");
         playerController.runningSpeed = 0;
       }
   }

   private void OnCollisionEnter(Collision collision)
   {
       if(collision.gameObject.CompareTag("Collision"))
       {
          Debug.Log("Touched obstacle...");
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // End kismina gelince oyun tekrar baslar
       }
   }

   public void AddCoin()
   {
       Score++;
       CoinText.text = "Score: " + Score.ToString();
   }
}
