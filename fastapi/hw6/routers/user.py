from fastapi import APIRouter
from fastapi.responses import JSONResponse

from hw6.db import users, database
from hw6.models.user import User, UserIn

router = APIRouter()


@router.get("/fake_users/{count}")
async def create_users(count: int):
    for i in range(count):
        query = users.insert().values(first_name=f'first_name{i}',
                                      last_name=f'last_name{i}',
                                      email=f'email{i}@mail.com',
                                      password=f'password{i}')
        await database.execute(query)
    return {'message': f'{count} fake users have been created'}


@router.get("/users/", response_model=list[User])
async def read_users():
    query = users.select()
    return await database.fetch_all(query)


@router.get("/users/{user_id}", response_model=User)
async def read_user(user_id: int):
    query = users.select().where(users.c.id == user_id)
    result = await database.fetch_one(query)
    return result if result else \
        JSONResponse(content={'message': f'No user with id = {user_id}'}, status_code=200)


@router.post("/users/", response_model=User)
async def create_user(user: UserIn):
    query = users.insert().values(first_name=user.first_name,
                                  last_name=user.last_name,
                                  email=user.email,
                                  password=user.password)
    last_record_id = await database.execute(query)
    return {**user.dict(), "id": last_record_id}


@router.put("/users/{user_id}", response_model=User)
async def update_user(user_id: int, new_user: UserIn):
    query = users.update().where(users.c.id == user_id).values(**new_user.dict())
    await database.execute(query)
    result = await database.fetch_one(users.select().where(users.c.id == user_id))
    return result if result else \
        JSONResponse(content={'message': f'No user with id = {user_id}'}, status_code=200)


@router.delete("/users/{user_id}")
async def delete_user(user_id: int):
    query = users.delete().where(users.c.id == user_id)
    await database.execute(query)
    return {'message': 'User has been deleted'}
