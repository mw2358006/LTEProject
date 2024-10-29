using UnityEngine;
using UnityEngine.UI;
public class SliderHpbar : MonoBehaviour
{
    public Slider hpBar;
    public int currHp;
    public int maxHp;
    void Start()
    {
        hpBar.value = (float) currHp/maxHp;
    }
    void Update()
    {
        Refresh();
    }
    void Refresh()
    {
        hpBar.value = (float) currHp/maxHp;
        if(hpBar.value <= 0) {
            transform.Find("Fill Area").gameObject.SetActive(false);
        }
        else if(hpBar.value > 0)
        {
            // hpBar.value이 0이 아닐때 Fill Area의 상태
        }
    }
    public void Damage(int damage)
    {
        if(currHp < 1)
        {
            Debug.Log("저런 디졌네요 ^^");
            damage = 0;
        }
        else
        {
            if(currHp - damage < 0)
            {
                int makeZero = (currHp - damage) * -1;
                currHp += makeZero;
            }
            Debug.Log("가라 이몸의 샤프클로");
        }
        currHp -= damage;
    }
    public void Heal(int heal)
    {
        // Heal 버튼 작동하는 함수
        if(currHp < 1 || currHp >= maxHp)
        {
            // currHp가 0이거나 MaxHp 보다 클 때
        }
        else
        {
            // currHp + Heal이 MaxHp보다 클 때
        }
    }
    public void Reset()
    {
        Debug.Log("투아림 부스트");
        currHp = maxHp;
        transform.Find("Fill Area").gameObject.SetActive(true);
    }
}