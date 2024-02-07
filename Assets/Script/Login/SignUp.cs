using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class SignUp : MonoBehaviour
{
    public InputField loginIdInput; //아이디 로그인 필드
    public InputField passwordInput; //비밀번호 로그인 필드
    public InputField idInput; // 아이디 입력 필드
    public InputField nameInput;   // 사용자명 입력 필드
    public InputField pwInput;   // 비밀번호 입력 필드
    public InputField pwConfirmInput; //비밀번호 확인 필드
    public GameObject loginError;//로그인 에러
    public LoginBtn logBtn;
    public Text errorTxt; //회원가입 에러텍스트
    public Text nameTxt; //이름 텍스트

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
            errorTxt.text = "공백은 입력할 수 없습니다.";
            return;
        }
        if (PlayerPrefs.GetString("Id").Equals(id))
        {
            errorTxt.text = "이미 존재하는 아이디 입니다.";
            return;
        }
        check = PlayerPrefs.GetString("Name").Equals(username);
        if (check)
        {
            errorTxt.text = "이미 존재하는 이름입니다.";
            return;
        }
        if(password != pwConfirm)
        {
            errorTxt.text = "비밀번호가 일치 하지 않습니다.";
            return;
        }
        if (idLength < 3)
        {
            errorTxt.text = "아이디는 최소3자 입니다.";
            return;
        }
        if (nameLength < 2)
        {
            errorTxt.text = "이름은 최소2자 입니다.";
            return;
        }
        if (pwLength < 5)
        {
            errorTxt.text = "비밀번호는 최소5자 입니다.";
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
        //Debug.Log("아이디" + PlayerPrefs.GetString("Id").Equals(id));
        //Debug.Log("비번" + PlayerPrefs.GetString("Pw").Equals(pw));
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

