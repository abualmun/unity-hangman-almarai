using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonsParent : MonoBehaviour
{
    string englishAlphabet = "abcdefghijklmnopqrstuvwxyz";
    string arabicAlphabet = "ابتثجحخدذرزسشصضطظعغفقكلمنهويءؤئة";
    [SerializeField] GameObject letterButtonPrebab;
    void Start()
    {
        string alphabet = (FindAnyObjectByType<GameController>().language == "ar")? arabicAlphabet:englishAlphabet;

            foreach (var letter in alphabet.ToCharArray())
            {
                TMP_Text buttonText = Instantiate(letterButtonPrebab,transform).GetComponentInChildren<TMP_Text>();
                buttonText.text = letter.ToString();
            }
        }
        
    

 
}
