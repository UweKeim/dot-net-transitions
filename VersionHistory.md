**Version 1.0**
Initial version of Transitions.

**Version 1.1**
Supports "folding" of transitions. This occurs if you start running a transition on a property that is already undergoing a different transition. In this case the original running transition will be canceled and replaced with the new transition. The new transition will start with the property's value at its current point in the original transition. This ensures that multiple transitions cannot be competing over a single property and potentially updating it in inconsistent ways.

**Version 1.2**
Fixed a bug where transitions could stop working if you closed a form in the middle of a transition that was acting on controls in the form.