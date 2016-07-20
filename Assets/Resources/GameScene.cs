using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using LitJson;

using BasicCard;
public class GameScene : MonoBehaviour {
    GameObject card; //手牌
    GameObject Read_CardLibrary;
    int my_hp;//我方HP
    int op_hp;//敵方HP
    List<Card> my_lib_list = new List<Card>();  //牌庫    (自己的)    按收一個LIST
    public List<Card> my_hand_list = new List<Card>();  //手牌
    List<Card> my_field_list = new List<Card>();  //場上手牌
    List<Card> op_lib_list = new List<Card>();  //牌庫    (對手的)
    public List<Card> op_hand_list = new List<Card>();  //手牌
    public List<Card> op_field_list = new List<Card>();  //場上手牌

    bool offensive;   //是否先手
    bool IsWaiting = false;
    bool DrawCard_state;// 抽牌階段
    bool Battle_state;// 出牌階段
    Client network;   //按收MSG
	// Use this for initialization
	void Start () {
        network = GameObject.Find("Main Camera").GetComponent<Client>();
        DrawCard_state = false;
        Battle_state = false;
        offensive = true;
        my_lib_list = RandomSortList(test());
        //my_lib_list = test();
        if (offensive)
        {
            for(int i=0;i<3;i++)
                DrawCard();
        }
        else
        {
            for (int i = 0; i < 4; i++)
                DrawCard();
        }

	}
	
	// Update is called once per frame
	void Update () {
        if (!IsWaiting)   //非等待
        {
            if (DrawCard_state && !IsWaiting)
            {
                DrawCard();
            }
            else if (Battle_state && !IsWaiting)
            {

            }
        }
        else
        {
            Debug.Log("別人回合");  //別人回合
        }

	}

    public List<Card> RandomSortList(List<Card> List)
    {
        ArrayList nums = new ArrayList();
        List<Card> newList = new List<Card>();
        //Random random = new Random();
        while(newList.Count<5)
        {
            int temp = Random.Range(0, List.Count );  // 0號..29
            if(!nums.Contains(temp))
            {
                nums.Add(temp);
                newList.Add(List[temp]);
            }
            
        }
        return newList;
    }

    public bool DrawCard()
    {
        if (my_lib_list.Count > 0 && my_hand_list.Count < 10)
        {
            my_hand_list.Add(my_lib_list[0]);  //加牌庫頭一張牌
            card = Instantiate(Resources.Load("Cards")) as GameObject;
            card.name = my_lib_list[0].Name;
            card.GetComponent<RawImage>().texture = Resources.Load(my_lib_list[0].Img) as Texture;
            card.GetComponent<Transform>().SetParent(GameObject.Find("hand_cards_p1").GetComponent<Transform>());
            card.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
            card.GetComponent<CardData>().img_path = my_lib_list[0].Img;
            card.GetComponent<CardData>().name = my_lib_list[0].Name;
            card.GetComponent<CardData>().card = my_lib_list[0];
            my_lib_list.RemoveAt(0);            //牌庫頭扣一張牌
            return true;
        }
        else
        {
            return false;
        }

    }
    List<Card> test()
    {
        string src = "data";
        List<Card> c;
        c = new List<Card>();
        TextAsset s = Resources.Load(src) as TextAsset;
        //Debug.Log (s);
        string tmp = s.text;
        JsonData jd = JsonMapper.ToObject(tmp);
        //上面读取card的json数据

        //debug imformation
        for (int i = 0; i < jd.Count; i++)
        {
            Card temp = new Card(i.ToString(), jd[i]["name"].ToString(), jd[i]["power"].ToString(), jd[i]["atk"].ToString(), jd[i]["life"].ToString(), jd[i]["skill"].ToString(), jd[i]["png"].ToString());
            c.Add(temp);
            //Debug.Log ("card" + i.ToString () + ":   name: " + jd [i] ["name"] + ",  attack: " + jd [i] ["atk"] + ",  power:" + jd [i] ["power"].ToString () + ",  life:" + jd [i] ["power"].ToString () + ", skill:" + jd [i] ["skill"].ToString () + ",  png" + jd [i] ["png"]);
           // Debug.Log(temp.ToString());
        }
        return c;
    }
}
