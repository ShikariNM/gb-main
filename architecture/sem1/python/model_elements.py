from typing import TypeVar


class Point3D:
    ...


class Angle3D:
    ...


class Color:
    ...


class Texture:
    ...


class Poligon:
    def __init__(self, points: list[Point3D]):
        self.points = points


class PoligonalModel:
    def __init__(self, textures: list[Texture] = None):
        self.poligons = [Poligon([Point3D()])]
        self.texture = textures if textures else []


class Flash:
    def __init__(self, location: Point3D, angle: Angle3D, color: Color, power: float) -> None:
        self.location = location
        self.angle = angle
        self.color = color
        self.power = power

    def rotate(self, angle: Angle3D):
        self.angle = angle

    def move(self, point: Point3D):
        self.location = point


class Camera:
    def __init__(self, location: Point3D, angle: Angle3D):
        self.location = location
        self.angle = angle

    def rotate(self, angle: Angle3D):
        self.angle = angle

    def move(self, point: Point3D):
        self.location = point


class Scene:
    TempType = TypeVar('TempType')

    def __init__(self, id_: int, models: list[PoligonalModel], flashes: list[Flash] = None):
        self.id_ = id_
        self.models = models
        self.flashes = flashes if flashes else []

    def method1(self, arg: TempType) -> TempType:
        ...

    def method2(self, arg1: TempType, arg2: TempType) -> TempType:
        ...
