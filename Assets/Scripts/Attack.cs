using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Attack : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //敌人的出战范围
    private GameObject war_p2;
    //
    public GameObject cavs;
    //拖动卡牌时，鼠标下面有一张牌跟随
    private RawImage image;
    //拖拽开始的位置
    private Vector3 draggingPlane;

    private Vector3 rect;
    private Vector2 card_size = new Vector2(80, 100);
    private Vector2 size;
    //public GameObject Sword;
    // Use this for initialization
    void Start() 
    {
        cavs = GameObject.Find("Canvas");
        
        war_p2 = GameObject.Find("op_war");
        rect = war_p2.GetComponent<Transform>().transform.position;
        size = new Vector2(Screen.width * (630f / 800f), Screen.height * (100f / 450f));
    }

    // Update is called once per frame 
    void Update()
    {

    }

    //开始拖动
    public void OnBeginDrag(PointerEventData eventData)
    {
        //draggingPlane = this.transform.position;
    }

    //拖动过程中
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
    }

    //拖动结束，判断落点是否在对方场上怪物上。
    public void OnEndDrag(PointerEventData eventData)
    {
        var mouse_vector = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        GameScene controller = cavs.GetComponent<GameScene>();
        if (mouse_vector.x <= rect.x + size.x / 2f && mouse_vector.x >= rect.x - size.x / 2f)
        {
            if (mouse_vector.y <= rect.y + size.y / 2f && mouse_vector.y >= rect.y - size.y / 2f)
            {
                for (int i = 0; i < controller.op_field_list.Count; i++)
                {
                    Debug.Log(controller.op_field_list[i].Name);
                    Debug.Log(GameObject.Find(controller.op_field_list[i].Name).GetComponent<Transform>().position);
                    
                }
            }
        }
        
    }
}
