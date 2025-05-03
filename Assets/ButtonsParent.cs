using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsParent : MonoBehaviour
{
    string englishAlphabet = "abcdefghijklmnopqrstuvwxyz";
    string arabicAlphabet = "ابتثجحخدذرزسشصضطظعغفقكلمنهوي";
    [SerializeField] GameObject letterButtonPrebab;
    public Sprite[] arabicAlphabetSprites;
    public Sprite[] englishAlphabetSprites;
    void Start()
    {
        string alphabet = (FindAnyObjectByType<GameController>().language == "ar")? arabicAlphabet:englishAlphabet;
            int i = 0;
            foreach (var letter in alphabet.ToCharArray())
            {
                Image buttonText = Instantiate(letterButtonPrebab,transform).GetComponent<Image>();
                buttonText.GetComponentInChildren<TMP_Text>().text = letter.ToString();
                buttonText.sprite = (FindAnyObjectByType<GameController>().language == "ar")? arabicAlphabetSprites[i]:englishAlphabetSprites[i];
                if(letter == 's' ||letter == 'i' ||letter == 'r' ||letter == 'y' ||letter == 'ر'||letter == 'ب'){
                    buttonText.transform.GetComponent<Button>().interactable = false;

                    buttonText.transform.GetComponent<Button>().image.color = Color.green;
                }
            i++;
            }
        }
        
    

 
}
