using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetItemInfo : MonoBehaviour
{
    //구매 버튼 클릭시에 상품 업데이트
    //StoreManager에 있는 SetItemData 를 가져온다.
    public delegate void UpdateStoreChain(ItemDataList itemDataList);
    public static event UpdateStoreChain StoreUpdate;

    private CreditLimit creditLimit;
    private OtherItemData otherItem;

    //아이템 구분을 위한 flag
    private bool flag;

    [SerializeField] private GameObject activePart;
    [SerializeField] private TMP_Text nameText, infoText;
    [SerializeField] private Button button;

    //구매 버튼을 눌렀을 때 활성화 되는 팝업
    [SerializeField] private GameObject purchasePopup;
    [SerializeField] private TMP_Text[] popupText;

    private void Awake()
    {
        SetItemData.ItemSelect += Active;
        popupText = purchasePopup.GetComponentsInChildren<TMP_Text>();

        activePart.SetActive(false);
    }

    private void Active(CreditLimit credit , OtherItemData other, bool checkFlag)
    {
        activePart.SetActive(true);

        //델리게이트로 받은 정보 클래스에 저장
        //버튼 클릭 메서드는 델리게이트가 아니므로
        //이게 없으면 필요한 정보를 가져올 수 없다
        creditLimit = credit;
        otherItem = other;
        flag = checkFlag;

        switch (checkFlag)
        {
            case false:
                nameText.text = otherItem.name;
                infoText.text = otherItem.itemInfo;
                break;
            case true:
                nameText.text = creditLimit.name;
                infoText.text = creditLimit.itemInfo;
                break;
        }
    }

    //구매 버튼 누를 시 작동되는 메서드
    public void Purchase()
    {
        ItemDataList itemDataList;

        switch (flag)
        {
            case false:
                //업데이트가 되지 않는 상품인경우
                //한번 구매 했을 때 활성화되는 if
                if (otherItem.isPurchase.Equals(true))
                {
                    popupText[0].text = "구매 안내";
                    popupText[1].text = "이미 구매한 상품입니다!";
                    purchasePopup.SetActive(true);
                    break;
                }
                //가지고 있는 포인트가 아이템 가격보다 작을 때
                if (DataMgr.Player.KUPointReserve < otherItem.price)
                {
                    popupText[0].text = "구매 안내";
                    popupText[1].text = "KU포인트가 부족합니다";
                    purchasePopup.SetActive(true);
                    break;
                }
                //DataMgr에 정보 업데이트
                DataMgr.Player.KUPointReserve -= creditLimit.price;
                DataMgr.Items.otherItem[otherItem.itemID].isPurchase = true;

                //간단 상태창 업데이트
                GameManager.instance.renewalPopup();

                //업데이트 된 정보를 다시 받아서
                //디스플레이 업데이트
                itemDataList = DataMgr.Items;
                StoreUpdate(itemDataList);

                //정보창 비활성화
                //정보창 업데이트 귀찮아서 이렇게 처리함
                activePart.SetActive(false);

                //구매완료 팝업 활성화
                popupText[0].text = "구매 완료";
                popupText[1].text = "구매가 완료되었습니다!";
                purchasePopup.SetActive(true);
                break;

            case true:
                //모든 상품을 구매 했을 경우 활성화되는 if
                if (creditLimit.isPurchase.Equals(true))
                {
                    popupText[0].text = "구매 안내";
                    popupText[1].text = "모든 상품을 구배하셨습니다!";
                    purchasePopup.SetActive(true);
                    break;
                }
                //가지고 있는 포인트가 아이템 가격보다 작을 때
                if (DataMgr.Player.KUPointReserve < creditLimit.price)
                {
                    popupText[0].text = "구매 안내";
                    popupText[1].text = "KU포인트가 부족합니다";
                    purchasePopup.SetActive(true);
                    break;
                }

                //DataMgr에 정보 업데이트
                DataMgr.Player.KUPointReserve -= creditLimit.price;
                DataMgr.Player.creditLimit += creditLimit.reward;
                DataMgr.Items.creditLimit[creditLimit.itemID].isPurchase = true;

                //간단 상태창 업데이트
                GameManager.instance.renewalPopup();

                //업데이트 된 정보를 다시 받아서
                //디스플레이 업데이트
                itemDataList = DataMgr.Items;
                StoreUpdate(itemDataList);

                //정보창 비활성화
                //정보창 업데이트 귀찮아서 이렇게 처리함
                activePart.SetActive(false);

                //구매완료 팝업 활성화
                popupText[0].text = "구매 완료";
                popupText[1].text = "구매가 완료되었습니다!";
                purchasePopup.SetActive(true);

                Debug.Log(DataMgr.Player.creditLimit);
                Debug.Log(DataMgr.Player.KUPointReserve);

                break;
        }
    } 
}
