using System;
using System.Collections.Generic;
using UnityEngine;

public class ClientManager : MonoBehaviour
{
    [Header("General Variable")]
    public int _dialoguePosition = 1;

    [Header("Game Objects")]
    public GameObject _girl1;
    public GameObject _girl2Wrong;
    public GameObject _girl2Right;

    //[SerializeField]
    //SerializableDictionary<string, Question> questions;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _girl2Wrong.SetActive(false);
        _girl2Right.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void WrongOption()
    {
        _dialoguePosition++;

        if (_dialoguePosition >= 2)
        {
            _girl1.SetActive(false);
            _girl2Wrong.SetActive(true);
            _girl2Right.SetActive(false);
        }
    }

    public void RightOption()
    {
        _dialoguePosition++;
        if (_dialoguePosition >= 2)
        {
            _girl1.SetActive(false);
            _girl2Right.SetActive(true);
            _girl2Wrong.SetActive(false);
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
