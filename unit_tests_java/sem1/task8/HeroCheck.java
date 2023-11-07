package sem1.task8;

import java.util.Arrays;

public class HeroCheck {
    public static void checkingHero(Hero hero) {
        assert hero.name.equals("Emmett"): "The name is not Emmet";
        assert hero.defense == 50: "The defense is not 50";
        assert hero.weapon.equals("sword"): "The weapon is not sword";
        assert hero.heroBag.containsAll(Arrays.asList("Bow", "Axe", "Gold")):
            "The bag content is different to Bow, Axe and Gold";
        assert hero.isHuman: "The hero is not a Human";
    }
}
