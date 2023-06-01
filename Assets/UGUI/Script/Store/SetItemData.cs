using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetItemData : MonoBehaviour
{
    //아이템 클릭시에 아이템 정보 및 구매버튼 활성화
    public delegate void ItemSelecteChain(CreditLimit creditLimit , OtherItemData otherItem, bool checkFlag);
    public static event ItemSelecteChain itemSelect;

    //StoreManager에서 접근하기 위해 internal
    [SerializeField]internal CreditLimit creditLimit;
    [SerializeField]internal OtherItemData otherItem;

    //아이템의 상품이 어떤 상품인지 알려주는 변수
    private bool flag;

    private void Awake()
    {
        StoreManager.WhatIsThis += WhatThisItem;
    }

    //해당 상품의 종류를 확인하는 메서드
    void WhatThisItem()
    {
        if (creditLimit.itemTypeID.Equals(0)) flag = false;
        else flag = true;

        TMP_Text[] text = GetComponentsInChildren<TMP_Text>();

        switch (flag)
        {
            case false:
                text[0].text = otherItem.name;
                text[1].text = $"{otherItem.price}";
                break;
            case true:
                text[0].text = creditLimit.name;
                text[1].text = $" {creditLimit.price}";
                break;
        }
    }

    //탭 클릭 시에 SetItemInfo 에 아이템 정보 전송
    public void OnButtonClick()
    {
        itemSelect(creditLimit, otherItem, flag);
    }
}
