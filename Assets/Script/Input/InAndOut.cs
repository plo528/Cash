using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InAndOut : MonoBehaviour
{
    [SerializeField] private Text txtCash;
    [SerializeField] private Text txtMoney;
    [SerializeField] private InputField inputTxtMoney;
    [SerializeField] private InputField outputTxtMoney;
    [SerializeField] public GameObject NoBtn;
    public int Cash = 100000;
    public int Money = 50000;
    public int BtnMoney = 0;
    void Start()
    {
        
    }
    public void Input() //입금
    {
        if(Cash < int.Parse(inputTxtMoney.text))
        { 
            NoBtn.SetActive(true);
            return;
        }
        else
        {
            Cash -= int.Parse(inputTxtMoney.text);
            Money += int.Parse(inputTxtMoney.text);
            txtCash.text = string.Format("{0:#,0}", Cash);
            txtMoney.text = string.Format("{0:#,0}", Money);
        }
    }

    public void Output() //출금
    {
        if (Money < int.Parse(outputTxtMoney.text))
        {
            NoBtn.SetActive(true);
            return;
        }
        else
        {
            Cash += int.Parse(outputTxtMoney.text);
            Money -= int.Parse(outputTxtMoney.text);
            txtCash.text = string.Format("{0:#,0}", Cash);
            txtMoney.text = string.Format("{0:#,0}", Money);
        }
    }

    public void SetBtn1()
    {
        BtnMoney = 10000;
    }
    public void SetBtn3()
    {
        BtnMoney = 30000;
    }
    public void SetBtn5()
    {
        BtnMoney = 50000;
    }
    public void BtnInput() //입금버튼
    {
        if (Cash < BtnMoney)
        {
            NoBtn.SetActive(true);
            return;
        }
        else
        {
            Cash -= BtnMoney;
            Money += BtnMoney;
            txtCash.text = string.Format("{0:#,0}", Cash);
            txtMoney.text = string.Format("{0:#,0}", Money);
        }
    }

    public void BtnOutput() //출금버튼
    {
        if (Money < BtnMoney)
        {
            NoBtn.SetActive(true);
            return;
        }
        else
        {
            Cash += BtnMoney;
            Money -= BtnMoney;
            txtCash.text = string.Format("{0:#,0}", Cash);
            txtMoney.text = string.Format("{0:#,0}", Money);
        }
    }
}
