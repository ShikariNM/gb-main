from fastapi import FastAPI, HTTPException
from pydantic import BaseModel
import uvicorn

app = FastAPI()
__id = id


class InTask(BaseModel):
    title: str
    description: str
    is_done: bool


class Task(InTask):
    id: int


tasks: list[Task] = list()


@app.get("/tasks/", response_model=list[Task])
async def get_tasks():
    return tasks


@app.get("/tasks/{task_id}", response_model=Task)
async def get_tasks(task_id: int):
    for task in tasks:
        if task.id == task_id:
            return task
    raise HTTPException(status_code=404, detail="Task not found")


@app.post("/tasks/", response_model=Task)
async def add_task(new_task: InTask):
    new_id = len(tasks) + 1
    tasks.append(Task(id=new_id,
                      title=new_task.title,
                      description=new_task.description,
                      is_done=new_task.is_done))
    return tasks[-1]


@app.put("/tasks/{task_id}/", response_model=Task)
async def change_task(task_id: int, new_task: InTask):
    for task in tasks:
        if task.id == task_id:
            task.title = new_task.title
            task.description = new_task.description
            task.is_done = new_task.is_done
            return task
    raise HTTPException(status_code=404, detail="Task not found")


@app.delete("/tasks/{task_id}", response_model=Task)
async def remove_task(task_id: int):
    for task in tasks:
        if task.id == task_id:
            tasks.remove(task)
            return task
    raise HTTPException(status_code=404, detail="Task not found")


if __name__ == '__main__':
    uvicorn.run(
        f'{__name__}:app',
        host='127.0.0.1',
        port=8000,
        reload=True
    )
