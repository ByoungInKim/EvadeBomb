using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // UI와 폭탄생성기를 주인공 소스코드에서 다루기 위한 변수를 만듭니다.
    public GameObject gameoverText;
    public GameObject gameoverBtn;
    public GameObject bombGenerator;

    private Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        //print(horizontal);
        transform.Translate(new Vector3(horizontal * 0.1f, 0f, 0));

    }

    public void Restart()
    {
        Debug.Log("restrt");
        SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // UI 2개를 다시 켜줍니다.
        // 조금전에 화면에서 보이게 하지 않기 위해 inspector 뷰에서 껏던것을 
        // 켜는 코드 입니다. 동작은 에디터에서 했던것과 동일한 작업을 합니다.
        gameoverText.SetActive(true);
        gameoverBtn.SetActive(true);

        // 폭탄 생성기의 함수를 호출해서 게임오버가 됬다는것을 알려주는 코드 입니다.
        bombGenerator.GetComponent<BombGenerator>().SetGameOver(true);
    }

    

}
