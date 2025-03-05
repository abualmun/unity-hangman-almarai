using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using ArabicSupport;

public class LetterScript : MonoBehaviour
{
    public string trueLetter;
    [SerializeField] Text textBox;

    public void ShowLetter(){
        if (FindAnyObjectByType<GameController>().language == "ar"){
            transform.GetChild(0).gameObject.SetActive(true);
    // string fixedText = ArabicFixer.Fix(trueLetter, false, false);
        textBox.text = "";

        }else{
textBox.text = trueLetter;


        }
    
   }
}
