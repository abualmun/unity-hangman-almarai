using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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

                if(letter == 's' ||letter == 'i' ||letter == 'r' ||letter == 'y' ||letter == 'ر'||letter == 'ب'){
                    buttonText.transform.parent.GetComponent<Button>().interactable = false;

                    buttonText.transform.parent.GetComponent<Button>().image.color = Color.green;
                }

            }
        }
        
    

 
}
