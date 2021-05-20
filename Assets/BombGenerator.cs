using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombGenerator : MonoBehaviour
{
    // 여기서 public 으로 만든 변수는 에디터에 있는 오브젝트와 연결하거나 값을 에디터에서
    // 넣어 줄수 있습니다.
    // 코딩을 하지 않고 속도, 생명등 게임에서 데이터가 되는 값은 이와같이 만들어서
    // 다시 코드창을 오지 않아도 수정할수 있습니다.
    public GameObject startPos;
    public GameObject endPos;

    public GameObject bomb;
    public float interval;

    float timer;

    // 폭탄을 멈추게할 상태를 추가합니다.
    bool isGameover;

    // Start is called before the first frame update
    void Start()
    {
        timer = interval;

        // 게임을 시작할때는 폭탄을 생성해야하기 때문에 false 상태로 만들어 줍니다.
        isGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 게임 오버가 된 상태라면 아무것도 하지 않도록
        // 상태를 체크하고 함수를 끝내줍니다.
        if (isGameover == true)
        {
            return;
        }

        // interval에서 설정한 값에 따라 호출하는 타이머코드 입니다.
        // interval = 2 로 설정한다면 2초에 한번씩 조건을 만족해서 호출합니다.
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            // x 좌표를 랜덤으로 만드는 함수 입니다.
            // Random.Range(min, max) 와 같은 형식이고
            // min, max 안에 랜덤한 값을 만들어 주는 함수로 우리는 조금전에 만든
            // Object 2개를 사용하겠습니다.
            float randomX = Random.Range(startPos.transform.position.x, endPos.transform.position.x);

            // Instantiate 함수는 Instantiate(Object, position) 과 같은 형태입니다.
            // Object를 position에 만들어주는 함수로 우리가 조금전에 에디터에서 Object를 만드는것과
            // 동일한 작업을 합니다.
            // 우리는 폭탄을 만들예정이니 이전 시간에 만들었던 BombPrefab을 사용할예정입니다.
            Instantiate(bomb, new Vector3(randomX, startPos.transform.position.y, 0), Quaternion.identity);
            timer = interval;
        }
    }

    // 게임 오버 상태를 변경하는 함수 입니다.
    // public 이라는 키워드를 붙여주면 해당 스크립트가 뿐만 아니라
    // 다른 스크립트에서도 호출할수 있습니다.
    // 우리는 폭탄 맞은 주인공이 호출하게 할예정입니다.
    public void SetGameOver(bool gameover)
    {
        isGameover = gameover;
    }
}
