from fastapi import APIRouter
from fastapi.responses import JSONResponse
from sqlalchemy import select

from hw6.db import users, products, orders, database
from hw6.models.order import Order, OrderIn, OrderOut

from random import choice
from datetime import date

router = APIRouter()


@router.get("/fake_orders/{count}")
async def create_orders(count: int):
    all_users = [user.id for user in await database.fetch_all(users.select())]
    all_products = [product.id for product in await database.fetch_all(products.select())]
    for _ in range(count):
        query = orders.insert().values(user_id=choice(all_users),
                                       product_id=choice(all_products),
                                       order_date=date.today(),
                                       is_done=False)
        await database.execute(query)
    return {'message': f'{count} fake orders have been created'}


@router.get("/orders/", response_model=list[OrderOut])
async def read_orders():
    query = select(orders.c.id.label('order_id'),
                   orders.c.order_date,
                   orders.c.is_done.label('order_is_done'),
                   users.c.first_name.label('user_first_name'),
                   users.c.last_name.label('user_last_name'),
                   products.c.title.label('product_title')
                   ).join(users).join(products)
    return await database.fetch_all(query)


@router.get("/orders/{order_id}", response_model=Order)
async def read_order(order_id: int):
    query = orders.select().where(orders.c.id == order_id)
    result = await database.fetch_one(query)
    return result if result else \
        JSONResponse(content={'message': f'No order with id = {order_id}'}, status_code=200)


@router.post("/orders/")
async def create_order(order: OrderIn):
    query = orders.insert().values(user_id=order.user_id,
                                   product_id=order.product_id,
                                   order_date=order.order_date,
                                   is_done=order.is_done)
    last_record_id = await database.execute(query)
    return await database.fetch_one(orders.select().where(orders.c.id == last_record_id))


@router.put("/orders/{order_id}", response_model=Order)
async def update_order(order_id: int, order: OrderIn):
    query = orders.update().where(orders.c.id == order_id).values(user_id=order.user_id,
                                                                  product_id=order.product_id,
                                                                  order_date=order.order_date,
                                                                  is_done=order.is_done)
    await database.execute(query)
    result = await database.fetch_one(orders.select().where(orders.c.id == order_id))
    return result if result else \
        JSONResponse(content={'message': f'No order with id = {order_id}'}, status_code=200)


@router.delete("/orders/{order_id}")
async def delete_order(order_id: int):
    query = orders.delete().where(orders.c.id == order_id)
    await database.execute(query)
    return {'message': 'Order has been deleted'}
