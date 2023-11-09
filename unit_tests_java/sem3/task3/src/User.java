package sem3.task3.src;

public class User {
    String login;
    String password;
    boolean isLogined;
    boolean isAdmin;

    public User(String login, String password, boolean isAdmin) {
        this.login = login;
        this.password = password;
        this.isAdmin = isAdmin;
        this.isLogined = false;
    }

    public User(String login, String password) {
        this(login, password, false);
    }

    public boolean authentification(UserRepository repo, String login, String password) {
        isLogined = this.login == login && this.password == password;
        if (isLogined) repo.addUser(this);
        return isLogined;
    }
}
