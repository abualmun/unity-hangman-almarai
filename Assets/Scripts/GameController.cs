using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
using ArabicSupport;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    string sentence;
    string[] words;
    [SerializeField] HorizontalLayoutGroup wordSlots;
    [SerializeField] GameObject wordPrefab;
    [SerializeField] GameObject letterPrefab;
    [SerializeField] float spaceBetweenWords;
    int healthPoints = 4;
    int score = 0;
    [SerializeField] Animator kidsAnimator;
    [SerializeField] Animator glassAnimator;
    public string language = "ar";
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject loseScreen;
    bool gameEnded = false;
    [SerializeField] AudioClip[] clips;
    AudioSource audioSource;
    [SerializeField] Animator milkAnimator;
    [SerializeField] Animator cowAnimator;
    int winScore;
    [SerializeField] Sprite englishWin;
    [SerializeField] Sprite arabicWin; 
    
    // Start is called before the first frame update
    void Start()
    {
            audioSource = GetComponent<AudioSource>();
    }

    public void GenerateSlots(bool arabic){

        if (arabic){
            language = "ar";
            winScore = 8;
            sentence = ReverseString("شرب الحليب سر اللبيب");
            
        } else {
            language = "en";
            winScore = 16;
            sentence = "drinking milk makes you think";
            wordSlots.transform.localScale = new Vector3(.62f,.9f,.9f);
        }
        words = sentence.Split(" ");
        
        int lettersBeforeThisWord = 0;
        foreach (string _word in words)
        {

            Transform newWord = Instantiate(wordPrefab,wordSlots.transform).transform;
            newWord.GetComponent<HorizontalLayoutGroup>().padding.left = (int)(letterPrefab.GetComponent<RectTransform>().rect.width*spaceBetweenWords * lettersBeforeThisWord);
            foreach (char c in _word)
            {
                LetterScript letter = Instantiate(letterPrefab,newWord).GetComponent<LetterScript>();
                letter.trueLetter = ArabicFixer.Fix(c.ToString());
            }
            lettersBeforeThisWord += _word.Length;
        }
    }

    public bool TryLetter(string letter){
        // string letter = debugText.text;
        bool correct = false;
        int i = 0;
        foreach (string word in words)
        {   

            string _word = word; 
            int charsRemoved = 0;
            while(_word.IndexOf(letter) != -1){            
                
            int charIndex = _word.IndexOf(letter) + charsRemoved;
            wordSlots.transform.GetChild(i).GetChild(charIndex).GetComponent<LetterScript>().ShowLetter();
            correct = true;
            _word = _word.Remove(_word.IndexOf(letter),1);
            charsRemoved++;
            }
            i++;
        }
        if(correct){
            RightAnswer();
        }
        else{
            WrongAnswer();
        }
        return correct;
    }

    void RightAnswer(){
        kidsAnimator.Play("Celebrate");
        score++;

        audioSource.clip = clips[1];
        audioSource.Play();
        if (score == winScore){
            Win();
        }
    }
    void WrongAnswer(){
        glassAnimator.SetTrigger("wrong");
        milkAnimator.Play("pour");
        cowAnimator.Play("cow");
        kidsAnimator.Play("Sad");
        healthPoints--;
        audioSource.clip = clips[0];
        audioSource.Play();
        
        if(healthPoints == 0){
            Lose();
        }
    }
    void Win(){
    if (language == "ar")   winScreen.GetComponentInChildren<SpriteRenderer>().sprite = arabicWin;
    if (language == "en")   winScreen.GetComponentInChildren<SpriteRenderer>().sprite = englishWin;

    gameEnded = true;
    kidsAnimator.Play("Win");
    winScreen.SetActive(true);
    
        audioSource.clip = clips[2];
        audioSource.Play();
    }
    void Lose(){
        loseScreen.SetActive(true);
            gameEnded = true;
            audioSource.clip = clips[3];
        audioSource.Play();
        kidsAnimator.Play("Lose");
    }

    public void ReloadScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public string ReverseString(string stringToReverse)
    {
        string reversedString = "";

        for(int i = stringToReverse.Length - 1; i >= 0; i--)
        {
            reversedString += stringToReverse[i];
        }

        return reversedString;
    }
}
