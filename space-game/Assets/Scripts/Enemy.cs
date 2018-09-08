using UnityEngine;

public class Enemy : MonoBehaviour
{

	
	public int movementPattern;
	
	int wpnsCount;
	public float mobility;
	public float hostileness;
	private float mobilityR = 0.0f;
	private float hostilenessR = 0.0f;
	
	public bool patternChanger;
	float changerTime;
	
	public int recoilPush;
	
	private int currentScheme=0;
	Transform target;
	
	int mod(int x, int m) 
	{
		return (x%m + m)%m;
	}
	
	void Start()
	{

		wpnsCount = gameObject.GetComponent<Weapons>().Wpns.Length;
		mobilityR=Random.Range(-0.5f,0);
		hostilenessR=Random.Range(-0.5f,0);
		if(movementPattern==2||patternChanger) //SPY
		{
			if(GameObject.FindGameObjectWithTag("Player"))
				target=GameObject.FindGameObjectWithTag("Player").transform;
		}

	}

    void FixedUpdate()
    {
		if(mobilityR>1/mobility)
		{
			mobilityR=0;
			currentScheme++;
		}
		
		if(hostilenessR>1/hostileness)
		{
			hostilenessR=Random.Range(0,1/hostileness);
			for(int i=0;i<wpnsCount;i++)
			{
				gameObject.SendMessage("Shoot",i,SendMessageOptions.RequireReceiver);
			}
		}
			
			//1 up
			//2 down
			//3 left
			//4 right
			
		// -> <-
		if(movementPattern==0)
		{
			if(mod(currentScheme,2)==0)
				gameObject.SendMessage("GetInput", 3);
			else
				gameObject.SendMessage("GetInput", 4);
		}
		// <>
		else if(movementPattern==1)
		{
			if(mod(currentScheme,4)==0)
			{
				gameObject.SendMessage("GetInput", 4);
				gameObject.SendMessage("GetInput", 2);
			}
			else if(mod(currentScheme,4)==3)
			{
				gameObject.SendMessage("GetInput", 4);
				gameObject.SendMessage("GetInput", 1);
			}			
			else if(mod(currentScheme,4)==2)
			{
				gameObject.SendMessage("GetInput", 3);
				gameObject.SendMessage("GetInput", 1);
			}
			else
			{
				gameObject.SendMessage("GetInput", 3);
				gameObject.SendMessage("GetInput", 2);
			}
		}
		// SPY
		else if(movementPattern==2)
		{
			if(target)
			{
				if(transform.position.x>target.position.x)
					gameObject.SendMessage("GetInput", 4);
				else
					gameObject.SendMessage("GetInput", 3);
			}
			else
				movementPattern=1;
		}
		// <<>>
		else if(movementPattern==3)
		{
			if(mod(currentScheme,4)==0)
			{
				gameObject.SendMessage("GetInput", 4);
				if(Random.Range(1,3)==1)
					gameObject.SendMessage("GetInput", 2);
			}
			else if(mod(currentScheme,4)==3)
			{
				gameObject.SendMessage("GetInput", 4);
				if(Random.Range(1,3)==1)
					gameObject.SendMessage("GetInput", 1);
			}			
			else if(mod(currentScheme,4)==2)
			{
				gameObject.SendMessage("GetInput", 3);
				if(Random.Range(1,3)==1)
					gameObject.SendMessage("GetInput", 1);
			}
			else
			{
				gameObject.SendMessage("GetInput", 3);
				if(Random.Range(1,3)==1)
					gameObject.SendMessage("GetInput", 2);
			}
		}
		
		
		if(patternChanger)
		{
			if(changerTime>3)
			{
				changerTime=0;
				movementPattern++;
				if(movementPattern>3)
				{
					movementPattern=0;
				}	
			}
		}
		
    }
	
	void OnCollisionEnter2D(Collision2D coll) 
	{
		currentScheme++;
	}
	
	void LateUpdate()
	{
		mobilityR+=Time.deltaTime;
		hostilenessR+=Time.deltaTime;
		if(patternChanger)
			changerTime+=Time.deltaTime;
	}
	
	public void ShootConfirmed()
	{
		if(recoilPush!=0)
		{
			gameObject.SendMessage("Push", recoilPush);
		}
	}
	
}