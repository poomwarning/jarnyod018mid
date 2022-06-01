using UnityEngine;
using System.Collections;
using RootMotion.Dynamics;
using UnityEngine.UI;
using UnityEngine.Events;

/*namespace RootMotion.Demos
{*/
    
    public class zombie : MonoBehaviour
    {
         int reward;
        string className;
       // public RawImage blood;
        //state enemy
        public float sightRange,attackRange;
        public bool playerInsightRange,PlayerInattackRange;
        public float zombieHP;

        public  float Zdamage;
        //
        public BehaviourPuppet puppet;
        public UnityEngine.AI.NavMeshAgent agent;
        public Transform target;
        public Animator animator;
        public PuppetMaster puppetMaster;
        public LayerMask whatIsPlayer;
        public float speed;
        public static bool alert;
        bool getshot ;
        Color temp;
         shootHP Hp = new shootHP();
        static DeadEvent  deadEvent = new DeadEvent();
        public static void Zombielistener (UnityAction<int> listeneroof)
        {
            deadEvent.AddListener(listeneroof);
        }
        
         private void Awake() 
         {
             target = GameObject.FindWithTag("Player").transform;
             alert = false;
             Hp.HP = zombieHP;
             getshot = false;
            /* temp = blood.color;
             temp.a = 0f;
             blood.color = temp;*/
              Hp = new shootHP();
                 className = gameObject.GetComponentInChildren<zombie>().GetType().Name;
             switch (className)
            {
                case "zombie":
                    reward = 100;
                    break;
                case "zombieriot":
                    reward = 200;
                    break;
                case "zombiearmy":
                    reward = 150;
                    break;
                default:
                    break;
            }
             
        }
         private void Start() 
         {
         
        }
        void Update()
        {
          
             //blood.color = temp;
            playerInsightRange = Physics.CheckSphere(transform.position,sightRange,whatIsPlayer);
            PlayerInattackRange = Physics.CheckSphere(transform.position,attackRange,whatIsPlayer);

            // Keep the agent disabled while the puppet is unbalanced.
            agent.enabled = puppet.state == BehaviourPuppet.State.Puppet;

            // Update agent destination and Animator
            if (agent.enabled)
            {
                if(alert==false)
             {
                if( playerInsightRange&&animator.GetBool("run")==false || getshot == true)
                {
                    
                    animator.SetBool("trigger",true);
                    agent.SetDestination(target.position);
                    agent.speed = 0;
                   
                  // transform.LookAt(new Vector3(target.position.x,transform.position.y,target.position.z));
                   this.transform.rotation = Quaternion.Slerp(this.transform.rotation,Quaternion.LookRotation(target.position-this.transform.position),0.01f);
                }
               
             }
             else
             {
                 animator.SetBool("run",true);
                 agent.SetDestination(target.position);
                 agent.speed = speed;
                 temp.a -= Time.deltaTime/2;
             }
             if(animator.GetBool("run")==true)
             {
                     alert = true;
                     agent.SetDestination(target.position);
                   //  Debug.Log(PlayerInattackRange);   
                     agent.speed = speed;
                   
                     if((target.transform.position-this.transform.position).sqrMagnitude<2.5*2.5&&agent.enabled)
                        {
                             Debug.Log("working");
                             HP.regen = false;
                             animator.SetBool("attacking",true);
                            // temp.a += Time.deltaTime/2;
                        }
                        else
                        {
                            HP.regen = true;
                            animator.SetBool("attacking",false);
                           // PlayerInattackRange == true
                            //target.transform.position-this.transform.position).sqrMagnitude<2.5*2.5
                        }
             }
            
         
                
             
             
                //
                

               // animator.SetFloat("Forward", agent.velocity.magnitude * 0.25f);
            }
            else
            {
                HP.regen = true;
            }
        if(Hp.HP<=0)
        {
                deadEvent.Invoke(reward);
                puppetMaster.Kill();
                remain.zombie -= 1;
                random.limitzombie -=1;
                Invoke("destro",10f);
                this.enabled = false;
                agent.enabled = false;
        }
        
            
        }
        public void destro()
        {
            Destroy(transform.parent.gameObject);
        }
        public void CollisionDetected(ChildScript childScript)
        {
            getshot = true;
            Hp.HP -= Hp.DAMAGE;
            Debug.Log(Hp.HP);
        }
         public void Headshot(ChildScript childScript)
        {
            Hp.HP -= Hp.HP*2;
           // Debug.Log("HEADSHOT");
        }
        public void setbool()
        {
            animator.SetBool("run",true);
            animator.SetBool("trigger",false);
        }
        public void animationpunch()
        {
           
           HP.takedamage(Zdamage);
        }
    }
//}
