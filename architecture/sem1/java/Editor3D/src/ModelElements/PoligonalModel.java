package ModelElements;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import ModelElements.blinds.Point3D;

public class PoligonalModel {
    public List<Poligon> poligons;
    public List<Texture> textures;

    public PoligonalModel(List<Texture> textures) {
        this.textures = textures;
        this.poligons = new ArrayList<>();
        this.poligons.add(new Poligon(Arrays.asList(new Point3D())));
    }

    public PoligonalModel() {
        this(new ArrayList<>());
    }
}
