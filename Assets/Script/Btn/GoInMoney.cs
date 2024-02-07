using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoInMoney : MonoBehaviour
{
    public GameObject InBtn;
    public GameObject MoneyBtn;
    public GameObject OutBtn;
    public void InMoneyBtn()
    {
        InBtn.SetActive(true);
        MoneyBtn.SetActive(false);
    }
    public void OutMoneyBtn()
    {
        OutBtn.SetActive(true);
        MoneyBtn.SetActive(false);
    }
    public void HomeMoneyBtn()
    {
        InBtn.SetActive(false);
        OutBtn.SetActive(false);
        MoneyBtn.SetActive(true);
    }
}
