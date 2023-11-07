package sem1.task8;

import java.util.List;

public class Hero {
    String name;
    int defense;
    String weapon;
    List<String> heroBag;
    boolean isHuman;

    public Hero(String name, int defense, String weapon, List<String> heroBag, boolean isHuman) {
        this.name = name;
        this.defense = defense;
        this.weapon = weapon;
        this.heroBag = heroBag;
        this.isHuman = isHuman;
    }
}
