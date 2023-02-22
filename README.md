# ShallowCopyVsDeepCopy

## Shallow copy
shallow copy is a List<T>, where T is a reference type, copies only the structure of the collection and references to its elements, not the elements themselves. This means that changes to the elements in any of the two lists will be reflected in both the original and copied lists.

## Deep Copy 
The alternative of shallow copy is to create a deep copy – this means that we don’t just copy the references to the objects but create new, copied objects. This produces a different result than shallow copies as the objects referenced by the copied list are separate from those referenced in the original list.
