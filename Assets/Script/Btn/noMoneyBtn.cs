using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noMoneyBtn : MonoBehaviour
{
    public GameObject NoBtn;
    public void NoMoneyBtn()
    {
        NoBtn.SetActive(true);
    }
    public void OkMoneyBtn()
    {
        NoBtn.SetActive(false);
    }
}
