using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -0.1f, 0));

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    // 아래 함수를 추가 합니다.
    // 이 함수는 미리 정의되어 있는 함수로 똑같이 따라서 써주셔야 합니다.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 폭탄이 주인공에 맞았다면 폭탄이 사라야겠죠?
        // 폭탄을 없애주는 코드 입니다.
        Debug.Log("Bomb");
        Destroy(gameObject);
    }
}
