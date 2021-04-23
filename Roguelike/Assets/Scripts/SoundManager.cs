using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource efxSound;
    public AudioSource musicSound;
    public static SoundManager instance = null;

    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f; // tạo ra sự khác bọt về âm thanh

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        //nếu awake thì sẽ set soundmanager sang dontDestroyOnLoad
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySingle(AudioClip clip) // chơi những âm thanh đơn lẻ như sound eff và music loop
    {
        efxSound.clip = clip;
        efxSound.Play();
    }

    public void RandomizeSfx(params AudioClip[] clips) // phân tích các đối số thông qua dấu phẩy
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        //tạo ra một chút biến thể bằng cách chơi xen kẽ các âm thanh
        efxSound.pitch = randomPitch;
        efxSound.clip = clips[randomIndex];

        efxSound.Play();
    }
}
