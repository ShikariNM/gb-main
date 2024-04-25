from pydantic import BaseModel, Field
from datetime import date


class OrderIn(BaseModel):
    user_id: int
    product_id: int
    order_date: date = Field(default=date.today())
    is_done: bool = Field(default=False)


class Order(OrderIn):
    id: int


class OrderOut(BaseModel):
    order_id: int
    order_date: date
    order_is_done: bool
    user_first_name: str
    user_last_name: str
    product_title: str
