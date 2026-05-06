using System;
using System.Collections.Generic;
using UnityEngine;

public class ClientManager : MonoBehaviour
{
    [Header("General Variable")]
    public int _dialoguePosition = 1;

    [Header("Game Objects")]
    public GameObject _BF1;
    public GameObject _BFAngry;
    public GameObject _BF2Right;

    //[SerializeField]
    //SerializableDictionary<string, Question> questions;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _BFAngry.SetActive(false);
        _BF2Right.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void WrongOption()
    {
        _dialoguePosition++;

        if (_dialoguePosition == 2)
        {
            _BF1.SetActive(false);//lines 39 & 40 will be replaced with animation controller responses - Syd
            _BF1.SetActive(true);
            _BFAngry.SetActive(true);
            _dialoguePosition--; //The dialogue briefly jumps from position 1 to 2 to 1. This also allows the right option to be selected in the right position
        }
    }

    public void RightOption()
    {
        _dialoguePosition++;
        if (_dialoguePosition == 2)
        {
            _BFAngry.SetActive(false);
            _BF1.SetActive(false);
            _BF2Right.SetActive(true);
        }
    }

    public void EndClient()
    {
        _dialoguePosition = 1;
    }

    // This is a data packet, essentially!
    //[Serializable]
    //public class Question
    //{
    //    public GameObject client;
    //    public string question;

    //    [SerializeField]
    //    public string isRight;

    //    [SerializeField]
    //    public string isWrong;
    //}
}
