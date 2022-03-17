using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour
{
    public float speed;
    Vector3 movimiento;
    public CharacterController cont;
    Vector2 mousePosition;
    public Camera cam;
    public bool corriendo = false;
    public Animator animador;
    public gameManager gm;
    public GameObject arma;
    public GameObject cuerpo;
    public statsJugador stats;
    public float cooldownMelee=0;
    public GameObject trail;
    public UnityEngine.UI.Slider sliderMelee;
    public bool paused = false;
    // Start is called before the first frame update
    void Start()
    {
        speed = stats.velocidad;
        cam = GameObject.Find("Camara").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        sliderMelee.value = 1 - (cooldownMelee / stats.cooldownMelee);
        cuerpo.transform.localPosition= new Vector3(-0.08f, -0.5f, -0.15f);
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        float hitDist = 1.0f;
        if(playerPlane.Raycast(ray, out hitDist) && gm.InputEnable /*&& !(animador.GetCurrentAnimatorClipInfo(1)[0].clip.name == "Attack02" || animador.GetCurrentAnimatorClipInfo(1)[0].clip.name == "Attack01")*/)
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
        }
        
        movimiento.x = Input.GetAxisRaw("Horizontal");
        movimiento.z = Input.GetAxisRaw("Vertical");
        if ((movimiento.x != 0 || movimiento.z != 0) && !animador.GetBool("corriendo") && gm.InputEnable)
        {
            corriendo = true;
            animador.SetBool("corriendo", true);
        }
        else if ((movimiento.x == 0 && movimiento.z == 0) && animador.GetBool("corriendo") && gm.InputEnable)
        {
            corriendo = false;
            animador.SetBool("corriendo", false);
        }
        if(gm.InputEnable)
        {
            cont.Move(movimiento * speed * Time.deltaTime);
        }
        if(cooldownMelee > 0)
        {
            cooldownMelee -= Time.deltaTime;
        }
        else { cooldownMelee = 0; }
        if (Input.GetKeyDown("p"))
        {
            if (paused)
            {
                Time.timeScale = 1;
                paused = false;
            }
            else
            {
                Time.timeScale = 0;
                paused = true;
            }
        }
        
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse1) && !((animador.GetCurrentAnimatorClipInfo(1)[0].clip.name == "Clip1") || (animador.GetCurrentAnimatorClipInfo(1)[0].clip.name == "WalkForwardBattle") || (animador.GetCurrentAnimatorClipInfo(1)[0].clip.name == "lanzar")) && cooldownMelee <= 0 && gm.InputEnable)
        {
            cooldownMelee = stats.cooldownMelee;
            trail.SetActive(true);
            animador.SetTrigger("atacar");
        }else if (Input.GetKey(KeyCode.Mouse0) && !((animador.GetCurrentAnimatorClipInfo(1)[0].clip.name == "Clip1") || (animador.GetCurrentAnimatorClipInfo(1)[0].clip.name == "lanzar")) && gm.InputEnable)
        {
            animador.SetTrigger("atacar2");
        }
    }
}
