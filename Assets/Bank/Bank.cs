using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(Enemy))]

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 300;
    [SerializeField] int currentBalance;
    public int CurrentBalance { get {return currentBalance;} }
    
   [SerializeField]TextMeshProUGUI displayBalance;
   
   void Awake() 
   {
      currentBalance = startingBalance;
      UpdateDisplay();
   }

   public void Deposit(int amount)
   {
      currentBalance += Mathf.Abs(amount);
      UpdateDisplay();
   }

   public void Withdraw(int amount)
   {
      currentBalance -= Mathf.Abs(amount);
      UpdateDisplay();

      if(currentBalance < 0)
      {
         // LOSE GAME  for development  upgrade:   Progress to next scene or back to lobby.  for menu system
         ReloadScene();
      }
   }
   
   void UpdateDisplay()
   {
      displayBalance.text = "Gold: " + currentBalance;
   }

   void ReloadScene()
   {
      Scene currentScene = SceneManager.GetActiveScene();
      SceneManager.LoadScene(currentScene.buildIndex);
   }

}
