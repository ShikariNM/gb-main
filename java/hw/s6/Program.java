package s6;

import java.util.NoSuchElementException;
import java.util.Random;

public class Program {
    public static void main(String[] args) {
        FakeSet set = new FakeSet();
        System.out.println("\nBEFORE SET FILLING");
        System.out.println("isEmpty: " + set.isEmpty());
        System.out.println("size: " + set.size());
        System.out.println("contains \"4\": " + set.contains(4));
        System.out.println("get by index \"2\": " + set.get(2));
        System.out.println("remove 4: " + set.remove(4));

        System.out.print("\nAdded numbers are: ");
        for (int i = 0; i < 30; i++) {
            int addedNum = new Random().nextInt(0, 10);
            System.out.print(addedNum + " ");
            set.add(addedNum);
        }
        System.out.println("\nGotten set is: " + set);

        System.out.println("\nAFTERE SET FILLING");
        System.out.println("isEmpty: " + set.isEmpty());
        System.out.println("size: " + set.size());
        System.out.println("contains \"4\": " + set.contains(4));
        System.out.println("get by index \"2\": " + set.get(2));
        System.out.println("remove 4: " + set.remove(4));
        System.out.println("contains \"4\": " + set.contains(4));

        System.out.println("\nITERATOR CHECK");
        System.out.println("contains \"5\": " + set.contains(5));
        FakeSet.FakeSetIterator it = set.iterator();
        System.out.print("Iterator's \"next\" returns: ");
        while (it.hasNext()) {
            int next = it.next();
            System.out.print(next + " ");
            if (next == 5) it.remove();
        }
        System.out.println("\ncontains \"5\": " + set.contains(5));
    }
}

class FakeSet {
    static int objectIndex = 0;
    static int length = 16;
    private FakeSetObject[] mainArray = new FakeSetObject[length];

    public void add(Integer number) {
        int hash = number.hashCode();
        int index = hash % length;
        FakeSetObject obj = mainArray[index];
        while (obj != null) {
            if (mainArray[index].value == number) return;
            obj = obj.next;
        }
        FakeSetObject newObject = 
        new FakeSetObject(number, hash, objectIndex, mainArray[index]);
        objectIndex += 1;
        mainArray[index] = newObject;
    }

    @Override
    public String toString() {
        StringBuilder res = new StringBuilder("[");
        FakeSetIterator it = this.iterator();
        while (it.hasNext()){
            res.append(it.next());
            res.append(", ");
        }
        res.replace(res.length()-2, res.length()-1, "]");
        return res.toString();
    }

    public Integer get(Integer index) {
        if (this.size() == 0) return null;
        FakeSetIterator it = this.iterator();
        while (it.hasNext()){
            FakeSetObject obj = it.nextNode();
            if (index == obj.index) return obj.value;
        }
        throw new ArrayIndexOutOfBoundsException
        ("Index " + index + " out of bounds for length " + objectIndex);
    }

    public boolean isEmpty() {
        for (FakeSetObject elem : mainArray) {
            if (elem != null) return false;
        }
        return true;
    }

    public Integer size() {
        return objectIndex;
    }

    public boolean contains(Integer number) {
        if (this.size() == 0) return false;
        FakeSetIterator it = this.iterator();
        while (it.hasNext()){
            if (number == it.next()) return true;
        }
        return false;
    }

    final FakeSetObject removeNode (Integer value) {
        if (this.size() == 0) return null;
        int objIndex = 0;
        FakeSetObject currentPrev = null;
        for (FakeSetObject obj : mainArray) {
            while (obj != null) {
                if (obj.value == value) {
                    if (currentPrev == null) mainArray[objIndex] = obj.next;
                    else currentPrev.next = obj.next;
                    obj.next = null;
                    return obj;
                }
                currentPrev = obj;
                obj = obj.next;
            }
            currentPrev = null;
            objIndex++;
        }
        return null;
    }

    public Integer remove(Integer value) {
        FakeSetObject removedObj = this.removeNode(value);
        return (removedObj) == null ? null : removedObj.value;
    }

    public FakeSetIterator iterator() {
        return new FakeSetIterator();
    }

    public class FakeSetIterator {
        FakeSetObject current;
        FakeSetObject next;
        int index;

        FakeSetIterator() {
            index = 0;
            while (index < mainArray.length && mainArray[index] == null) {
                index++;
            }
            next = mainArray[index];
        }

        public final boolean hasNext() {
            return next != null;
        }

        final FakeSetObject nextNode() {
            if (next == null)
                throw new NoSuchElementException();
            current = next;
            next = current.next;
            if (next == null && index < mainArray.length - 1) {
                index++;
                while (index < mainArray.length && mainArray[index] == null) index++;
                if (index < mainArray.length) next = mainArray[index];
            }
            return current;
        }

        final Integer next() {
            return nextNode().value;
        }

        public final void remove() {
            removeNode(current.value);
        }
    }

    class FakeSetObject {
        int value;
        int hash;
        int index;
        FakeSetObject next;

        public FakeSetObject
        (Integer value, Integer hash, Integer index, FakeSetObject next){
            this.value = value;
            this.hash = hash;
            this.index = index;
            this.next = next;
        }
    }
}