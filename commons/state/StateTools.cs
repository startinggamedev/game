using Godot;
using System;

static class StateTools
{
	static public void SetUpThread(StateThread ThreadTosetup)
	{

	}
	static public void RunStateProcess(double delta,State StateToRun)
	{   
		StateToRun.Process(delta);
		foreach (var CurrentThread in StateToRun.Threads)
		{
			CurrentThread.Process(delta);
		}
	}
	static public void RunStatePhysics(double delta,State StateToRun)
	{
		StateToRun.Physics(delta);
		foreach (var CurrentThread in StateToRun.Threads)
		{
			CurrentThread.Physics(delta);
		}
	}
}
