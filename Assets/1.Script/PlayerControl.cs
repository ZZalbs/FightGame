using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    bool isDashing; // 무적판정용
    public float normalSpeed; //평소 속도
    public float dashSpeed; //대쉬속도
    float speed; //실제 적용속도

    Vector2 curPos, nextPos; //현위치 다음위치
    //상하좌우 터치 확인
    bool isUpTouch;
    bool isDownTouch;
    bool isLeftTouch;
    bool isRightTouch;

    // Start is called before the first frame update
    void Start()
    {
        isDashing = false;
        speed = normalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && !isDashing)
            StartCoroutine(Dash());
    }

    void Move()
    {
        curPos = transform.position;
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if ((isLeftTouch && h == -1) || (isRightTouch && h == 1))
            h = 0;
        if ((isUpTouch && v == 1) || (isDownTouch && v == -1))
            v = 0;

        nextPos = new Vector3(h, v, 0) * speed * Time.deltaTime;

        transform.position = curPos + nextPos;
    }

    IEnumerator Dash()
    {
        isDashing = true;
        speed = dashSpeed;
        yield return new WaitForSeconds(0.015f);
        speed = normalSpeed;
        yield return new WaitForSeconds(0.2f);
        isDashing = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Up":
                    isUpTouch = true;
                    break;
                case "Down":
                    isDownTouch = true;
                    break;
                case "Left":
                    isLeftTouch = true;
                    break;
                case "Right":
                    isRightTouch = true;
                    break;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Up":
                    isUpTouch = false;
                    break;
                case "Down":
                    isDownTouch = false;
                    break;
                case "Left":
                    isLeftTouch = false;
                    break;
                case "Right":
                    isRightTouch = false;
                    break;
            }
        }
    }
}