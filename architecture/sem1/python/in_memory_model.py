from abc import ABC, abstractmethod

from model_elements import PoligonalModel, Scene, Flash, Camera, Point3D, Angle3D, Color


class IModelChangeObserver(ABC):
    @abstractmethod
    def apply_update_model(self) -> None:
        ...


class IModelChanger(ABC):
    @abstractmethod
    def notify_change(self, sender) -> None:
        ...


class ModelStore(IModelChanger):

    def __init__(self, change_observers: list[IModelChangeObserver]) -> None:
        self.__change_observers = change_observers

        self.models = [PoligonalModel()]
        self.scenes = [Scene(1, [PoligonalModel()])]
        self.flashes = [Flash(Point3D(), Angle3D(), Color(), 100)]
        self.cameras = [Camera(Point3D(), Angle3D())]

    def get_scena(self, id_: int):
        for scene in self.scenes:
            if scene.id_ == id_:
                return scene

    def notify_change(self, sender) -> None:
        return super().notify_change(sender)
