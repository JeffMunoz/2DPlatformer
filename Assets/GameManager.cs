// Author: Jeffry Munoz

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isGameover = false;
    private bool isGameWon = false;
    public float restartDelay = 1f;
    
   public void endGame()
    {
        if (!isGameover)
        {
            isGameover = true;
            print("game over");
            SceneManager.LoadScene("GameOver");
            // Invoke("restartGame",restartDelay);
        }
        
    }

   public void winGame()
   {
       if (!isGameWon)
       {
           isGameWon = true;
           print("VICTORY");
           SceneManager.LoadScene("Victory");
       }
       
   }
   
   public void restartGame()
   {
       //loads the previous scene
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1 );
   }

   /*
    * Load the next level but for demo purposes it starts the same level again 
    */
   public void nextLevel()
   {
       //loads the next available scene 
      // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1 );
      SceneManager.LoadScene("Level1");
   }
}
