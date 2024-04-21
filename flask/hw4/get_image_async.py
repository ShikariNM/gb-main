import asyncio
import aiohttp

import sys
from pathlib import Path

from time_decorators import async_time_decorator


@async_time_decorator(full_program=False)
async def download(url, folder_name='images/'):
    async with aiohttp.ClientSession() as session:
        async with session.get(url) as response:
            content = await response.read()
            folder = Path(folder_name)
            if not folder.is_dir():
                folder.mkdir()
            url = url.split('/')
            file = folder.joinpath(url[-1] if url[-1] else url[-2])
            with open(file, "wb") as f:
                f.write(content)
            return file


@async_time_decorator()
async def main(urls):
    tasks = []
    for url in urls:
        task = asyncio.create_task(download(url))
        tasks.append(task)
    await asyncio.gather(*tasks)

if __name__ == '__main__':
    loop = asyncio.get_event_loop()
    loop.run_until_complete(main(sys.argv[1:]))
