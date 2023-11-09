package sem3.task3.src;

import java.util.ArrayList;
import java.util.Iterator;

public class UserRepository {
    public ArrayList<User> dataBase;

    public UserRepository() {
        dataBase = new ArrayList<>();
    }

    public void addUser(User user) {
        dataBase.add(user);
    }

    public void globalLogOutExceptAdmins() {
        Iterator<User> dbIterator = dataBase.iterator();
        while (dbIterator.hasNext()) {
            User nextUser = dbIterator.next();
            if (!nextUser.isAdmin) dbIterator.remove();
        }
    }
}
