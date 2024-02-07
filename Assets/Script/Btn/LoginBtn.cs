using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginBtn : MonoBehaviour
{
    public GameObject logBtn;
    public GameObject SignBtn;

    public void ClickLoginBtn()
    {
        logBtn.SetActive(false);
    }

    public void ClickSingBtn()
    {
        SignBtn.SetActive(true);
    }

    public void SignBtnCancle()
    {
        SignBtn.SetActive(false);
    }
}
