from threading import Thread

import sys
import requests
from pathlib import Path

from time_decorators import time_decorator


@time_decorator(full_program=False)
def download(url, folder_name='images/'):
    response = requests.get(url)
    folder = Path(folder_name)
    if not folder.is_dir():
        folder.mkdir()
    url = url.split('/')
    file = folder.joinpath(url[-1] if url[-1] else url[-2])
    with open(file, "wb") as f:
        f.write(response.content)
    return file


@time_decorator()
def main(urls):
    threads = list()
    for url in urls:
        thread = Thread(target=download, args=[url])
        threads.append(thread)
        thread.start()

    for thread in threads:
        thread.join()


if __name__ == '__main__':
    main(sys.argv[1:])
