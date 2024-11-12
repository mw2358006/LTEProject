using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 진행순서 : Awake > Start > Update > FixedUpdate */

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /* 단타 or 판정 같은 곳에서 사용 */
    void Update()
    {
        // 버튼에서 손을 뗐을 때 정지
        if(Input.GetButtonUp("Horizontal"))
        {
            /* normalized : 벡터 크기를 1로 만듦(단위벡터 상태) */
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        // 방향 전환
        if(Input.GetKeyDown("Horizontal"))
        {
            /* FlipX : 스프라이트의 X축을 뒤집기 */
        }
    }

/* 1초에 60번 정도 출력 */
    void FixedUpdate()
    {
        /* Horizontal : 가로 이동(2D 기준 X축) */
        /* Vertical : 세로 이동 (2D 기준 Y축) */
        float height = Input.GetAxisRaw("Horizontal"); // 속도 입력
        // Debug.Log("height 입력 : " + height);

        /* AddForce : 물리 오브젝트를 이동하거나, 이동속도 또는 방향을 변경할 때 사용하는 함수 */
        rigid.AddForce(Vector2.right * height, ForceMode2D.Impulse);

        /* velocity : Rigidbody의 현재 속도. 자료형은 Vector */
        if(rigid.velocity.x > maxSpeed) // 오른쪽 최대속도 도달시
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }
        else if(rigid.velocity.x) // 왼쪽 최대 속도 도달시
        {
            
        }

        /* Mathf.Abs : 절댓값을 구하는 함수. */
        Debug.Log("현재 속도 : " + Mathf.Abs(rigid.velocity.x));
    }
}
