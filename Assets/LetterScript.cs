using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LetterScript : MonoBehaviour
{
    public string trueLetter;
    [SerializeField] TMP_Text textBox;
//    void Start(){
//     ShowLetter();
//    }
   public void ShowLetter(){
    textBox.text = trueLetter;
   }
}
