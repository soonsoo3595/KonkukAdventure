using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//상점 관리를 맏는 클래스, 상품 나열, 판매 처리, 상품 업데이트 등을 담당
public class StoreManager : MonoBehaviour
{
    //아이템의 종류를 확인하는 코드가 들어갈 델리게이트
    //아이템 정보를 받아오는 타이밍이 어긋나서 만들었음
    //이게 없으면 아이템 정보를 받기 전부터 이름 같은것들을 세팅해서
    //아무런 정보를 띄우지 않음. 꼭 필요함
    public delegate void StoreChain();
    public static event StoreChain WhatIsThis;

    [SerializeField] SetItemData[] itemDatas;

    private void Awake()
    {
        Portal.SetStoreData += SetItemData;
        SetItemInfo.ItemUpdate += SetItemData;
    }

    //아이템들의 정보를 아이템 셀에 뿌려주는 메서드
    //SetItemInfo에서 델리게이트를 이용해
    //플레이어가 상품 구매후, 업데이트 할 때에 호출한다.
    public void SetItemData(ItemDataList itemDataList)
    {
        CreditLimit nowLimitItem = LimititemCheck(itemDataList.creditLimit);

        itemDatas = GetComponentsInChildren<SetItemData>();
        //0번째 셀에는 학점제한 해제 상품
        itemDatas[0].creditLimit = nowLimitItem;
        //그 외에는 샘플상품
        for (int i = 1; i < itemDatas.Length; i++)
        {
            itemDatas[i].otherItem = itemDataList.otherItem[i - 1];
        }
        //정보 전송
        //SetItemData를 통해 각 아이템 셀에서 정보를 가져간다.
        WhatIsThis();
    }

    //현재 학점 제한 아이템 해제 상품에서 제일 앞에 있는거 끌어오는 코드
    CreditLimit LimititemCheck(List<CreditLimit> creditLimit )
    {
        for(int i=0;i< creditLimit.Count; i++)
        {
            if (creditLimit[i].isPurchase.Equals(false))
            {
                return creditLimit[i];
            }
        }
        return creditLimit[9];
    }
}
