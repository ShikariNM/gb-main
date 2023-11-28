package InMemoryModel;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import ModelElements.Camera;
import ModelElements.Flash;
import ModelElements.PoligonalModel;
import ModelElements.Scene;
import ModelElements.blinds.Angle3D;
import ModelElements.blinds.Color;
import ModelElements.blinds.Point3D;

public class ModelStore implements IModelChanger{
    public List<PoligonalModel> models;
    public List<Scene> scenes;
    public List<Flash> flashes;
    public List<Camera> cameras;
    private IModelChangeObserver[] changeObservers;

    public ModelStore(IModelChangeObserver[] changeObservers) {
        this.changeObservers = changeObservers;

        this.models = new ArrayList<>();
        this.models.add(new PoligonalModel());
        this.scenes = new ArrayList<>();
        this.scenes.add(new Scene(1, Arrays.asList(new PoligonalModel())));
        this. flashes = new ArrayList<>();
        this.flashes.add(new Flash(new Point3D(), new Angle3D(), new Color(), 100f));
        this.cameras = new ArrayList<>();
        this.cameras.add(new Camera(new Point3D(), new Angle3D()));
    }

    public Scene getScena(int id){
        return scenes.get(id);
    }

    @Override
    public void notifyChange(IModelChanger sender) {
        // TODO Auto-generated method stub
        throw new UnsupportedOperationException("Unimplemented method 'notifyChange'");
    }
    
}
