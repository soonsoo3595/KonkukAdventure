using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDetailInfo : MonoBehaviour
{
    public Text userNameTxt, gradeTxt, semesterTxt, limitCreditTxt, reserveCreditTxt, reserveScoreTxt, reserveKUpointTxt;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        PlayerData player = DataMgr.player;

        userNameTxt.text = $"  이름 : {player.userName}";
        gradeTxt.text = $"  현재 학년 : {player.grade}학년";
        semesterTxt.text = $"  진행 학기 : {player.semester}학기";
        limitCreditTxt.text = $"  채울 수 있는 학점 : {player.creditLimit} 학점";
        reserveCreditTxt.text = $"  현재 획득한 학점 : {player.creditReserve} 학점";
        reserveScoreTxt.text = $"  획득한 점수 : {player.scoreReserve} 점";
        reserveKUpointTxt.text = $"  획득한 KU 포인트 : {player.KUPointReserve} 포인트";
    }
}
