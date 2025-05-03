using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LetterButtonScript : MonoBehaviour
{


    string letter;    
    public void OnButtonPressed(){
        letter = GetComponentInChildren<TMP_Text>().text;
        
        GetComponent<Button>().image.color = FindObjectOfType<GameController>().TryLetter(letter)? Color.green:Color.red;    
        
        GetComponent<Button>().interactable = false;
    }
}
