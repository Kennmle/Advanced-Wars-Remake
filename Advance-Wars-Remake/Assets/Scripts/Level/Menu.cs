using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Menu : MonoBehaviour {
  static int movementChoice;
  static int unitChoice;
  static GameObject movementMenu;
  static GameObject optionMenu;

  void Awake() {
    movementChoice=0;
    unitChoice=0;
  }

  void Start() {
    if(movementMenu==null)
      movementMenu=GameObject.FindWithTag("Movement Menu");
    if(optionMenu==null)
      optionMenu=GameObject.FindWithTag("Option Menu");
  }

  void Update() {

  }

  public static void movementReset() {
      movementChoice=0;
  }

  public static void movementWait() {
    movementChoice=1;
  }

  public static void movementAttack() {
    movementChoice=2;
  }

  public static void movementSelect(bool attack, string other) {
    int otherOptions=0;
    Button button = movementMenu.GetComponentInChildren<Button>();
    if(attack==true)
      otherOptions++;
    if(other!=null) //Other is "special" option for certain units
      otherOptions++;
    for(int i = 0; i<otherOptions;i++) {
      if(attack&&i==0)
        duplicate(button,"Attack",1);
      else
        duplicate(button,other,i+1);
    }
  }

  public static void movementSelect(bool attack) {
    Menu.movementSelect(attack,null);
  }

  public static void movementSelect() {
    Menu.movementSelect(true);
  }

  private static void duplicate(Button original, string text, int verticalOffset) {
    Button temp = GameObject.Instantiate(original,original.transform.parent);
    temp.GetComponentInChildren<Text>().text = text;
    Vector3 tempOffset  = new Vector3(0f,-1f,0f);
    tempOffset*= original.GetComponentInChildren<RectTransform>().localScale.y*original.GetComponentInChildren<RectTransform>().sizeDelta.y*verticalOffset;
    temp.transform.localPosition+=tempOffset;
  }

  public static int getMovementState() {
    return movementChoice;
  }

  public static void setMovementState(int x) {
    movementChoice=x;
  }

  //For some reason localPosition.z has to be -120 or lower. Need to figure out why
  public static void switchToMovement() {
    UI.hideHighlighter();
    movementMenu.transform.localPosition = new Vector3(UI.getMousePos().x,UI.getMousePos().y,-50f-70f);
  }

  public static void switchFromMovement() {
    UI.showHighlighter();
    movementMenu.transform.localPosition = new Vector3(UI.getMousePos().x,UI.getMousePos().y,50f+70f);
  }

}
