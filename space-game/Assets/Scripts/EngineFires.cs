using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineFires : MonoBehaviour 
{

	string[] inputs;
	public GameObject[] engineFires;
	public int enginePower = 3;
	
	void GetInputs(string[] inpts)
	{
		inputs=inpts;
	}
	
	void Update () 
	{
		
		//RightFire
		if(Input.GetKey(inputs[2]))
		{
			engineFires[0].GetComponent<ParticleSystem>().Emit(enginePower);
		}
		
		//LeftFire
		if(Input.GetKey(inputs[3]))
		{
			engineFires[1].GetComponent<ParticleSystem>().Emit(enginePower);
		}
		
		//BothBottomFires
		if(Input.GetKey(inputs[0]) && !Input.GetKey(inputs[3]) && !Input.GetKey(inputs[2]))
		{
			engineFires[2].GetComponent<ParticleSystem>().Emit(enginePower);
			engineFires[3].GetComponent<ParticleSystem>().Emit(enginePower);
		}
		else
		{
			//LeftBottomFire
			if(Input.GetKey(inputs[3]) && Input.GetKey(inputs[0]))
			{
				engineFires[2].GetComponent<ParticleSystem>().Emit(enginePower);
			}
			
			//RightBottomFire
			if(Input.GetKey(inputs[2]) && Input.GetKey(inputs[0]))
			{
				engineFires[3].GetComponent<ParticleSystem>().Emit(enginePower);
			}
		}
		
		//BothUpFires
		if(Input.GetKey(inputs[1]) && !Input.GetKey(inputs[3]) && !Input.GetKey(inputs[2]))
		{
			engineFires[4].GetComponent<ParticleSystem>().Emit(enginePower);
			engineFires[5].GetComponent<ParticleSystem>().Emit(enginePower);
		}
		else
		{
			//LeftUpFire
			if(Input.GetKey(inputs[3]) && Input.GetKey(inputs[1]))
			{
				engineFires[4].GetComponent<ParticleSystem>().Emit(enginePower);
			}
			
			//RightUpFire
			if(Input.GetKey(inputs[2]) && Input.GetKey(inputs[1]))
			{
				engineFires[5].GetComponent<ParticleSystem>().Emit(enginePower);
			}
		}
		
	}
	
	void PickupEB(float multi)
	{
		for(int i = 0;i<6;i++)
		{
			var temp = engineFires[i].GetComponent<ParticleSystem>().main;
			temp.startSize=new ParticleSystem.MinMaxCurve(0.2f, multi/3);
		}
	}
	
}
