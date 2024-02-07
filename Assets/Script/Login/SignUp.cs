using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class SignUp : MonoBehaviour
{
    public InputField loginIdInput; //���̵� �α��� �ʵ�
    public InputField passwordInput; //��й�ȣ �α��� �ʵ�
    public InputField idInput; // ���̵� �Է� �ʵ�
    public InputField nameInput;   // ����ڸ� �Է� �ʵ�
    public InputField pwInput;   // ��й�ȣ �Է� �ʵ�
    public InputField pwConfirmInput; //��й�ȣ Ȯ�� �ʵ�
    public GameObject loginError;//�α��� ����
    public LoginBtn logBtn;
    public Text errorTxt; //ȸ������ �����ؽ�Ʈ
    public Text nameTxt; //�̸� �ؽ�Ʈ

    public void RegisterUser()
    {
        string id = idInput.text;
        string username = nameInput.text;    
        string password = pwInput.text; 
        string pwConfirm = pwConfirmInput.text;
        int idLength = id.Length;
        int nameLength = username.Length;
        int pwLength = password.Length;
        bool check;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(id) || string.IsNullOrEmpty(pwConfirm))
        {
            errorTxt.text = "������ �Է��� �� �����ϴ�.";
            return;
        }
        if (PlayerPrefs.GetString("Id").Equals(id))
        {
            errorTxt.text = "�̹� �����ϴ� ���̵� �Դϴ�.";
            return;
        }
        check = PlayerPrefs.GetString("Name").Equals(username);
        if (check)
        {
            errorTxt.text = "�̹� �����ϴ� �̸��Դϴ�.";
            return;
        }
        if(password != pwConfirm)
        {
            errorTxt.text = "��й�ȣ�� ��ġ ���� �ʽ��ϴ�.";
            return;
        }
        if (idLength < 3)
        {
            errorTxt.text = "���̵�� �ּ�3�� �Դϴ�.";
            return;
        }
        if (nameLength < 2)
        {
            errorTxt.text = "�̸��� �ּ�2�� �Դϴ�.";
            return;
        }
        if (pwLength < 5)
        {
            errorTxt.text = "��й�ȣ�� �ּ�5�� �Դϴ�.";
            return;
        }

        PlayerPrefs.SetString("Id", id);
        PlayerPrefs.SetString("Name", username);
        PlayerPrefs.SetString("Pw", password);
        PlayerPrefs.Save();
        //Debug.Log(PlayerPrefs.GetString("Id"));
        //Debug.Log(PlayerPrefs.GetString("Name"));
        //Debug.Log(PlayerPrefs.GetString("Pw"));
        //Debug.Log(check); 

        logBtn.SignBtnCancle();
    }

    public void Login()
    {
        string id = loginIdInput.text;
        string pw = passwordInput.text;
        //Debug.Log(PlayerPrefs.GetString("Id"));
        //Debug.Log(PlayerPrefs.GetString("Name"));
        //Debug.Log(PlayerPrefs.GetString("Pw"));
        //Debug.Log("���̵�" + PlayerPrefs.GetString("Id").Equals(id));
        //Debug.Log("���" + PlayerPrefs.GetString("Pw").Equals(pw));
        if (PlayerPrefs.GetString("Id").Equals(id) && PlayerPrefs.GetString("Pw").Equals(pw))
        {
            loginError.SetActive(false);
            nameTxt.text = PlayerPrefs.GetString("Name");
            logBtn.ClickLoginBtn();
        }
        else
        {
            loginError.SetActive(true);
        }
    }
}

