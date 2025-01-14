using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerDetailInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text userNameTxt, gradeTxt,limitCreditTxt, information, scoreGrade;

    [Header("졸업안내")]
    [SerializeField] private TMP_Text navigateGradu;
    [SerializeField] private TMP_Text  graduatePoint;
    [SerializeField] private Image graduProgressBar;

    [Header("progress")]
    [SerializeField] private Image semesterProgressBar;

    void OnEnable()
    {
        PlayerData player = DataMgr.Player;
        PlayerRecordData record = DataMgr.Record;

        userNameTxt.text = $" {player.userName}";
        gradeTxt.text = $"{player.grade}학년 {DataMgr.Player.semester/2+1}학기";
        limitCreditTxt.text = $"{player.creditReserve} / {player.creditLimit}";
        navigateGradu.text = $"{record.totalCredit} / {record.graduateCredit}";
        graduatePoint.text = $"{record.graduateCredit}";
        //졸업까지 프로그래스 바
        graduProgressBar.fillAmount = record.totalCredit / (float)record.graduateCredit;
        //학기 진행 프로그래스 바
        semesterProgressBar.fillAmount = (float)player.creditReserve / player.creditLimit;
        //플레이어 상세 정보
        information.text = $"{player.grade * player.semester}\n{player.KUPointReserve}\n\n{record.totalCredit}\n{player.scoreReserve}\n{record.totalKupoint}";
        ScoreGrade(player.scoreReserve);
    }

    //평점 계산
    private void ScoreGrade(int score)
    {
        switch (score)
        {
            case 0: 
                scoreGrade.text = "F";
                break;
            case 4: 
                scoreGrade.text = "D";
                break;
            case 8:
                scoreGrade.text = "D";
                break;
            case 12:
                scoreGrade.text = "C";
                break;
            case 16:
                scoreGrade.text = "B";
                break;
            case 20:
                scoreGrade.text = "A";
                break;
        }
    }
}
