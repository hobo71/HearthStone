using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using BasicCard;

public class ThrowCard : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler,IPointerEnterHandler
{
    int speed = 10;
    private float delay = 0.2f;
    GameObject war;
    Vector3 rect;
    Vector2 Size;
    GameObject card;
    Animator avatar;
    // 按?是否是按下??  
    private bool isDown = false;
    GameObject gs;
    // 按?最后一次是被按住???候的??  
    private float lastIsDownTime; 
	// Use this for initialization
	void Start () {
        avatar = GetComponent<Animator>();
        war = GameObject.Find("war");
        rect = war.GetComponent<Transform>().transform.position;
        Size = new Vector2(Screen.width * (630f / 800f), Screen.height * (100f / 450f));

        gs = GameObject.Find("Canvas");
        Debug.Log(gs.GetComponent<GameScene>().my_hand_list[0].Img);

	}
	
	// Update is called once per frame
    void Update()
    {

        if (isDown)
        {

            if (Time.time - lastIsDownTime > delay)
            {

                lastIsDownTime = Time.time;

            }
        }
        

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log(this);
        
        //controller.my_hand_list.Remove();
        isDown = true;
        lastIsDownTime = Time.time;
        

    }

    public void OnPointerUp(PointerEventData eventData)
    {

        if (Input.mousePosition.x <= rect.x + Size.x / 2f && Input.mousePosition.x >= rect.x - Size.x / 2f)
            if (Input.mousePosition.y <= rect.y + Size.y / 2f && Input.mousePosition.y >= rect.y - Size.y / 2f)
            {
                GameScene controller = gs.GetComponent<GameScene>();
                card = Instantiate(Resources.Load("NewCards")) as GameObject;
                card.GetComponent<Transform>().SetParent(GameObject.Find("war").GetComponent<Transform>());
                card.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
                card.GetComponent<RawImage>().texture = Resources.Load(GetComponent<CardData>().img_path) as Texture;
                gs.GetComponent<GameScene>().my_hand_list.Remove(GetComponent<CardData>().card);
                GameObject obj = GameObject.Find(GetComponent<CardData>().name);
                Destroy(obj);
                Debug.Log(gs.GetComponent<GameScene>().my_hand_list.Count);
            }
        isDown = false;
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        isDown = false;
        GetComponent<Animation>().Play("Smaller");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Animation>().Play("Scale");
        

        
    }

}
