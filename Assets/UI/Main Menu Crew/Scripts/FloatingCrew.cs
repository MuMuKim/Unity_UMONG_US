using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingCrew : MonoBehaviour
{
    public EPlayerColor playerColor;

    private SpriteRenderer spriteRenderer;
    private Vector3 direction;
    private float floatingSpeed;
    private float rotateSpeed;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //크루원 스프라이트, 크루원의 색상, 날아갈 방향, 날아가는 속도, 회전방향, 크루원의 크기
    public void SetFloatingCrew(Sprite sprite, EPlayerColor playerColor, Vector3 direction, float floatingSpeed, float rotateSpeed, float size )
    {
        this.playerColor = playerColor;
        this.direction = direction;
        this.floatingSpeed = floatingSpeed;
        this.rotateSpeed = rotateSpeed;

        spriteRenderer.sprite = sprite;
        spriteRenderer.material.SetColor("_PlayerColor", PlayerColor.GetColor(playerColor));

        transform.localScale = new Vector3(size, size, size);
        //sortingOrder : 크기가 작은 크루원이 뒤로가고, 큰 크루원이 앞으로 나와서 작은 크루원을 가리게 만듬
        spriteRenderer.sortingOrder = (int)Mathf.Lerp (1, 32767, size);
    }
 
    void Update()
    {
        transform.position += direction * floatingSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler( transform.rotation.eulerAngles + new Vector3(0f, 0f, rotateSpeed));
    }
}
