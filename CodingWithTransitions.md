### Contents ###
  * [Adding the Transitions library to your project.](CodingWithTransitions#Adding_the_Transitions_library_to_your_project.md)
  * [Creating a transition that works on multiple properties.](CodingWithTransitions#Creating_a_transition_that_works_o_multiple_properties.md)
  * [Creating a transition that works on a single property.](CodingWithTransitions#Creating_a_transition_that_works_on_a_single_property.md)
  * [Creating chained transitions.](CodingWithTransitions#Creating_chained_transitions.md)
  * [Using the TransitionCompletedEvent.](CodingWithTransitions#Using_the_TransitionCompletedEvent.md)
  * [Using the predefined transition-types.](CodingWithTransitions#Using_the_predefined_transition-types.md)
  * [Using the user-defined transition-type.](CodingWithTransitions#Using_the_user-defined_transition-type.md)
  * [Creating your own transition-type.](CodingWithTransitions#Creating_your_own_transition-type.md)
  * [Property types supported by the Transitions library.](CodingWithTransitions#Property_types_supported_by_the_Transitions_library.md)

### Adding the Transitions library to your project ###
To add Transitions to your project you just need to add a reference to the Transitions.dll. This dll can be found in the TransitionsSample and TransitionsLibrary downloads.


### Creating a transition that works on multiple properties ###
You create a transition in three stages:
  1. Create a new Transition object.
  1. Add the properties to it that you want to animate.
  1. Run the transition.

Here's an example:
```
Transition t = new Transition(new TransitionType_EaseInEaseOut(2000));
t.add(pictureBox1, "Left", 0);
t.add(pictureBox2, "Left", -300);
t.run();
```
This transition moves pictureBox1 to X=0 and pictureBox2 to X=-300 from their initial positions overr the course of 2000ms. (If pictureBox1.Left was -300 before the transition, and the width of the picture-boxes is 300, this will slide picturebox2 off the screen while simultaneously sliding picturebox1 onto the screen.)

When you create the transition you specify which transition-type you will be using and any parameters needed by it - in particular the time that the transition will take, expressed in milliseconds. The transition-type defines which 'animation-curve' will be used. See [below](CodingWithTransitions#Using_the_predefined_transition-types.md) for more details about the different transition types.

After creating the transition, you tell it which properties you want to animate. As in the example above, these can be properties on more than one object. Equally, you could animate multiple properties on the same object. You specify the object, the name of the property and the destination value.

When you run the transition, the Transitions library will animate the specified properties from their current values to the specified destination values using the transition-type you specified. The animation is done asynchronously on a background thread, so your main thread of code carries on running immediately after the run() method is called.


### Creating a transition that works on a single property ###
The Transitions class has a static run() method that lets you animate a single property. You call it like this:
```
Transition.run(this, "BackColor", Color.Red, new TransitionType_Linear(1000));
```

This is just a convenient shorthand for:
```
Transition t = new Transition(new TransitionType_Linear(1000));
t.add(this, "BackColor", Color.Red);
t.run();
```


### Creating chained transitions ###
You may want to create animated transitions that chain together. For example, you might want to move an object down the screen and then across. To do this, you create multiple individual transitions and chain them together like this:
```
Transition t1 = new Transition(new TransitionType_Linear(1000));
t1.add(pictureBox1, "Top", 500);

Transition t2 = new Transition(new TransitionType_Linear(1000));
t2.add(pictureBox1, "Left", 400);

Transition.runChain(t1, t2);
```
This animates the picture-box to Y=500 and when that has completed it animates it to X=400. The runChain() method can take an arbitrary number of transitions, or can take an array of Transition objects.


### Using the TransitionCompletedEvent ###
Transitions are run asynchronously. If you need to know when a transition has completed you can register with the TransitionCompletedEvent. This is raised from the Transition's background thread when the transition is completed. If your event-handler is on a UI object such as a form, the event will automatically be marshaled to the UI thread.


### Using the predefined transition-types ###
When you create a transition you specify the transition-type. These specify the animation-curve  - and other parameters - needed by the animation. There are a number of built-in transition types, described below.

**TransitionType\_Linear** is a linear animation with objects moving at a constant rate throughout the transition.

**TransitionType\_Acceleration** starts the transition at zero velocity and builds up at a constant rate of acceleration to be at full-speed by the end of the transition.

**TransitionType\_Deceleration** starts the transition at full-speed and decelerates at a constant rate to be at zero velocity by the end of the transition.

**TransitionType\_CriticalDamping** is a declerating transition, using an exponentially decaying velocity. It is good (for example) for animating properties such as needles on dials.

**TransitionType\_EaseInEaseOut** starts at zero velocity and accelerates until halfway through the transition, then decelerates back to zero velocity by the end of the transition.

**TransitionType\_Bounce** accelerates to the destination value by halfway through the transition and then decelerates back to the original value by the end. This is similar to acclerating downwards with gravity and then bouncing back against gravity.

**TransitionType\_ThrowAndCatch** is the counterpart of the Bounce transition above. It decelerates to the destination value by halfway through the transition and then acclerates back to the original value by the end.

**TransitionType\_Flash** lets you specify a number of flashes and the time for each flash. Each flash animates the properties to their destination value and back again using an ease-in-ease-out transition.


### Using the user-defined transition-type ###
The TransitionType\_UserDefined lets you define your own custom animation-curve by building it out of elements. Each element specifies one part of the curve. You create a list of TransitionElement objects and then pass them to constructor of the TransitionType\_UserDefined. For each transition-element you specify the end time, the end value and the interpolation method. For example, you could specify the ease-in-ease-out transition as a user-defined transition like this:
```
IList<TransitionElement> elements = new List<TransitionElement>();
elements.Add(new TransitionElement(50, 50, InterpolationMethod.Accleration));
elements.Add(new TransitionElement(100, 100, InterpolationMethod.Deceleration));

Transition.run(pictureBox1, "Left", 400, new TransitionType_UserDefined(elements, 2000));
```
This specifies that by 50% of the way through the transition, the value will be at 50% of the final value and will have got there by accelerating; by 100% of the way through it will have 100% of the value and will have got there by decelerating. (See the sample code for another example of a user-defined transition.)


### Creating your own transition-type ###
All transition-types implement the ITransitionType interface. You can create your own classes that implement this interface and use them as your own custom transition-types. The interface has only one method:
```
void onTimer(int iTime, out double dPercentage, out bool bCompleted);
```
As the transition progresses, the elapsed time (in milliseconds) is passed in. The function calculates the percentage 'distance' traveled between the original and destination values of properties for this point in time. (This is returned as a number like 0.75 for 75%.) Note: you can return values less than 0.0 and greater than 1.0 if you want to create a transition that can 'overshoot' the original or destination values. When the transition has completed, you must return true in the bCompleted parameter.


### Property types supported by the Transitions library ###
The Transitions library knows how to perform animations on properties of these types: Int,Float, Double, Color and String. This covers most animatable properties of most objects. If you have a property that you need to animate that is not one of these, you can create a class that implements the IManagedType interface and register it with the Transitions class. This has to be done by extending the library itself and recompiling it. If you do this - or if you want another type added - please let me know and I can add it to a future version of the library. You can mail me at richard\_s\_shepherd@yahoo.co.uk.