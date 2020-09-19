using UnityEngine;
using System.Collections;

// 要求元件(類型(元件))，套用腳本時觸發，新增一個指定類型的元件。    // 僅使用在腳本最外層
[RequireComponent(typeof(AudioSource))]
public class Rotate_Object : MonoBehaviour
{
    [Header("旋轉角度"), Range(0, 150)]
    public float angle = 90;
    [Header("旋轉速度"), Range(0, 100)]
    public float speed = 1.5f;
    [Header("音效")]
    public AudioClip sound;
    [Header("音量"), Range(0, 5)]
    public float valume = 1;

    private AudioSource aud;

    private void Awake()
    {
        aud = GetComponent<AudioSource>();  // 開始時套用指定音效
    }

    /// <summary>
    /// 開始旋轉
    /// </summary>
    public void StartRotate()
    {
        StartCoroutine(Rotate());   // 啟用協程()
    }

    /// <summary>
    /// 旋轉
    /// </summary>
    private IEnumerator Rotate()
    {
        aud.PlayOneShot(sound, valume);             // aud.POS(音效, 音量/float)
        GetComponent<Collider>().enabled = false;   // 關閉此物件的碰撞器(enabled = true/false)

        // 當 角度 不等於 指定的選轉角度(Euler(x, y, z))
        while (transform.rotation != Quaternion.Euler(0, angle, 0))
        {
            // 使用插值(當前角度, 指定 Euler角(x, y, z), 時間)
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, angle, 0), Time.deltaTime);
            yield return null;
        }
    }


}
