from pydantic import BaseModel, Field


class ProductIn(BaseModel):
    title: str = Field(min_length=2)
    description: str = Field(max_length=128)
    price: float


class Product(ProductIn):
    id: int
