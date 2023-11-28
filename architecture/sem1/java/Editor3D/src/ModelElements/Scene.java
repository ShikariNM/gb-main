package ModelElements;

import java.util.ArrayList;
import java.util.List;

public class Scene {
    public int id;
    public List<PoligonalModel> models;
    public List<Flash> flashes;

    public Scene(int id, List<PoligonalModel> models, List<Flash> flashes) {
        this.id = id;
        this.models = models;
        this.flashes = flashes;
    }

    public Scene(int id, List<PoligonalModel> models) {
        this(id, models, new ArrayList<>());
    }

    class TempType {}

    public TempType method1(TempType arg) {
        return new TempType();
    }

    public TempType method2(TempType arg1, TempType arg2) {
        return new TempType();
    }
}
