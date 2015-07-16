### Overview ###
The Transitions library lets you create animated transitions of any properties of user-interface elements for .NET. It provides an easy way to perform UI animations in .NET in a similar way to the Core Animation library for Apple and the iPhone.

The Transitions library is built with Visual Studio 2008 but targets version 2 of the .NET runtime, so it can be used with projects built with VS2005.


### Getting started ###
You can animate a single property of an object with a single line of code like this:
```
Transition.run(this, "BackColor", Color.Red, new TransitionType_Linear(1000));
```
If this code is in a Form class, it animates the background color from its initial color to red over the course of 1000ms.

You can animate multiple properties (maybe across multiple objects) simultaneously with code like this:
```
Transition t = new Transition(new TransitionType_EaseInEaseOut(2000));
t.add(pictureBox1, "Left", 300);
t.add(pictureBox1, "Top", 200);
t.run();
```
This animates the movement of pictureBox1 from its initial location to (300, 200) over the course of 2000ms.

### Coding with Transitions ###
The TestSample project (which is part of the code download) demonstrates a number of different transitions. It is fairly well commented, and can act as a tutorial to help get you started.

For more information on how to code with the Transitions library see the [coding reference](CodingWithTransitions.md).

### Version History ###
Transitions is currently at version 1.2. See the VersionHistory page for details of previous version.

### Acknowledgements ###
Thanks to Maxim Gready for writing the critical-damping transition-type.