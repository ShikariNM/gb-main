from fastapi import APIRouter
from fastapi.responses import JSONResponse
from random import uniform

from hw6.db import products, database
from hw6.models.product import Product, ProductIn

router = APIRouter()


@router.get("/fake_products/{count}")
async def create_products(count: int):
    for i in range(count):
        query = products.insert().values(title=f'title{i}',
                                         description=f'description{i}',
                                         price=round(uniform(10, 1000), 2))
        await database.execute(query)
    return {'message': f'{count} fake products have been created'}


@router.get("/products/", response_model=list[Product])
async def read_products():
    query = products.select()
    return await database.fetch_all(query)


@router.get("/products/{product_id}", response_model=Product)
async def read_product(product_id: int):
    query = products.select().where(products.c.id == product_id)
    result = await database.fetch_one(query)
    return result if result else \
        JSONResponse(content={'message': f'No product with id = {product_id}'}, status_code=200)


@router.post("/products/", response_model=Product)
async def create_product(product: ProductIn):
    query = products.insert().values(title=product.title,
                                     description=product.description,
                                     price=product.price)
    last_record_id = await database.execute(query)
    return {**product.dict(), "id": last_record_id}


@router.put("/products/{product_id}", response_model=Product)
async def update_product(product_id: int, new_product: ProductIn):
    query = products.update().where(products.c.id == product_id).values(**new_product.dict())
    await database.execute(query)
    result = await database.fetch_one(products.select().where(products.c.id == product_id))
    return result if result else \
        JSONResponse(content={'message': f'No product with id = {product_id}'}, status_code=200)


@router.delete("/products/{product_id}")
async def delete_product(product_id: int):
    query = products.delete().where(products.c.id == product_id)
    await database.execute(query)
    return {'message': 'Product has been deleted'}
