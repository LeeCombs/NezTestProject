using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;
using System.Collections;

namespace NezTestProject
{
    class Player : Component
{
	// we'll store a reference to our SimpleMover for easy access
	SimpleMover _mover;
	
	// this method is called when a Component is added to an Entity. It is called after all the Components are added in a frame so it is
	// safe to access the other Components from here.
	public virtual void OnAddedToEntity()
	{
		// we can access any other Components on the Entity via the getComponent method. Just pass in the Type of the Component and it
		// will return the Component or null if no Component of that Type is on the Entity.
		_mover = entity.getComponent<SimpleMover>();
	}
	
	
	// this method is called elsewhere (perhaps when a bullet hits the Entity). It reduces the SimpleMovers speed for 2 seconds
	public void TakeDamage()
	{
		// reduce the SimpleMovers speed
		_mover.speed = 70f;
		
		// use the TimerManager to schedule a callback after 2 seconds have elapsed
		Core.schedule( 2f, t => _mover.speed = 100f );
	}
	
	
	public void TakeDamageTwo()
	{
		// reduce the SimpleMovers speed
		_mover.speed = 70f;
		
		// use a coroutine to reset the SimpleMovers speed after 2 seconds have elapsed
		Core.startCoroutine(ResetSpeedAfterDelay());
	}
	
	
	IEnumerator ResetSpeedAfterDelay()
	{
		// let the CoroutineManager know we want to wait for 2 seconds
		yield return Coroutine.waitForSeconds( 2f );
		
		// reset the speed
		_mover.speed = 100f;
	}
}
}
