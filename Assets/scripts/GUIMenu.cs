using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;

public class GUIMenu : MonoBehaviour
{
  public GameObject ScreenObject;
  public NewBehaviourScript playerController;
  public TMP_Text timeText;

  void Start()
  {
      playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<NewBehaviourScript>();   
      ScreenObject.SetActive(true); // GUI Should always be active
      StartCoroutine(TimeRoutine());
  }

  // Update is called once per frame
  void Update()
  {   
  }

  public IEnumerator TimeRoutine() {
    // prepare the coroutine
    string[] parts = timeText.text.Split(":");
    
    int number = int.Parse(parts[parts.Length - 1]);
    string prefix = "";
    for (int i = 0; i < parts.Length - 1; i++) {
      prefix += parts[i];
    }

    while(number > 0) {
      yield return new WaitForSeconds(1);
      number--;
      timeText.text = prefix + ": " + number.ToString();
    }
  }
}
