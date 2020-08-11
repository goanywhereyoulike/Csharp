using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private float m_nextFire;
    public GameObject Bullet;
    public float BulletSpeed;
    public Transform firepoint;
    public AudioSource firesound;
    private void FixedUpdate()
    {
        m_nextFire = m_nextFire + Time.fixedDeltaTime;

        // 获取鼠标坐标并转换成世界坐标
        Vector3 m_mousePosition = Input.mousePosition;
        m_mousePosition = Camera.main.ScreenToWorldPoint(m_mousePosition);
        // 因为是2D，用不到z轴。使将z轴的值为0，这样鼠标的坐标就在(x,y)平面上了
        m_mousePosition.z = 0;

        // 武器朝向角度
        Vector3 aimDirection = (m_mousePosition - transform.position).normalized;
        float m_weaponAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;


        // 变换最终角度
        transform.eulerAngles = new Vector3(0, 0, m_weaponAngle);
        if (Input.GetMouseButton(0) && m_nextFire >0.1)
        {

        m_nextFire = 0;
        firesound = GetComponent<AudioSource>();
        firesound.Play();
      
        GameObject m_bullet = Instantiate(Bullet, firepoint.position, firepoint.rotation);

        m_bullet.GetComponent<Rigidbody2D>().velocity = aimDirection * BulletSpeed;

            m_bullet.transform.Rotate(0,0, m_weaponAngle);
         }
    }

}
