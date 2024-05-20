using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winMenu : MonoBehaviour
{
  public GameObject winMenuUI;
  public NewBehaviourScript playerController;

  void Start()
  {
    playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<NewBehaviourScript>();   
    winMenuUI.SetActive(false);
  }

  void Update() {
    if(playerController.coins == 7)
    {
      winMenuUI.SetActive(true);
    }
  }
}
