First of all: it smells like recursion of course!

Since you also wanted to know the principle, I did my best to explain it human language. I think recursion is very easy most of the times. You only have to grasp two steps:

The first step
All the other steps (all with the same logic)
In human language:

In short:

The permutation of 1 element is one element.
The permutation of a set of elements is a list each of the elements, concatenated with every permutation of the other elements.
Example:

If the set just has one element -->
return it.
perm(a) -> a

If the set has two characters: for each element in it: return the element, with the permutation of the rest of the elements added, like so:

perm(ab) ->

a + perm(b) -> ab

b + perm(a) -> ba

Further: for each character in the set: return a character, concatenated with a permutation of > the rest of the set

perm(abc) ->

a + perm(bc) --> abc, acb

b + perm(ac) --> bac, bca

c + perm(ab) --> cab, cba

perm(abc...z) -->

a + perm(...), b + perm(....)
....

I found the pseudocode on http://www.programmersheaven.com/mb/Algorithms/369713/369713/permutation-algorithm-help/:

makePermutations(permutation) {
  if (length permutation < required length) {
    for (i = min digit to max digit) {
      if (i not in permutation) {
        makePermutations(permutation+i)
      }
    }
  }
  else {
    add permutation to list
  }
}

C#

OK, and something more elaborate (and since it is tagged c #), from http://radio.weblogs.com/0111551/stories/2002/10/14/permutations.html : Rather lengthy, but I decided to copy it anyway, so the post is not dependent on the original.

The function takes a string of characters, and writes down every possible permutation of that exact string, so for example, if "ABC" has been supplied, should spill out:

ABC, ACB, BAC, BCA, CAB, CBA.

Code:

class Program
{
    private static void Swap(ref char a, ref char b)
    {
        if (a == b) return;

        var temp = a;
        a = b;
        b = temp;
    }

    public static void GetPer(char[] list)
    {
        int x = list.Length - 1;
        GetPer(list, 0, x);
    }

    private static void GetPer(char[] list, int k, int m)
    {
        if (k == m)
        {
            Console.Write(list);
        }
        else
            for (int i = k; i <= m; i++)
            {
                   Swap(ref list[k], ref list[i]);
                   GetPer(list, k + 1, m);
                   Swap(ref list[k], ref list[i]);
            }
    }

    static void Main()
    {
        string str = "sagiv";
        char[] arr = str.ToCharArray();
        GetPer(arr);
    }
}

static IEnumerable<IEnumerable<T>>
    GetPermutations<T>(IEnumerable<T> list, int length)
{
    if (length == 1) return list.Select(t => new T[] { t });

    return GetPermutations(list, length - 1)
        .SelectMany(t => list.Where(e => !t.Contains(e)),
            (t1, t2) => t1.Concat(new T[] { t2 }));
}

public static IEnumerable<IEnumerable<T>> Permute<T>(this IEnumerable<T> sequence)
{
    if (sequence == null)
    {
        yield break;
    }

    var list = sequence.ToList();

    if (!list.Any())
    {
        yield return Enumerable.Empty<T>();
    }
    else
    {
        var startingElementIndex = 0;

        foreach (var startingElement in list)
        {
            var index = startingElementIndex;
            var remainingItems = list.Where((e, i) => i != index);

            foreach (var permutationOfRemainder in remainingItems.Permute())
            {
                yield return permutationOfRemainder.Prepend(startingElement);
            }

            startingElementIndex++;
        }
    }
}
