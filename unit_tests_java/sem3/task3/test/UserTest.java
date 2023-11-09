package sem3.task3.test;

import static org.junit.Assert.assertFalse;
import static org.junit.Assert.assertTrue;

import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.BeforeEach;

import sem3.task3.src.User;
import sem3.task3.src.UserRepository;

public class UserTest {
    User user;
    UserRepository repo;

    @BeforeEach
    void createUserAndRepo() {
        user = new User("login", "password");
        repo = new UserRepository();
    }

    @Test
    void succesfulAuthTest() {
        assertTrue(user.authentification(repo, "login", "password"));
    }

    @Test
    void wrongLoginAuthTest() {
        assertFalse(user.authentification(repo, "MISTAKE", "password"));
    }

    @Test
    void wrongPasswordAuthTest() {
        assertFalse(user.authentification(repo, "login", "MISTAKE"));
    }

    @Test
    void RepoContainsLoginedUserTest() {
        user.authentification(repo, "login", "password");
        assertTrue(repo.dataBase.contains(user));
    }

    @Test
    void globalLogOutExceptAdminsTest() {
        User admin = new User("admin", "password", true);
        repo.addUser(admin);
        repo.addUser(user);
        repo.globalLogOutExceptAdmins();
        assertFalse(repo.dataBase.contains(user));
        assertTrue(repo.dataBase.contains(admin));
    }
}
