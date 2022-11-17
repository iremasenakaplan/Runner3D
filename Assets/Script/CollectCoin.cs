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
  public int maxScore;
  Animator PlayerAnim;
  public GameObject Player;
  public GameObject Finish;

   private void Start() 
   {
    PlayerAnim = Player.GetComponentInChildren<Animator>();

   }
    
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
         transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
         Finish.SetActive(true);
         
         if(Score >= maxScore)
         {
          //Debug.Log("you are win!!");
          PlayerAnim.SetBool("win", true);
         }
         else
         {
          //Debug.Log("you are lose!!");
          PlayerAnim.SetBool("lose", true);
         }
       }
   }

   public void RestartGame()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
